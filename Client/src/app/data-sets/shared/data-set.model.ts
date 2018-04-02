export class DataSetModel {
    id: number;
    name: string;
    description: string;

    public constructor(fields?: Partial<DataSetModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
