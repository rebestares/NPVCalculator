using System;
namespace NPVCalculator.Application.Projections.Commands.CalculateProjection
{
    public class CalculatedProjectionDto
    {
        /// <summary>
        /// Gets or sets the discount rate increment.
        /// </summary>
        /// <value>The discount rate increment.</value>
        public double DiscountRateIncrement { get; set; }

        /// <summary>
        /// Gets or sets the initial amount.
        /// </summary>
        /// <value>The initial amount.</value>
        public double InitialAmount { get; set; }

        /// <summary>
        /// Gets or sets the net present value.
        /// </summary>
        /// <value>The net present value.</value>
        public double NetPresentValue { get; set; }
    }
}
