import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { DataSetModel } from '../models';
import { DataSetController } from '../network';
import { DataSetActions } from '../store';

export const dataSetReducer: Reducer<DataSetModel> = (
    state: DataSetModel = null, action: FluxStandardAction<DataSetModel>): DataSetModel => {
    switch (action.type) {
        case DataSetController.LOADED_DATASET:
            return Object.assign({}, state, action.payload);
        case DataSetActions.UPLOAD_FILE:
            const dataSet = Object.assign({}, state);
            dataSet.fileEntries.push(action.payload);
            return dataSet;
        default:
            return state;
    }
};
