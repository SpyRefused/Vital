import * as React from 'react';
import { Link } from 'react-router';

const vitalLogo: any = require('./../img/profile_small.jpg');

export interface INavMenuProps {
    languageSelector: React.ReactElement<any>;
}

export default class NavMenu extends React.Component<INavMenuProps, void> {
    logo: string = vitalLogo;
    public render() {
        return <nav className="navbar-default navbar-static-side" role="navigation">
                   <div className="sidebar-collapse">
                       <ul className="nav metismenu" id="side-menu">
                           <li className="nav-header">
                               <div className="dropdown profile-element"> <span>
                                       <img alt="image" className="img-circle" src={vitalLogo}/>
                                   </span>
                                   <a data-toggle="dropdown" className="dropdown-toggle" href="#">
                                       <span className="clear"> <span className="block m-t-xs"> <strong className="font-bold">David Williams</strong>
                                       </span> <span className="text-muted text-xs block">Metge, Client <b className="caret"></b></span> </span> </a>
                                   <ul className="dropdown-menu animated fadeInRight m-t-xs">
                                       <li><a href="profile.html">Perfil</a></li>
                                       <li><a href="contacts.html">Contactes</a></li>
                                       <li><a href="mailbox.html">Email</a></li>
                                       <li className="divider"></li>
                                       <li><a href="login.html">Sortir</a></li>
                                   </ul>
                               </div>
                               <div className="logo-element">
                                   VITAL
                               </div>
                           </li>

                       </ul>
                   </div>
                   <div className='main-nav'>
                       <div className='navbar navbar-inverse'>
                           <div className='navbar-header'>
                               <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                                   <span className='sr-only'>Toggle navigation</span>
                                   <span className='icon-bar'></span>
                                   <span className='icon-bar'></span>
                                   <span className='icon-bar'></span>
                               </button>
                               <Link className='navbar-brand' to={'/'}>Vital.Client</Link>
                           </div>
                           <div className='clearfix'></div>
                           <div className='navbar-collapse collapse'>
                               <ul className='nav navbar-nav'>
                                   <li>
                                       <Link to={'/doctor'} activeClassName='active'>
                                           <span className='glyphicon glyphicon-home'></span> Home
                                       </Link>
                                   </li>

                               </ul>
                           </div>
                       </div>
                   </div >
               </nav>;


    }
}
