import { Reducer } from 'redux';
import { AppThunkAction } from './';
import { fetch, addTask } from 'domain-task';
import { browserHistory } from 'react-router';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface LoginState {
    isFetching: boolean;
    isAuthenticated: boolean;
    idToken: string;
    credentials: Credentials;
    message: string;
}

//Tengo dudas aqui, esto no forma parte del state, son simples params.
export interface Credentials {
    username: string;
    password: string;
}

export interface LoginResponse {
    idToken: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestLoginAction {
    type: 'LOGIN_REQUEST';
    isFetching: boolean;
    isAuthenticated: boolean;
    credentials: Credentials;
}

interface ReceiveLoginAction {
    type: 'LOGIN_SUCCESS';
    isFetching: boolean;
    isAuthenticated: boolean;
    idToken: string;
}

interface LoginErrorAction {
    type: 'LOGIN_FAILURE';
    isFetching: boolean;
    isAuthenticated: boolean; 
    message: string;
}

interface RequestLogoutAction {
    type: 'LOGOUT_REQUEST';
    isFetching: boolean;
    isAuthenticated: boolean;
}

interface ReceiveLogoutAction {
    type: 'LOGOUT_SUCCESS';
    isFetching: boolean;
    isAuthenticated: boolean;
}

interface LogoutErrorAction {
    type: 'LOGOUT_FAILURE'; 
    isFetching: boolean;
    isAuthenticated: boolean; 
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestLoginAction | ReceiveLoginAction | LoginErrorAction | RequestLogoutAction | ReceiveLogoutAction | LogoutErrorAction;

export const actionCreators = {
    requestLogin: (credentials: Credentials): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({
            type: 'LOGIN_REQUEST',
            isFetching: true,
            isAuthenticated: false,
            credentials: credentials
        });
        const config = {
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            body: `username=${credentials.username}&password=${credentials.password}`
        };
        const loginTask = fetch(`http://localhost:50679/api/jwt`, config).then(response => response.json()).then((data) => {
            if (!data.idToken) {
                dispatch({
                    type: 'LOGIN_FAILURE',
                    isFetching: false,
                    isAuthenticated: false,
                    message: 'Error en el login'
                });
                return Promise.reject(data);
            } else {
                // If login was successful, set the token in local storage
                if (typeof localStorage !== 'undefined') {
                    localStorage.setItem('idToken', data.idToken);
                }
                // Dispatch the success action
                dispatch({
                    type: 'LOGIN_SUCCESS',
                    isFetching: false,
                    isAuthenticated: true,
                    idToken: data.idToken
            });
            }
            return Promise.reject(data);
        });
    },
    requestLogout: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({
            type: 'LOGOUT_REQUEST',
            isFetching: true,
            isAuthenticated: true,
        });
        if (typeof localStorage !== 'undefined') {
            localStorage.removeItem('idTOken');
        }
        dispatch({
            type: 'LOGOUT_SUCCESS',
            isFetching: false,
            isAuthenticated: false
        });
        browserHistory.push('/Login');

    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: LoginState = {
    isFetching: false,
    isAuthenticated: (typeof(localStorage) === 'undefined')
        ? false
        : localStorage.getItem('access_token')
        ? true
        : false,
    idToken: '',
    credentials: null,
    message: ''
};

export const reducer: Reducer<LoginState> = (state: LoginState, action: KnownAction) => {
    switch (action.type) {
    case 'LOGIN_REQUEST':
        return {
            isFetching: true,
            isAuthenticated: false,
            idToken: '',
            credentials: action.credentials,
            message: ''
        };
    case 'LOGIN_SUCCESS':
        return {
            isFetching: false,
            isAuthenticated: true,
            idToken: action.idToken,
            credentials: null,
            message: ''
        };
    case 'LOGIN_FAILURE':
        return {
            isFetching: false,
            isAuthenticated: false,
            idToken: '',
            credentials: null,
            message: action.message
        };
    case 'LOGOUT_SUCCESS':
        return {
            isFetching: true,
            isAuthenticated: false,
            idToken: '',
            credentials: null,
            message: ''
        };
    default:
        // The following line guarantees that every action in the KnownAction union has been covered by a case above
        const exhaustiveCheck: any = action;
    }

    return state || unloadedState;
};