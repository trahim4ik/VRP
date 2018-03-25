import { combineReducers } from 'redux';

import { userReducer } from '../users/shared';

export const rootReducer = combineReducers({
    user: userReducer
});
