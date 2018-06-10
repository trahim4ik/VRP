export class UserModel {
    public id: number;
    public title: string;
    public content: string;
    public isError?: boolean;

    public constructor(fields?: Partial<UserModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
