export class DataSetPredictModel {
    id: number;
    dataSetId: number;
    target: number;
    predict: number;


    public getAbsolute(): number {
        return this.predict - this.target;
    }

    public getRelative(): number {
        return Math.abs(this.predict - this.target) / this.target;
    }

    public getPercentageDifference(): number {
        return Math.abs((this.predict - this.target) / ((this.predict + this.target) / 2)) * 100;
    }

    public constructor(fields?: Partial<DataSetPredictModel>) {

        if (fields) {
            Object.assign(this, fields);
        }
    }
}
