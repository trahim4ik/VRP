import { SearchResultModel, UserModel } from '../../core/models/';

export class UsersResultModel extends SearchResultModel<UserModel> {

    public constructor(fields?: Partial<UsersResultModel>) {

        super(fields);

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
