using System;
using System.Collections.Generic;

namespace NPVCalculator.Application.Projections.Queries
{
    /// <summary>
    /// Projection list view model.
    /// </summary>
    public class ProjectionListViewModel
    {
        /// <summary>
        /// Gets or sets the projections.
        /// </summary>
        /// <value>The projections.</value>
        public IEnumerable<ProjectionDto> Projections { get; set; }
    }
}
