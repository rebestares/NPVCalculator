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

        /// <summary>
        /// Gets or sets the computed net present value.
        /// </summary>
        /// <value>The computed net present value.</value>
        public double ComputedNetPresentValue { get; set; }

        /// <summary>
        /// Gets or sets the expected present cashflow value.
        /// </summary>
        /// <value>The expected present cashflow value.</value>
        public double ExpectedPresentCashflowValue { get; set; }
    }
}
