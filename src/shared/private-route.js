import React from 'react'
import {
  Route,
  Redirect
} from 'react-router-dom';
import { authService } from '../global/auth.service';

const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route {...rest} render={props => (
    authService.isUserLoggedIn() ? (
      <Component {...props}/>
    ) : (
      <Redirect push to={{
        pathname: '/login',
        state: { from: props.location }
      }}/>
    )
  )}/>
)

export default PrivateRoute;