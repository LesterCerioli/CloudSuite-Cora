using CloudSuite.Modules.Cora.Application.Handlers.Account;
using CloudSuite.Modules.Cora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Services.Contracts
{
    public interface IExtractAppService
    {
        Task<ExtractViewModel> GetByStartDate(DateTimeOffset startDate);

        Task<ExtractViewModel> GetByEndDate(DateTimeOffset endDate);

        Task<ExtractViewModel> GetByCustomer(Customer customer);

        Task<ExtractViewModel> GetByEntryType(OperationTypeEnum entryType);

        Task<ExtractViewmodel> GetByEntryAmount(decimal entryAmount);

        Task Save(CreateExtractCommand createCommand);
         
    }
}