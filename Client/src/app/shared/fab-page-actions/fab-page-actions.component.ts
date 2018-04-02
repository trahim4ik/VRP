import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'fab-page-actions',
  templateUrl: './fab-page-actions.component.html',
  styleUrls: ['./fab-page-actions.component.scss']
})
export class FabPageActionsComponent implements OnInit {

  @Input() disabled: boolean;

  @Output() save = new EventEmitter();

  @Output() cancel = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

}
