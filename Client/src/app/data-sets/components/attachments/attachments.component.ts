import { Component, Input } from '@angular/core';

import { DataSetModel, DataSetActions, DataSetsNetwork } from '../../shared';
import { FileEntryModel } from '../../../shared/models';

@Component({
  selector: 'attachments',
  templateUrl: './attachments.component.html',
  styleUrls: ['./attachments.component.scss']
})
export class AttachmentsComponent {

  @Input() id: number;
  @Input() attachments: FileEntryModel[];

  constructor(public actions: DataSetActions) { }

  protected getUrl(): string {
    return `api/File/Upload/${this.id}`;
  }

}
