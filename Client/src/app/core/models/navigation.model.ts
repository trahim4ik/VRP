export class NavigationModel {
    public title: string;
    public icon: string;
    public link: string;

    public constructor(fields?: Partial<NavigationModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
