using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Customer.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Customer;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Customer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {

        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ICustomerRepository repositorioCustomer, ILogger<CreateCustomerHandler> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateCustomerCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateCustomerCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var customerCnpj = await _repositorioCustomer.GetByCnpj(new Cnpj(command.Cnpj));
                    var customerSocialReason = await _repositorioCustomer.GetBySocialReason(command.SocialReason);

                    if (customerCnpj != null && customerSocialReason != null)
                    {
                        return await Task.FromResult(new CreateCustomerResponse(command.Id, "Cliente já cadastrado!"));
                    }
                    await _repositorioCustomer.Add(command.GetEntity());
                    return await Task.FromResult(new CreateCustomerResponse(command.Id, validationResult));
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateCustomerResponse(command.Id, "Não foi possível processar a solicitação."));
                }
            }
            return await Task.FromResult(new CreateCustomerResponse(command.Id, validationResult));
        }
    }
}
