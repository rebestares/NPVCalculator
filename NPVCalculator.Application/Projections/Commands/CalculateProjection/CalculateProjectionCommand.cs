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

            /// <summary>
            /// Handle the specified request and cancellationToken.
            /// </summary>
            /// <returns>The handle.</returns>
            /// <param name="request">Request.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            public async Task<CalculatedProjectionResponse> Handle(CalculateProjectionCommand request, CancellationToken cancellationToken)
            {
                if(request == null)
                {
                    throw new ArgumentNullException();
                }

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
                var expectedCashflowAmountList = new List<double>();

                List<double> netPresentValueList;
                while (currentDiscountRate < request.UpperBoundDiscountRate)
                {
                    netPresentValueList = new List<double>();

                    if (lowerBoundDiscountRatePass != 0)
                    {
                        currentDiscountRate  += request.DiscountRateIncrement;

                        if (currentDiscountRate > request.UpperBoundDiscountRate)
                            continue;
                    }
                    else
                    {
                        currentDiscountRate = request.LowerBoundDiscountRate;
                        lowerBoundDiscountRatePass++;
                    }

                    var realDiscountRate = (currentDiscountRate / 100) + 1;

                    var discountRateForPresentValue = 1;
                    foreach(var cashFlow in request.CashFlowAmount)
                    {
                        var computedDiscountRate = Math.Pow(realDiscountRate, discountRateForPresentValue);
                        var netPresentValue = cashFlow / computedDiscountRate;
                        netPresentValueList.Add(netPresentValue);
                        discountRateForPresentValue++;
                    }


                    var presentValue = netPresentValueList.Sum();
                    var totalNPV = netPresentValueList.Sum() - request.InitialAmount;
                    var presentValueExpectedCashflow = netPresentValueList.Sum();
                    cashFlowProjections.Add(new CalculatedProjectionDto()
                    {
                        NetPresentValue = Math.Round(totalNPV, decimalPlaces),
                        DiscountRateIncrement = Math.Round(currentDiscountRate, decimalPlaces),
                        InitialAmount = request.InitialAmount,
                        PresentValueExpectedCashflow = Math.Round(presentValueExpectedCashflow, decimalPlaces),
                        UpperBoundDiscountRate = request.UpperBoundDiscountRate,
                        LowerBoundDiscountRate = currentDiscountRate
                    });

                    expectedCashflowAmountList.Add(presentValue);
                }

                var response = new CalculatedProjectionResponse()
                {
                    Projections = cashFlowProjections 
                };

                return response;
            }
        }
    }
}
