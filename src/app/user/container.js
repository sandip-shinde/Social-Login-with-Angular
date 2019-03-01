import React, { Component } from 'react';

import Header from './header'
import Main from './main'

export default class Container extends Component {

  render (){
    
    return (
      <div>
        <Header />
        <Main />
      </div>
    );

  }

}