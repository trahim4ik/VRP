import { NgModule } from '@angular/core';
import { NgReduxModule, NgRedux, DevToolsExtension } from '@angular-redux/store';

import { createLogger } from 'redux-logger';

import { IAppState } from './app-state';
import { rootReducer } from './reducers';

@NgModule({
    imports: [
        NgReduxModule
    ],
    providers: [],
})
export class StoreModule {

    constructor(
        store: NgRedux<IAppState>,
        devTools: DevToolsExtension
    ) {

        store.configureStore(
            rootReducer,
            {},
            [createLogger()],
            devTools.isEnabled() ? [devTools.enhancer()] : []
        );
    }

}
