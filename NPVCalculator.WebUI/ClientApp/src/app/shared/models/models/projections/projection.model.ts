export interface ProjectionModel {
    lowerBoundDiscountRate: number;
    upperBoundDiscountRate: number;
    discountRateIncrement: number;
    initialAmount:number;
    cashFlowAmount: number[];
}
