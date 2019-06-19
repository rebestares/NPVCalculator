using System;
namespace NPVCalculator.Application.Projections.Commands.SaveCalculation
{
    public class SaveCommandDto
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

        /// <summary>
        /// Gets or sets the present value expected cashflow.
        /// </summary>
        /// <value>The present value expected cashflow.</value>
        public double PresentValueExpectedCashflow { get; set; }

        /// <summary>
        /// Gets or sets the lower bound discount rate.
        /// </summary>
        /// <value>The lower bound discount rate.</value>
        public double LowerBoundDiscountRate { get; set; }

        /// <summary>
        /// Gets or sets the upper bound discount rate.
        /// </summary>
        /// <value>The upper bound discount rate.</value>
        public double UpperBoundDiscountRate { get; set; }
    }
}
