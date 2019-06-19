using System;
using System.Collections.Generic;

namespace NPVCalculator.Application.Projections.Commands.CalculateProjection
{
    /// <summary>
    /// Calculated projection response.
    /// </summary>
    public class CalculatedProjectionResponse
    {
        /// <summary>
        /// Gets or sets the projections.
        /// </summary>
        /// <value>The projections.</value>
        public IList<CalculatedProjectionDto> Projections { get; set; }
    }
}
