using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NPVCalculator.Application.Interfaces;
using NPVCalculator.Application.Projections.Commands.CalculateProjection;
using NPVCalculator.Domain.Entities;

namespace NPVCalculator.Application.Projections.Commands.SaveCalculation
{
    public class SaveCalculationCommand : IRequest<bool>
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
        /// Gets or sets the computed net present value.
        /// </summary>
        /// <value>The computed net present value.</value>
        public double ComputedNetPresentValue { get; set; }

        /// <summary>
        /// Gets or sets the expected present cashflow value.
        /// </summary>
        /// <value>The expected present cashflow value.</value>
        public double ExpectedPresentCashflowValue { get; set; }

        public class Handler : IRequestHandler<SaveCalculationCommand, bool>
        {
            private readonly INPVCalculatorDbContext _context;
            private readonly IMediator _mediator;

            public Handler(INPVCalculatorDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            /// <summary>
            /// Handle the specified request and cancellationToken.
            /// </summary>
            /// <returns>The handle.</returns>
            /// <param name="request">Request.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            public async Task<bool> Handle(SaveCalculationCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    var entity = new Projection
                    {
                        Id = Guid.NewGuid(),
                        ComputedNetPresentValue = request.ComputedNetPresentValue,
                        DateAdded = DateTime.UtcNow,
                        DiscountRateIncrement = request.DiscountRateIncrement,
                        ExpectedPresentCashflowValue = request.ExpectedPresentCashflowValue,
                        LowerBoundDiscountRate = request.LowerBoundDiscountRate,
                        UpperBoundDiscountRate = request.UpperBoundDiscountRate
                    };

                    _context.Projections.Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

      }
}
