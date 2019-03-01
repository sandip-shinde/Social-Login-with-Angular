import React, { Component} from 'react'
import { Switch } from 'react-router-dom'
import PrivateRoute from '../../shared/private-route';

import Home from './home';
import Comp1 from './comp1';
import Comp2 from './comp2';
import NoMatch from '../no-match';

export default class Main extends Component {
    render() {
        return (
        <main>
            <Switch>
            <PrivateRoute path='/' exact component={Home}/>
            <PrivateRoute path='/comp1' component={Comp1}/>
            <PrivateRoute path='/comp2' component={Comp2}/>
            <PrivateRoute component={NoMatch}/>
            </Switch>
        </main>
        )
    }
}


