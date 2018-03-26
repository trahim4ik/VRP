import { Reducer } from 'redux';
import { FluxStandardAction } from 'flux-standard-action';

import { RealtyController } from './realty.controller';
import { RealtyModel } from './realty.model';

export const realtyReducer: Reducer<RealtyModel> = (state: RealtyModel = null, action: FluxStandardAction<RealtyModel>): RealtyModel => {
    switch (action.type) {
        case RealtyController.prototype.get.toString():
            return Object.assign({}, state, action.payload);
        default:
            return state;
    }
};
