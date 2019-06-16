using System;
namespace NPVCalculator.Application.Projections.Queries
{
    /// <summary>
    /// Projection Data transfer object
    /// </summary>
    public class ProjectionDto
    {
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
        /// Gets or sets the cashflow amount.
        /// </summary>
        /// <value>The cashflow amount.</value>
        public double CashflowAmount { get; set; }

        /// <summary>
        /// Gets or sets the projected amount.
        /// </summary>
        /// <value>The projected amount.</value>
        public double ProjectedAmount { get; set; }

        /// <summary>
        /// Gets or sets the initial value.
        /// </summary>
        /// <value>The initial value.</value>
        public double InitialValue { get; set; }

        /// <summary>
        /// Gets or sets the date added.
        /// </summary>
        /// <value>The date added.</value>
        public DateTime DateAdded { get; set; }
    }

}
