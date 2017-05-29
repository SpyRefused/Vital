import * as React from 'react';
import { Link } from 'react-router';
import LocaleSelector from './LocaleSelector';

export interface ITopMenu {   
    navBarStyle: { marginBottom: 0 }
}

export default class TopMenu extends React.Component<ITopMenu, void> {

    renderLanguageSelector() {
        return <LocaleSelector ></LocaleSelector>;
    }

    public render() {

        return <nav className="navbar navbar-fixed-top" role="navigation" style={this.props.navBarStyle}>
                   <div className="navbar-header">
                       <a className="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#">
                           <i className="fa fa-bars">
                           </i>
                       </a>
                       <form role="search" className="navbar-form-custom" action="search_results.html">
                           <div className="form-group">
                               <input type="text" placeholder="Search for something..." className="form-control" name="top-search" id="top-search"/>
                           </div>

                       </form>
                   </div>
                   <ul className="nav navbar-top-links navbar-right">

                       {this.renderLanguageSelector()}

                       <li>
                           <span className="m-r-sm text-muted welcome-message">Bienvenido! </span>
                       </li>


                       <li>
                           <a href="login.html">
                               <i className="fa fa-sign-out"></i> Log out
                           </a>
                       </li>
                   </ul>
               </nav>;
    }
}