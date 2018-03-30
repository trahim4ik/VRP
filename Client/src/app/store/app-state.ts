import { UserModel } from '../core/models';
import { DataSetModel } from '../data-sets/shared';

export interface IAppState {
    user?: UserModel;
    dataSet?: DataSetModel;
}
