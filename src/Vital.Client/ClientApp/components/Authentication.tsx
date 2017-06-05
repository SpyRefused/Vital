import * as React from 'react'
import * as LoginState from '../store/Login'
import {ApplicationState} from "ClientApp/store/index";
import { connect } from 'react-redux';

type AuthenticatedComponentProps = LoginState.LoginState & 
    { isAuthenticated, location, history}

export function requireAuthentication(Component) {

    class AuthenticatedComponent extends React.Component<AuthenticatedComponentProps, void> {

        shouldComponentUpdate(nextProps) {
            return true;
        }

        componentWillMount() {
            this.checkAuth();
        }

        componentWillReceiveProps(nextProps) {  
            this.checkAuth();   
        }   
            
        private checkAuth() {
            if (!this.props.isAuthenticated) {
                let redirectAfterLogin = this.props.location.pathname;
                this.props.history.push('/Login');
            } else if (this.props.isAuthenticated && this.props.location.pathname.toLowerCase() === 'login') {
                let redirectAfterLogin = this.props.location.pathname;
                this.props.history.push('');
            }
        }

        render() {
            return this.props.isAuthenticated === true
                ? <Component {...this.props}/>
                : null;
        }
    }

    return connect(
        (state: ApplicationState) =>
        state.login,
 // Selects which state properties are merged into the component's props
        LoginState.actionCreators
    )(AuthenticatedComponent);
}