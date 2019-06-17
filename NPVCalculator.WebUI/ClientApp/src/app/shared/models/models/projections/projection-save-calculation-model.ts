export interface ProjectionSaveCalculation {
    computedNetPresentValue: number
    expectedPresentCashflowValue: number
    lowerBoundDiscountRate: number;
    upperBoundDiscountRate: number;
    discountRateIncrement: number;
    initialAmount: number;
}