using CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Payments.Boletos;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos
{
	//public class CreateBoletoHandler : IRequestHandler<CreateBoletoCommand, CreateBoletoResponse>
	//{
		//private readonly IBoletoRepository _boletoRepository;
		//private readonly ILogger<CreateBoletoHandler> _logger;

		//public CreateBoletoHandler(IBoletoRepository boletoRepository, ILogger<CreateBoletoHandler> logger)
		//{
			//_boletoRepository = boletoRepository;
			//_logger = logger;

		//}
		//public async Task<CreateBoletoResponse> Handle(CreateBoletoCommand command, CancellationToken cancellationToken)
		//{
			//_logger.LogInformation($"CreateBoletoCommand: {JsonSerializer.Serialize(command)}");
			//var validationResult = new CreateBoletoCommandValidation().Validate(command);

			//if (validationResult.IsValid)
			//{
				//try
				//{
					//var digitableLine = await _boletoRepository.getByDigitableLine
				//}
			//}
		//}
	//}
}
