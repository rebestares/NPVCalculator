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
    MatToolbarModule
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
        MatToolbarModule],
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
        MatToolbarModule
    ]
})
export class MaterialModule{
    
}