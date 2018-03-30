import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { DataSetController } from './data-set.controller';
import { DataSetModel } from '.';

export const dataSetReducer: Reducer<DataSetModel> = (
    state: DataSetModel = null, action: FluxStandardAction<DataSetModel>): DataSetModel => {
    switch (action.type) {
        case DataSetController.prototype.get.toString():
            return Object.assign({}, state, action.payload);
        default:
            return state;
    }
};
