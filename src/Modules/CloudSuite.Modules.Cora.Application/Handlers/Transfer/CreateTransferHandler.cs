using CloudSuite.Infrastructure.Data.Repositories.Cora;
using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Transfer;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer
{
    public class CreateTransferHandler : IRequestHandler<CreateTransferCommand, CreateTransferResponse>
    {
        private readonly ITransferRepository _repositorioTransfer;
        private readonly IAccountRepository _repositorioAccount;
        private readonly ILogger<CreateTransferHandler> _logger;

        public CreateTransferHandler(TransferRepository repositorioTransfer, ILogger<CreateTransferHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CreateTransferResponse> Handle(CreateTransferCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateTransferCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateTransferCommandValidation().Validate(command);
            if (validationResult.IsValid)
            {
                try
                {
                    var transferAccountNumber = await _repositorioAccount.GetByAccountNumber(command.AccountNumberAccount);
                    var transferAmount = await _repositorioTransfer.GetByAmount(command.Amount);
                    var transferBankCodeRecipient = await _repositorioTransfer.GetByBankCodeRecipient(command.BankCodeRecipient);
                    var transferBranchCodeRecipient = await _repositorioTransfer.GetByBranchNumberRecipient(command.BranchNumberRecipient);
                    var transferCategory = await _repositorioTransfer.GetByCategory(command.Category);
                    var transferCode = await _repositorioTransfer.GetByCode(command.Code);
                    var transferScheduled = await _repositorioTransfer.GetByScheduled(command.Scheduled);
                    var transferStatus = await _repositorioTransfer.GetByStatus(command.Status);
                    if (transferAccountNumber != null && transferAmount != null && transferBankCodeRecipient != null && transferBranchCodeRecipient != null &&
                        transferCategory != null && transferCode != null && transferScheduled != null && transferStatus != null)
                    {
                        return await Task.FromResult(new CreateTransferResponse(command.Id, "Transferência já efetuada"));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateTransferResponse(command.Id, "Não foi possível processar a informação."));
                }
            }
            return await Task.FromResult(new CreateTransferResponse(command.Id, validationResult));
        }
    }
}
