using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NPVCalculator.Domain.Entities;

namespace NPVCalculator.Application.Interfaces
{
    /// <summary>
    /// NPVC alculator db context.
    /// </summary>
    public interface INPVCalculatorDbContext
    {
        /// <summary>
        /// Gets or sets the projections.
        /// </summary>
        /// <value>The projections.</value>
        DbSet<Projection> Projections { get; set; }

        /// <summary>
        /// Save asynchrounous changes on database
        /// </summary>
        /// <param name="cancellationToken">CancellationToken object</param>
        /// <returns>Task</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
