import { Http, Response, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';

type TypeConstructor<T> = (value: any) => T;

export abstract class BaseController {

    protected apiRelativePath = '/api/';

    constructor(
        protected http: Http,
        protected ngRedux: NgRedux<any>
    ) {
    }

    public handleError(error: any) {
        console.error((error._body) ? error._body : error.status ? `${error.status} - ${error.statusText}` : 'Server error');

        this.ngRedux.dispatch({ type: BaseController.prototype.handleError, payload: error });
    }

    protected httpGet<T>(type: string, url: string, ctor: TypeConstructor<T>): Observable<any> {
        const result: Observable<any> = this.http
            .get(this.apiRelativePath + url)
            .map((res: Response) => this.mapType<T>(res, ctor))
            .share();
        result.subscribe(
            data => {
                if (type) {
                    this.ngRedux.dispatch({ type: type, payload: data });
                }
            },
            this.handleError.bind(this)
        );
        return result;
    }

    protected httpPost<T>(type: string, url: string, ctor: TypeConstructor<T>, data: any = null): Observable<any> {
        const result: Observable<any> = this.http
            .post(this.apiRelativePath + url, data)
            .map((res: Response) => this.mapType<T>(res, ctor))
            .share();
        result.subscribe(
            d => {
                if (type) {
                    this.ngRedux.dispatch({ type: type, payload: d });
                }
            },
            this.handleError.bind(this)
        );
        return result;
    }

    protected httpPut<T>(type: string, url: string, ctor: TypeConstructor<T>, data: any = null): Observable<any> {
        const result: Observable<any> = this.http
            .put(this.apiRelativePath + url, data)
            .map((res: Response) => this.mapType<T>(res, ctor))
            .share();
        result.subscribe(
            d => {
                if (type) {
                    this.ngRedux.dispatch({ type: type, payload: d });
                }
            },
            this.handleError.bind(this)
        );
        return result;
    }

    protected httpDelete<T>(type: string, url: string, id: number | number[] | null, ctor: TypeConstructor<T>): Observable<any> {
        const result: Observable<any> = this.http
            .delete(this.apiRelativePath + url + '/' + id)
            .map((res: Response) => this.mapType<T>(res, ctor))
            .share();
        result.subscribe(
            data => {
                if (type) {
                    this.ngRedux.dispatch({ type: type, payload: { id: id, data: data } });
                }
            },
            this.handleError.bind(this)
        );
        return result;
    }

    protected mapType<T>(res: Response, ctor: TypeConstructor<T>): any {
        const val: any = res.status === 204 || !res.json ? null : res.json();
        if (val === null) {
            return val;
        }
        if (Array.isArray(val)) {
            return val.map(x => ctor(x));
        }
        return ctor(val);
    }

    protected downloadFile(type: string, url: string): Observable<any> {
        const result: Observable<any> = this.http
            .get(this.apiRelativePath + url, { responseType: ResponseContentType.Blob })
            .map(res => res.blob())
            .share();
        result.subscribe(
            data => {
                this.ngRedux.dispatch({ type: type, payload: data });
            },
            this.handleError.bind(this)
        );
        return result;
    }

}
