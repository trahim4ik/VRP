import { combineReducers } from 'redux';

import { userReducer } from '../users/shared';
import { dataSetReducer } from '../data-sets/shared';

export const rootReducer = combineReducers({
    user: userReducer,
    dataSet: dataSetReducer
});
