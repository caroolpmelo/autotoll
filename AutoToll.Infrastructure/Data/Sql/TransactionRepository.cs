using AutoToll.Domain.Entities;
using AutoToll.Domain.Interfaces;

namespace AutoToll.Infrastructure.Data.Sql
{
    public class TransactionRepository : ITransactionRepository
    {
        /// <summary>
        /// Provides access to the database context for toll operations.
        /// </summary>
        private readonly TollDbContext _context;

        /// <summary>
        /// Initializes a new instance of the TransactionRepository class using the specified database context.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public TransactionRepository(TollDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously saves a transaction to the database.
        /// </summary>
        /// <param name="transaction">The transaction to save.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task SaveTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync(); // Records on PostgreSQL, ensuring ACID compliance
        }
    }
}
