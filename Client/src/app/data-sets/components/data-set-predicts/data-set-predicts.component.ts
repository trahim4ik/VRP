import { Component, Input, OnChanges, OnInit, ViewChild } from '@angular/core';

import { DataSetPredictModel } from '../../shared';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'data-set-predicts',
  templateUrl: './data-set-predicts.component.html',
  styleUrls: ['./data-set-predicts.component.scss']
})
export class DataSetPredictsComponent implements OnChanges, OnInit {

  @Input() id: number;
  @Input() items: DataSetPredictModel[] = [];

  protected displayedColumns = ['predict', 'target', 'absolute', 'relative', 'difference'];
  protected lineChartData: Array<any> = [];
  public lineChartLabels: Array<any> = [];

  protected isBuilded = false;
  protected lineChartOptions: any = { responsive: false };
  protected lineChartColors: Array<any> = [
    { // grey
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    { // dark grey
      backgroundColor: 'rgba(77,83,96,0.2)',
      borderColor: 'rgba(77,83,96,1)',
      pointBackgroundColor: 'rgba(77,83,96,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)'
    }
  ];

  protected lineChartLegend = true;
  protected lineChartType = 'line';

  protected pageSizeOptions = [50];
  protected pageEvent: PageEvent = { pageSize: 50, pageIndex: 0, length: 0 };


  constructor() { }

  ngOnInit(): void {
    this.pageEvent.length = this.items.length;
    this.buildChartData();
  }

  ngOnChanges(changes: any): void {
    if (changes && changes.items) {
      this.pageEvent.length = this.items.length;
      this.buildChartData();
    }
  }

  protected buildChartData(): void {
    this.isBuilded = false;
    const start: number = this.pageEvent.pageIndex * this.pageEvent.pageSize;
    const end: number = start + this.pageEvent.pageSize;

    this.lineChartData = [
      { data: this.items.map(x => x.target).slice(start, end), label: 'Target' },
      { data: this.items.map(x => x.predict).slice(start, end), label: 'Predict' },
    ];
    this.lineChartLabels = this.items.map(x => x.id).slice(start, end);
    this.isBuilded = true;
  }

  protected onChangePage(event: PageEvent): void {
    this.pageEvent = event;
    this.buildChartData();
  }

}
