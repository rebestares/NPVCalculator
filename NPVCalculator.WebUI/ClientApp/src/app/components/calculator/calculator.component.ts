import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { ProjectionModel } from 'src/app/shared/models/models/projections/projection.model';
import { ProjectionListModel } from 'src/app/shared/models/models/projections/projection-list.model';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { MatTable } from '@angular/material';
import { MatDialog } from '@angular/material/dialog';
import { GenericDialogComponent } from '../generic-dialog/generic-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ProjectionSaveCalculation } from 'src/app/shared/models/models/projections/projection-save-calculation-model';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {

  public projectionForm = new FormGroup({});
  public projection: ProjectionModel;
  public projectionListModel: ProjectionListModel;
  public projectionSaveCalculationModel : ProjectionSaveCalculation;
  public displayedProjectionsColumns: string[] = ['year', 'discountRateIncrement', 'initialAmount', 'netPresentValue', 'presentValueExpectedCashflow'];
  public http: HttpClient;
  public baseUrl: string;
  public showLoading:boolean;

  constructor(
    private fb: FormBuilder, 
    http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    public dialog: MatDialog,
    private snackBar: MatSnackBar
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

  addCashflow() {
    this.cashFlowAmount.push(this.fb.control(''));
  }

  resetCalculator() {
    this.initForm();
    this.projectionListModel = null;
  }

  saveResult(){
    this.showLoading = true;

    this.http.post(
      this.baseUrl + 'api/projections/SaveCalculation',
      this.projectionListModel
    ).subscribe(result => {
      this.showLoading = false;
      this.snackBar.open("Result Saved", "Success", {
        duration: 2000,
      });
      this.resetCalculator();
    }, error => console.error(error));

  }

  openDialog(): void {
    const dialogRef = this.dialog.open(GenericDialogComponent, {
      width: '250px',
      data: this.projectionListModel
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.saveResult();
      }
    });
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
