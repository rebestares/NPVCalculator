using Microsoft.EntityFrameworkCore;
using NPVCalculator.Application.Interfaces;
using NPVCalculator.Domain.Entities;

namespace NPVCalculator.Persistence
{
    public class NPVCalculatorDbContext : DbContext, INPVCalculatorDbContext
    {
        /// <summary>
        /// NPV calculator Db context consturctor
        /// </summary>
        /// <param name="options"></param>
        public NPVCalculatorDbContext(DbContextOptions<NPVCalculatorDbContext> options)
           : base(options)
        {
        }
        public DbSet<Projection> Projections { get; set; }

        /// <summary>
        /// Method invoked when creating db context
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NPVCalculatorDbContext).Assembly);
        }
    }
}
