import * as React from 'react';
import  * as LocaleState from "../store/Locale";
import {ApplicationState} from "../store";
import { connect } from 'react-redux';
import { Link, History } from 'react-router';

type LocaleProps =
    LocaleState.LocaleState // ... state we've requested from the Redux store
    & typeof LocaleState.actionCreators // ... plus action creators we've requested

class LocaleSelector extends React.Component<LocaleProps, void> {

    public render() {

        return <li>
            <span className="m-r-sm text-muted welcome-message"><a onClick={() => { this.props.requestSetLocale('es'); history.pushState(this.state,'/'); }}>{"Castellano"}</a></span>
            <span className="m-r-sm text-muted welcome-message"><a onClick={() => { this.props.requestSetLocale('ca'); history.pushState(this.state, '/');}}>{"Català"}</a></span>
               </li>;

    }
}

export default connect(
    (state: ApplicationState) =>
    state.locale, // Selects which state properties are merged into the component's props
    LocaleState.actionCreators // Selects which action creators are merged into the component's props  
)(LocaleSelector);

