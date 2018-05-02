import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { DataSetItemController } from '../network';
import { DataSetItemSearchModel } from '../models';

export const dataSetItemsSearchReducer: Reducer<DataSetItemSearchModel> = (
    state: DataSetItemSearchModel = new DataSetItemSearchModel({ dataSetType: 0, limit: 100, skip: 0 }),
    action: FluxStandardAction<DataSetItemSearchModel>): DataSetItemSearchModel => {
    switch (action.type) {
        default:
            return state;
    }
};
