using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Customer.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Customer.Responses;
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
    public class CheckCustomerExistsByCnpjHandler : IRequestHandler<CheckCustomerExistsByCnpjRequest, CheckCustomerExistsByCnpjResponse>
    {

        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CheckCustomerExistsByCnpjHandler> _logger;

        public CheckCustomerExistsByCnpjHandler(ICustomerRepository repositorioCustomer, ILogger<CheckCustomerExistsByCnpjHandler> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByCnpjResponse> Handle(CheckCustomerExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCustomerExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCustomerExistsByCnpjRequestValidation ().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var paciente = await _repositorioCustomer.GetByCnpj(new Cnpj(request.Cnpj));
                    if (paciente != null)
                        return await Task.FromResult(new CheckCustomerExistsByCnpjResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCustomerExistsByCnpjResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckCustomerExistsByCnpjResponse(request.Id, false, validationResult));
        }
    }
}
