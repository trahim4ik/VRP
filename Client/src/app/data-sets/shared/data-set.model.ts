export class DataSetModel {
    public id: number;
    public name: string;
    public description: string;
    public insertDate: Date;
    public deleteDate: Date;
    public logo: string;
    public userId: number;
    public fileEntries: any[];

    public constructor(fields?: Partial<DataSetModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
