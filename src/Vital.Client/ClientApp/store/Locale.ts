import { Reducer } from 'redux';
import { AppThunkAction } from './';
import { loadTranslations, setLocale, syncTranslationWithStore } from 'react-redux-i18n';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface LocaleState {
    locale: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestSetLocaleAction {
    type: 'REQUEST_SET_LOCALE',
    locale: string;
}


// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestSetLocaleAction | any;

export const actionCreators = {
    requestSetLocale: (locale: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch(setLocale(locale));
        dispatch({ type: 'REQUEST_SET_LOCALE', locale: locale });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: LocaleState = { locale: '' };

export const reducer: Reducer<LocaleState> = (state: LocaleState, action: KnownAction) => {
    switch (action.type) {
    case 'REQUEST_SET_LOCALE':
        return {
            locale: action.locale
        };
    default:
        // The following line guarantees that every action in the KnownAction union has been covered by a case above
        const exhaustiveCheck: any = action;
    }
    return state || unloadedState;
};
