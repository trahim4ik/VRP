export class DataSetItemModel {
    area: number;
    price: number;
    latitude: number;
    longitude: number;
    zipCode: string;

    public constructor(fields?: Partial<DataSetItemModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
