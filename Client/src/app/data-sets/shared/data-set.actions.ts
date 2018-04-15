import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { IAppState } from '../../store/app-state';

@Injectable()
export class DataSetActions {
    constructor(private ngRedux: NgRedux<IAppState>) { }

    public static UPLOAD_FILE = 'UPLOAD_FILE';

    uploadFile(file: any): void {
        this.ngRedux.dispatch({ type: DataSetActions.UPLOAD_FILE, payload: file });
    }
}
