import { createStore, applyMiddleware, compose, combineReducers, GenericStoreEnhancer } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer } from 'react-router-redux';
import * as Store from './store';
import { loadTranslations, setLocale, syncTranslationWithStore, i18nReducer } from 'react-redux-i18n';

const translationsObject = {
    en: {
        application: {
            title: 'Awesome app with i18n!',
            hello: 'Hello, %{name}!'
        },
        date: {
            long: 'MMMM Do, YYYY'
        },
        export: 'Export %{count} items',
        export_0: 'Nothing to export',
        export_1: 'Export %{count} item',
        two_lines: 'Line 1<br />Line 2'
    },
    nl: {
        application: {
            title: 'Toffe app met i18n!',
            hello: 'Hallo, %{name}!'
        },
        date: {
            long: 'D MMMM YYYY'
        },
        export: 'Exporteer %{count} dingen',
        export_0: 'Niks te exporteren',
        export_1: 'Exporteer %{count} ding',
        two_lines: 'Regel 1<br />Regel 2'
    }
};

export default function configureStore(initialState?: Store.ApplicationState) {
    // Build middleware. These are functions that can process the actions before they reach the store.
    const windowIfDefined = typeof window === 'undefined' ? null : window as any;
    // If devTools is installed, connect to it
    const devToolsExtension = windowIfDefined && windowIfDefined.devToolsExtension as () => GenericStoreEnhancer;
    const createStoreWithMiddleware = compose(
        applyMiddleware(thunk),
        devToolsExtension ? devToolsExtension() : f => f
    )(createStore);

    // Combine all reducers and instantiate the app-wide store instance
    const allReducers = buildRootReducer(Store.reducers);
    const store = createStoreWithMiddleware(allReducers, initialState) as Redux.Store<Store.ApplicationState>;

    // Enable Webpack hot module replacement for reducers
    if (module.hot) {
        module.hot.accept('./store', () => {
            const nextRootReducer = require<typeof Store>('./store');
            store.replaceReducer(buildRootReducer(nextRootReducer.reducers));
        });
    }

    syncTranslationWithStore(store);
    store.dispatch(loadTranslations(translationsObject));
    store.dispatch(setLocale('en'));

    return store;
}

function buildRootReducer(allReducers) {
    return combineReducers<Store.ApplicationState>(Object.assign({}, allReducers, { routing: routerReducer }));
}
