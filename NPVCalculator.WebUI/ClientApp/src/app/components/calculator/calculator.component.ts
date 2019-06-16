import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { ProjectionModel } from 'src/app/shared/models/models/projections/projection.model';
import { ProjectionListModel } from 'src/app/shared/models/models/projections/projection-list.model';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { MatTable } from '@angular/material';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {

  public projectionForm = new FormGroup({});

  public projection: ProjectionModel;
  public projectionListModel: ProjectionListModel;
  public displayedProjectionsColumns: string[] = ['year', 'discountRateIncrement', 'initialAmount', 'netPresentValue'];
  public http: HttpClient;
  public baseUrl: string;

  constructor(private fb: FormBuilder, http: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.initForm();
  }
  @ViewChild(MatTable) computationResultTable: MatTable<any>;

  public initForm(): void {

    this.projectionForm = this.fb.group({
      lowerBoundDiscountRate: [''],
      upperBoundDiscountRate: [''],
      discountRateIncrement: [''],
      initialAmount: [''],
      cashFlowAmount: this.fb.array([
        this.fb.control('')
      ])
    });
  }

  get cashFlowAmount() {
    return this.projectionForm.get('cashFlowAmount') as FormArray;
  }

  addCashflow(control) {
    this.cashFlowAmount.push(this.fb.control(''));
  }

  resetCalculator() {
    this.initForm();
    this.projectionListModel = null;
  }

  calculateProjection() {
    this.http.post(
      this.baseUrl + 'api/projections/CalculateNPV',
      this.projectionForm.value
    ).subscribe(result => {
      this.projectionListModel = result as ProjectionListModel;

      if (this.computationResultTable != null)
        this.computationResultTable.renderRows();
        
    }, error => console.error(error));
  }
}
