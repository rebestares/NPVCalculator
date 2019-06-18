import { Component, OnInit, Inject,ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProjectionListHistoryModel } from  'src/app/shared/models/models/projections/projection-list-history-model';
import { MatTable } from '@angular/material';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  public displayedProjectionsColumns: string[] = ['id', 'lowerBoundDiscountRate', 'upperBoundDiscountRate', 'discountRateIncrement', 'computedNetPresentValue','expectedPresentCashflowValue'];
  public projectionListModel: ProjectionListHistoryModel;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ProjectionListHistoryModel>(baseUrl + 'api/projections/getall').subscribe(result => {

      this.projectionListModel = result as ProjectionListHistoryModel;

      if (this.computationResultTable != null)
        this.computationResultTable.renderRows();
    }, error => console.error(error));
  }
  ngOnInit() {
  }

  @ViewChild(MatTable) computationResultTable: MatTable<any>;

  
}
