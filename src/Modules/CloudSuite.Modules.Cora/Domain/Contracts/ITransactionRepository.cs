using CloudSuite.Modules.Cora.Domain.Models;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
    public interface TransactionRepository
    {
        Task<Transaction> GetByCounterPartyName(string EntryTransactionCounterPartyName);

        Task<Transaction> GetByTransactionOrder(string transactionOrder);

        Task<IEnumerable<Transaction>> GetList();

        Task Add(Transaction transaction);

        void Update(Transaction transaction);

        void Remove(Transaction transaction);
   
    }
}