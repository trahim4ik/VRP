import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { UserModel } from '../../core/models';
import { UsersController } from './users.controller';

export const userReducer: Reducer<UserModel> = (state: UserModel = null, action: FluxStandardAction<UserModel>): UserModel => {
    switch (action.type) {
        case UsersController.prototype.get.toString():
            return Object.assign({}, state, action.payload);
        default:
            return state;
    }
};
