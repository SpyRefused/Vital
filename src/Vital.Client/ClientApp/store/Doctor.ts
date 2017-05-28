import { fetch, addTask } from 'domain-task';
import { Reducer } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface DoctorState {
    isLoading: boolean;
    idDoctor: number;
    doctorResume: DoctorResume[];
}

export interface DoctorResume {
    id: string;
    idDoctor: number;
    year: number;
    month: number;
    settlementCode: string;
    receipt: string;
    serviceDetails: string;
    observations: string;
    insureds: string;
    registersUnregisters: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestDoctorResumeAction {
    type: 'REQUEST_DOCTOR_RESUME',
    idDoctor: number;
}

interface ReceiveDoctorResumeAction {
    type: 'RECEIVE_DOCTOR_RESUME',
    idDoctor: number;
    doctorResume: DoctorResume[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type DoctorActions = RequestDoctorResumeAction | ReceiveDoctorResumeAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestDoctorResume: (idDoctor: number): AppThunkAction<DoctorActions> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (idDoctor !== getState().doctor.idDoctor) {
            let fetchTask = fetch(`/api/Doctor/GetDoctorResume?idDoctor=${ idDoctor }`)
                .then(response => response.json() as Promise<DoctorResume[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_DOCTOR_RESUME', idDoctor: idDoctor, doctorResume: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_DOCTOR_RESUME', idDoctor: idDoctor });            
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: DoctorState = { idDoctor: null, doctorResume: [], isLoading: false };

export const reducer: Reducer<DoctorState> = (state: DoctorState, action: DoctorActions) => {
    switch (action.type) {
        case 'REQUEST_DOCTOR_RESUME':
            return {
                idDoctor: action.idDoctor,
                doctorResume: state.doctorResume,
                isLoading: true
            };
        case 'RECEIVE_DOCTOR_RESUME':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.idDoctor === state.idDoctor) {
                return {
                    idDoctor: action.idDoctor,
                    doctorResume: state.doctorResume,
                    isLoading: false
                };
            }
            break;
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};