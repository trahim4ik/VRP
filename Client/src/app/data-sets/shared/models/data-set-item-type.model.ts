export class DataSetItemTypeModel {
    public value: number;
    public name: string;

    public constructor(fields?: Partial<DataSetItemTypeModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
