import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProjectionModel } from 'src/app/shared/models/models/projections/projection.model';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ProjectionModel[]>(baseUrl + 'api/projections/getall').subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
  ngOnInit() {
  }

  
}
