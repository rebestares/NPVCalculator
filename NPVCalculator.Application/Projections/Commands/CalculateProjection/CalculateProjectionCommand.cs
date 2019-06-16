using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NPVCalculator.Application.Interfaces;

namespace NPVCalculator.Application.Projections.Commands.CalculateProjection
{
    public class CalculateProjectionCommand : IRequest<CalculatedProjectionResponse>
    {
        public double LowerBoundDiscountRate { get; set; }

        public double UpperBoundDiscountRate { get; set; }

        public double DiscountRateIncrement { get; set; }

        public double InitialAmount { get; set; }

        public IEnumerable<double> CashFlowAmount { get; set; }

        /// <summary>
        /// Handler for CalculationProjectionCommand.
        /// </summary>
        public class Handler : IRequestHandler<CalculateProjectionCommand, CalculatedProjectionResponse>
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
            public async Task<CalculatedProjectionResponse> Handle(CalculateProjectionCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    ComputeNetPresentValue(request);

                    return ComputeNetPresentValue(request);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// Computes the net present value.
            /// </summary>
            /// <returns>The net present value.</returns>
            /// <param name="request">Request.</param>
            private CalculatedProjectionResponse ComputeNetPresentValue(CalculateProjectionCommand request)
            {
                const int decimalPlaces = 2;
                var lowerBoundDiscountRatePass = 0;
                var currentDiscountRate = request.DiscountRateIncrement;
                var cashFlowProjections = new List<CalculatedProjectionDto>();


                while (currentDiscountRate < request.UpperBoundDiscountRate)
                {

                    if (lowerBoundDiscountRatePass != 0)
                    {
                        currentDiscountRate += request.DiscountRateIncrement;

                        if (currentDiscountRate > request.UpperBoundDiscountRate)
                            continue;
                    }
                    else
                    {
                        currentDiscountRate = request.LowerBoundDiscountRate;
                        lowerBoundDiscountRatePass++;
                    }

                    var computedDiscountRate = Math.Pow(1 + currentDiscountRate, lowerBoundDiscountRatePass);
                    var netPresentValue = 0.00;
                    foreach(var cashFlow in request.CashFlowAmount)
                    {
                        netPresentValue += cashFlow / computedDiscountRate;
                    }

                    cashFlowProjections.Add(new CalculatedProjectionDto()
                    {
                        NetPresentValue = Math.Round(netPresentValue,decimalPlaces),
                        DiscountRateIncrement = Math.Round(currentDiscountRate, decimalPlaces),
                        InitialAmount = request.InitialAmount
                    });
                }

                var totalNPV = cashFlowProjections.Sum(a => a.NetPresentValue) - request.InitialAmount;
                var expectedPresentCashflowValue = cashFlowProjections.Sum(a => a.NetPresentValue);

                var response = new CalculatedProjectionResponse()
                {
                    ComputedNetPresentValue = Math.Round(totalNPV, decimalPlaces),
                    ExpectedPresentCashflowValue = Math.Round(expectedPresentCashflowValue, decimalPlaces),
                    Projections = cashFlowProjections 
                };

                return response;
            }
        }
    }
}
