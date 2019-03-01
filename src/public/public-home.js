import React, { Component } from 'react';
import Login from './login';
import {
  Route,
  Switch
} from 'react-router-dom';


export default class PublicHome extends Component {

  render (){
    
    return (
        <main>
            <Switch>
              <Route path='/' component={Login}/>
            </Switch>
        </main>
    )

  }

}
