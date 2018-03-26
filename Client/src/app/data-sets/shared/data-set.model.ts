export class DataSetModel {
    area: number;
    price: number;
    latitude: number;
    longitude: number;
    zipCode: string;

    public constructor(fields?: Partial<DataSetModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
