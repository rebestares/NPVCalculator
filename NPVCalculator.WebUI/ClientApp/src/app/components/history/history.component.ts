import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProjectionListModel } from 'src/app/shared/models/models/projections/projection-list.model';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ProjectionListModel>(baseUrl + 'api/projections/getall').subscribe(result => {
      console.table(result);
    }, error => console.error(error));
  }
  ngOnInit() {
  }

  
}
