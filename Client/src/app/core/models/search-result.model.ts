export class SearchResultModel<T> {
    public total: number;
    public items: T[];

    public constructor(fields?: Partial<SearchResultModel<T>>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
