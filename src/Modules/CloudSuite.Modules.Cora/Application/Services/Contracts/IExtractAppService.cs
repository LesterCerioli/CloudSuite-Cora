namespace CloudSuite.Modules.Cora.Application.Services.Contracts
{
    public interface IExtractAppService
    {
        Task<ExtractViewModeel> GetByEndDate(DateTimeOffset startDate);

        Task<ExtractViewModel> GetByStartDate(DateTimeOffset startDate);

        Task<ExtractViewModel> GetByEntryType(OperationTypeEnum entryType);
        
        Task<ExtractViewModel> GetByEntryAmount(decimal entryAmount);
        
        Task Save(CreateExtractCommand createCommand);
         
    }
}