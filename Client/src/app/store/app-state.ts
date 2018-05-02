import { UserModel } from '../core/models';
import { DataSetItemModel, DataSetModel, DataSetItemSearchModel } from '../data-sets/shared/models';

export interface IAppState {
    user?: UserModel;
    dataSet?: DataSetModel;
    dataSetItems?: DataSetItemModel[];
    dataSetItemsSearch?: DataSetItemSearchModel;
}
