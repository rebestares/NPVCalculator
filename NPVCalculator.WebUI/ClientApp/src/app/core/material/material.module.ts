import { NgModule } from '@angular/core';

import {
    MatButtonModule, 
    MatCheckboxModule, 
    MatDatepickerModule, 
    MatNativeDateModule,
    MatFormFieldModule, 
    MatInputModule, 
    MatIconModule, 
    MatMenuModule, 
    MatCardModule,
    MatTableModule, 
    MatPaginatorModule, 
    MatSortModule,
    MatDialogModule,
    MatToolbarModule,
    MatExpansionModule,
    MatGridListModule,
    MatSnackBarModule,
    MatProgressBarModule
  } from '@angular/material';

  @NgModule({
    imports: [
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatIconModule,
        MatCardModule,
        MatTableModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatMenuModule,
        MatSortModule,
        MatDialogModule,
        MatToolbarModule,
        MatExpansionModule,
        MatGridListModule,
        MatSnackBarModule,
        MatProgressBarModule
    ],
    exports: [
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatIconModule,
        MatCardModule,
        MatTableModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatMenuModule,
        MatSortModule,
        MatDialogModule,
        MatToolbarModule,
        MatExpansionModule,
        MatGridListModule,
        MatSnackBarModule,
        MatProgressBarModule
    ]
})
export class MaterialModule{
    
}