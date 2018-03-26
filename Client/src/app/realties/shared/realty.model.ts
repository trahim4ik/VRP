export class RealtyModel {
    area: number;
    price: number;
    latitude: number;
    longitude: number;
    zipCode: string;

    public constructor(fields?: Partial<RealtyModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
