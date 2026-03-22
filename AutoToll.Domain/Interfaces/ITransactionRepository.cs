using AutoToll.Domain.Entities;

namespace AutoToll.Domain.Interfaces
{
    public interface ITransactionRepository // Interface for SQL DB (Transactions)
    {
        /// <summary>
        /// Asynchronously saves the specified transaction.
        /// </summary>
        /// <param name="transaction">The transaction to save.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveTransactionAsync(Transaction transaction);
    }
}
