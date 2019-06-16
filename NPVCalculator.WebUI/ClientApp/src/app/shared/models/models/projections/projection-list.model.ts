import { ProjectionModel } from "./projection.model";

export interface ProjectionListModel {
    projections: ProjectionModel[]
    computedNetPresentValue:number
    expectedPresentCashflowValue:number
}
