export class DataSetNetworkModel {
    area: number;
    price: number;
    latitude: number;
    longitude: number;
    zipCode: string;

    public constructor(fields?: Partial<DataSetNetworkModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
