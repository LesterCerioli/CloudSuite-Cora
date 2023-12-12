using CloudSuite.Modules.Cora.Application.Handlers.Customer.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Customer.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Customer;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Cora.Application.Handlers.Customer
{
    public class CheckCustomerExistsBySocialHandler : IRequestHandler<CheckCustomerExistsBySocialReasonRequest, CheckCustomerExistsBySocialReasonResponse>
    {
        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CheckCustomerExistsBySocialHandler> _logger;

        public async Task<CheckCustomerExistsBySocialReasonResponse> Handle(CheckCustomerExistsBySocialReasonRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCustomerExistsBySocialReasonRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCustomerExistsBySocialReasonRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var paciente = await _repositorioCustomer.GetBySocialReason(request.SocialReasion);
                    if (paciente != null)
                        return await Task.FromResult(new CheckCustomerExistsBySocialReasonResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCustomerExistsBySocialReasonResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckCustomerExistsBySocialReasonResponse(request.Id, false, validationResult));
        }
    }
}
