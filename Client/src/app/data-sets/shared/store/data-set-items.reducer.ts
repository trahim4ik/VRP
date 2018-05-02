import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { DataSetItemController } from '../network';
import { DataSetModel, DataSetItemModel } from '../models';

export const dataSetItemsReducer: Reducer<DataSetItemModel[]> = (
    state: DataSetItemModel[] = [], action: FluxStandardAction<DataSetItemModel[]>): DataSetItemModel[] => {
    switch (action.type) {

        case DataSetItemController.SEARCH_DATASET_ITEMS:
            return Object.assign([], action.payload);

        case DataSetItemController.LAZY_DATASET_ITEMS:
            const newState = Object.assign([], state);
            newState.push(...action.payload);
            return newState;

        default:
            return state;
    }
};
