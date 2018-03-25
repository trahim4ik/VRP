import { UserModel } from '../core/models';

export interface IAppState {
    user?: UserModel;
    feedback?: any;
}
