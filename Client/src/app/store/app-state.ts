import { UserModel } from '../core/models';
import {
    DataSetItemModel,
    DataSetModel,
    DataSetItemSearchModel,
    DataSetNetworkModel,
    DataSetPredictModel
} from '../data-sets/shared/models';

export interface IAppState {
    user?: UserModel;
    dataSet?: DataSetModel;
    dataSetItems?: DataSetItemModel[];
    dataSetNetworks?: DataSetNetworkModel[];
    dataSetPredicts?: DataSetPredictModel[];
    dataSetItemsSearch?: DataSetItemSearchModel;
}
