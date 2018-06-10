import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { DataSetPredictController } from '../network';
import { DataSetPredictModel } from '../models';
import { DataSetActions } from './data-set.actions';

export const dataSetPredictsReducer: Reducer<DataSetPredictModel[]> = (
    state: DataSetPredictModel[] = [], action: FluxStandardAction<DataSetPredictModel[]>): DataSetPredictModel[] => {

    switch (action.type) {

        case DataSetPredictController.LOADED_DATASET_PREDICTS:
            return Object.assign([], action.payload);
        case DataSetActions.UPLOAD_FILE:
            return Object.assign([], (<any>action.payload).dataSetPredicts.map(x => new DataSetPredictModel(x)));

        default:
            return state;
    }
};
