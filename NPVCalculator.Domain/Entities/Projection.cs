using System;
namespace NPVCalculator.Domain.Entities
{
    public class Projection
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

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

        /// <summary>
        /// Gets or sets the discount rate increment.
        /// </summary>
        /// <value>The discount rate increment.</value>
        public double DiscountRateIncrement { get; set; }

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

        /// <summary>
        /// Gets or sets the date added.
        /// </summary>
        /// <value>The date added.</value>
        public DateTime DateAdded { get; set; }
    }
}
