export class SearchModel {
    public query: string;
    public sort: string;
    public direction: string;
    public limit: number;
    public skip: number;
    public pageIndex: number;

    public constructor(fields?: Partial<SearchModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
