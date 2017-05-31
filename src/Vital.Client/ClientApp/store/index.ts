import * as WeatherForecasts from './WeatherForecasts';
import * as Counter from './Counter';
import * as Locale from './Locale';
import { i18nReducer } from 'react-redux-i18n';
import * as Login from './Login';
import * as Doctor from './Doctor';


// The top-level state object
export interface ApplicationState {
    counter: Counter.CounterState,
    weatherForecasts: WeatherForecasts.WeatherForecastsState,
    locale: Locale.LocaleState,
    login: Login.LoginState,
    doctor: Doctor.DoctorState,
    i18n: any,
    location: any,
    history: any
}

// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    counter: Counter.reducer,
    weatherForecasts: WeatherForecasts.reducer,
    i18n: i18nReducer,
    locale: Locale.reducer,
    login: Login.reducer,
    doctor: Doctor.reducer
};

// This type can be used as a hint on action creators so that its 'dispatch' and 'getState' params are
// correctly typed to match your store.
export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
