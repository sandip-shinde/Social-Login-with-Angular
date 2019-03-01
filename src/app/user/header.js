import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../../global/auth.service';
import { utilityService } from '../../global/utility.service';

export default class Header extends Component {

    constructor(){
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        authService.logOut();
        utilityService.redirect('/login');
    }

    render() {

        const LogoutButton = () => (
          <button className="btn btn-primary btn-md button-align" type='button' onClick={this.handleSubmit}>Logout</button>  
        )

        return (
        <header>
            <nav>
            <ul className='newtabs'>
                <li><Link to='/'>Home</Link></li>
                <li><Link to='/comp1'>Comp1</Link></li>
                <li><Link to='/comp2'>Comp2</Link></li>
                 <LogoutButton />
            </ul>
           
            </nav>
        </header>
        )
    }
}
