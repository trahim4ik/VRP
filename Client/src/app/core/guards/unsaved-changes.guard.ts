import { CanDeactivate, Routes } from '@angular/router';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Observable } from 'rxjs/Observable';

// import { ConfirmComponent } from '../components';

export interface IHaveChanges {
    haveChanges: () => Observable<boolean> | boolean;
}

@Injectable()
export class UnsavedChangesGuard<T extends IHaveChanges> implements CanDeactivate<T> {

    constructor(
        protected dialog: MatDialog
    ) { }

    canDeactivate(component: T) {
        if (component.haveChanges()) {
            // let dialogRef = this.dialog.open(ConfirmComponent, {
            //     data: {
            //         content: 'Are you sure you want to close this record without saving?'
            //     }
            // });
            // return dialogRef.afterClosed();

            return false;
        }

        return true;
    }
}
