import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as LoginStore from '../store/Login';
    
type LoginProps = LoginStore.LoginState & typeof LoginStore.actionCreators;

class Login extends React.Component<LoginProps, void> {
    
    private username: HTMLInputElement;
    private password: HTMLInputElement;

     private handleClick(event) {
        let credentials: LoginStore.Credentials = {
            username: this.username.value,
            password: this.password.value
        }
         this.props.requestLogin(credentials);
     };

    public render() {
        return <div className="loginColumns animated fadeInDown">
                   <div className="row">
                       <div className="col-md-6">
                           <h2 className="font-bold">Bienvenidos a Vital Seguro</h2>
                            <hr/>
                           <h2>Área de Entes Médicos</h2>
                           <p>Introducir los siguientes datos:</p>
                           <p><small>- NIF o código de Ente médico </small>
                           </p>
                           <p><small>- Contraseña (6 a 10 caracteres)</small>
                           </p>
                       </div>
                       <div className="col-md-6">
                           <div className="ibox-content">
                               <div className="m-t" role="form">
                                   <div className="form-group">
                                       <input type="text" ref={(c) => { this.username = c } } className="form-control" placeholder="NIF o código de Ente médico"/>
                                   </div>
                                   <div className="form-group">
                                       <input type="password" ref={(c) => { this.password = c } } className="form-control" placeholder="Contraseña"/>
                                   </div>
                                   <button  onClick={(event) => this.handleClick(event)}  className="btn btn-primary block full-width m-b">Login</button>

                                   <a href="#">
                                       <small>Si ha olvidado la contraseña pulse aquí</small>
                                   </a>
                                   <hr/>
                                   
                                   <p className="text-muted text-center">
                                       <small>Antes de Acceder por primera vez al Área de Entes Médicos, debe Registrarse</small>
                                   </p>
                                   <a className="btn btn-sm btn-white btn-block" href="register.html">Registrarse</a>
                               </div>
                               <p className="m-t">
                                   <small>{ new Date().getDate() +
                                       "/" +
                                       new Date().getMonth() +
                                       "/" +
                                       new Date().getFullYear()}</small>
                               </p>
                           </div>
                       </div>
                   </div>
                   <hr/>
                   <div className="row">
                       <div className="col-md-6">
                           Vital Seguro S.A.
                       </div>
                       <div className="col-md-6 text-right">
                           <small>© {new Date().getFullYear()}</small>
                       </div>
                   </div>
               </div>;
    }
}

export default connect(
    (state: ApplicationState) => state.login,
    LoginStore.actionCreators
)(Login);

