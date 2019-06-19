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
        /// Gets or sets the projections.
        /// </summary>
        /// <value>The projections.</value>
        public IList<SaveCommandDto> Projections { get; set; }

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

                    foreach(var projection in request.Projections)
                    {
                        var entity = new Projection
                        {
                            Id = Guid.NewGuid(),
                            DateAdded = DateTime.UtcNow,
                            DiscountRateIncrement = projection.DiscountRateIncrement,
                            LowerBoundDiscountRate = projection.LowerBoundDiscountRate,
                            UpperBoundDiscountRate = projection.UpperBoundDiscountRate,
                            ComputedNetPresentValue = projection.NetPresentValue,
                            ExpectedPresentCashflowValue = projection.PresentValueExpectedCashflow
                        };

                        _context.Projections.Add(entity);

                    }

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
