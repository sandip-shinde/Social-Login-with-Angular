import React, { Component } from 'react';

import AdminHeader from './admin-header'
import AdminMain from './admin-main'

export default class AdminContainer extends Component {

  render (){
    
    return (
      <div>
        <AdminHeader />
        <AdminMain />
      </div>
    );

  }

}