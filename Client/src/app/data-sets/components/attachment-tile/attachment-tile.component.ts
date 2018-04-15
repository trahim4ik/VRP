import { Component, Input } from '@angular/core';
import { FileEntryModel } from '../../../shared/models';

@Component({
  selector: 'attachment-tile',
  templateUrl: './attachment-tile.component.html',
  styleUrls: ['./attachment-tile.component.scss']
})
export class AttachmentTileComponent {
  @Input() attachment: FileEntryModel;
}

