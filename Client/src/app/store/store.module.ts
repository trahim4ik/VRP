import { NgModule } from '@angular/core';

import { NgReduxModule, NgRedux, DevToolsExtension } from '@angular-redux/store';
import { NgReduxRouterModule, NgReduxRouter } from '@angular-redux/router';
import { provideReduxForms } from '@angular-redux/form';

import { createLogger } from 'redux-logger';

import { IAppState } from './app-state';
import { rootReducer } from './reducers';

@NgModule({
    imports: [
        NgReduxModule,
        NgReduxRouterModule.forRoot()
    ],
    providers: [],
})
export class StoreModule {

    constructor(
        store: NgRedux<IAppState>,
        devTools: DevToolsExtension,
        ngReduxRouter: NgReduxRouter
    ) {

        store.configureStore(
            rootReducer,
            {},
            [createLogger()],
            devTools.isEnabled() ? [devTools.enhancer()] : []
        );

        if (ngReduxRouter) {
            ngReduxRouter.initialize();
        }

        provideReduxForms(store);
    }

}
