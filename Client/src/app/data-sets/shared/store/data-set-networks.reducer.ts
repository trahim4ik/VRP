import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { DataSetNetworkController } from '../network';
import { DataSetNetworkModel } from '../models';
import { DataSetActions } from './data-set.actions';

export const dataSetNetworksReducer: Reducer<DataSetNetworkModel[]> = (
    state: DataSetNetworkModel[] = [], action: FluxStandardAction<DataSetNetworkModel[]>): DataSetNetworkModel[] => {

    switch (action.type) {

        case DataSetNetworkController.LOADED_DATASET_NETWORKS:
            return Object.assign([], action.payload);
        case DataSetActions.UPLOAD_FILE:
            return Object.assign([], (<any>action.payload).dataSetNetworks);

        default:
            return state;
    }
};
