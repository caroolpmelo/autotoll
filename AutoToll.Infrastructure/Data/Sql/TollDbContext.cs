using AutoToll.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoToll.Infrastructure.Data.Sql
{
    public class TollDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the TollDbContext class using the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public TollDbContext(DbContextOptions<TollDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// DbSet representing the Transactions table in PostgreSQL
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }
    }
}
