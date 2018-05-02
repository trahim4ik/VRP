import { combineReducers } from 'redux';

import { userReducer } from '../users/shared';
import { dataSetReducer, dataSetItemsReducer } from '../data-sets/shared/store';

export const rootReducer = combineReducers({
    user: userReducer,
    dataSet: dataSetReducer,
    dataSetItems: dataSetItemsReducer
});
