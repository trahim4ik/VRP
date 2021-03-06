import { combineReducers } from 'redux';

import { userReducer } from '../users/shared';
import {
    dataSetReducer,
    dataSetItemsReducer,
    dataSetItemsSearchReducer,
    dataSetNetworksReducer,
    dataSetPredictsReducer
} from '../data-sets/shared/store';

export const rootReducer = combineReducers({
    user: userReducer,
    dataSet: dataSetReducer,
    dataSetItems: dataSetItemsReducer,
    dataSetItemsSearch: dataSetItemsSearchReducer,
    dataSetNetworks: dataSetNetworksReducer,
    dataSetPredicts: dataSetPredictsReducer
});
