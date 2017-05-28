import * as React from 'react';
import { Router, Route, HistoryBase } from 'react-router';
import App  from './components/App';
import Home from './components/Home';
import FetchData from './components/FetchData';
import Counter from './components/Counter';
import NavMenu from './components/NavMenu';
import TopMenu from './components/TopMenu';
import Login from './components/Login';
import DoctorResume from './components/DoctorResume';

export default <Route component={App}>
    <Route path='/' components={{ navMenu: NavMenu, topMenu: TopMenu, layout: Home }} />
    <Route path='/counter' components={{ navMenu: NavMenu, topMenu: TopMenu, layout: Counter }} />
    <Route path='/fetchdata' components={{ navMenu: NavMenu, topMenu: TopMenu, layout: FetchData }}>
        <Route path='(:startDateIndex)' /> { /* Optional route segment that does not affect NavMenu highlighting */ }
    </Route>
                   <Route path='/jander' components={{ navMenu: NavMenu, topMenu: TopMenu, layout: Counter }} />
    <Route path='/login' components={{ layout: Login }} />
                   <Route path='/doctorResume' components={{ navMenu: NavMenu, topMenu: TopMenu, layout: FetchData }}>
                       <Route path='(:idDoctor)' /> { /* Optional route segment that does not affect NavMenu highlighting */}

                   </Route>
</Route>;

// Enable Hot Module Replacement (HMR)
if (module.hot) {
    module.hot.accept();
}
