import * as React from 'react';
import  * as LocaleState from "../store/Locale";
import {ApplicationState} from "../store";
import { connect } from 'react-redux';
import { Link } from 'react-router';

type LocaleProps =
    LocaleState.LocaleState // ... state we've requested from the Redux store
    & typeof LocaleState.actionCreators // ... plus action creators we've requested

class LocaleSelector extends React.Component<LocaleProps, void> {
    public render() {
        return <li className="dropdown">
                   <a className="count-info dropdown-toggle" href="#" aria-expanded="true">
                       <span className="text-muted text-xs block">Idioma<b className="caret"></b></span></a>
                   <ul className="animated fadeInRight m-t-xs ng-scope dropdown-menu">
                       <li><a onClick={ () => { this.props.requestSetLocale('en'); } }>English</a></li>
                       <li><a onClick={ () => { this.props.requestSetLocale('nl'); } }>Needetlan</a></li>
                   </ul>
               </li>;
    }
}

export default connect(
    (state: ApplicationState) =>
    state.locale, // Selects which state properties are merged into the component's props
    LocaleState.actionCreators // Selects which action creators are merged into the component's props  
)(LocaleSelector);

