import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { DataSetItemController } from '../network';
import { DataSetModel } from '../models';

export const dataSetItemsReducer: Reducer<DataSetModel> = (
    state: DataSetModel = null, action: FluxStandardAction<DataSetModel>): DataSetModel => {
    switch (action.type) {
        case DataSetItemController.LOADED_DATASET_ITEMS:
            return Object.assign([], state, action.payload);
        default:
            return state;
    }
};
