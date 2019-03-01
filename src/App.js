import React, { Component } from 'react';

import { Constants } from './global/constants';
import { httpService } from './global/http.service';
import { authService } from './global/auth.service';

import PublicHome from './public/public-home';
import Container from './app/user/container';
import AdminContainer from './app/admin/admin-container';

export default class App extends Component {

    constructor(){
      super();
      this.state = {
        isDataAvailable : false,
        isAdminUser : false
      };
    }

    componentDidMount(){
      if(authService.isUserLoggedIn()) {
        this.getUserData(authService.getUserId());
      }
    }

    getUserData(userId){
      httpService.get(Constants.apiUrl.getUserData, { params: { id : userId} })
      .then( (response) => {
        if(response.code === 200)
        {
          this.setState({
            isDataAvailable : true,
            isAdminUser : response.isAdmin
          });
        }
      });
    }

    render() {
      const isUserLoggedIn = authService.isUserLoggedIn();
      const isAdminUser = isUserLoggedIn && this.state.isDataAvailable && this.state.isAdminUser;
      const isRegularUser = isUserLoggedIn && this.state.isDataAvailable && this.state.isAdminUser === false;

      return (
        <div>

        { isUserLoggedIn === false ? <PublicHome/> : '' }
        
        { isAdminUser ? <AdminContainer /> : '' }

        { isRegularUser ? <Container /> : '' }
        
        </div>
      )
    }
}
