import { SearchModel } from '../../../core/models';

export class DataSetItemSearchModel extends SearchModel {

    public dataSetType: number;
    public dataSetId: number;

    public constructor(fields?: Partial<DataSetItemSearchModel>) {
        super();
        if (fields) {
            Object.assign(this, fields);
        }
    }
}
