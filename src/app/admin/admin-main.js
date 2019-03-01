import React, { Component} from 'react'
import { Switch } from 'react-router-dom'
import PrivateRoute from '../../shared/private-route';

import AdminHome from './admin-home';
import AdminComp1 from './admin-comp1';
import AdminComp2 from './admin-comp2';
import NoMatch from '../no-match';

export default class Main extends Component {
    render() {
        return (
        <main>
            <Switch>
            <PrivateRoute path='/' exact component={AdminHome}/>
            <PrivateRoute path='/admin-comp1' component={AdminComp1}/>
            <PrivateRoute path='/admin-comp2' component={AdminComp2}/>
            <PrivateRoute component={NoMatch}/>
            </Switch>
        </main>
        )
    }
}


