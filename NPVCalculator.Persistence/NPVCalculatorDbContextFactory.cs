using Microsoft.EntityFrameworkCore;
using NPVCalculator.Persistence.Infrastructure;

namespace NPVCalculator.Persistence
{
    public class NPVCalculatorDbContextFactory : DesignTimeDbContextFactoryBase<NPVCalculatorDbContext>
    {
        protected override NPVCalculatorDbContext CreateNewInstance(DbContextOptions<NPVCalculatorDbContext> options)
        {
            return new NPVCalculatorDbContext(options);
        }
    }
}
