export class FileEntryModel {
    public id: number;
    public insertDate: Date;
    public deleteDate: Date;
    public fileName: string;
    public description: string;
    public contentType: string;
    public name: string;
    public extension: string;

    public constructor(fields?: Partial<FileEntryModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
