import React, { Component } from 'react';
import { Constants } from '../global/constants';
import { httpService } from '../global/http.service';
import { utilityService } from '../global/utility.service';
import { authService } from '../global/auth.service'

class Login extends Component {

  constructor(){
    super();

    this.state = {
      email : '',
      password : '',
      message : ''
    }

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  }

  validateInput(input){
    return input.email !== '' && input.password !== ''; 
  }

  handleSubmit(event){
    event.preventDefault();

    if(this.validateInput(this.state) === false){
      return;
    }

    const data = JSON.stringify({
        email: this.state.email,
        password: this.state.password
    });

    httpService.post(Constants.apiUrl.login, { body:data })
    .then( (response) => {
       if(response.code === 200){
         authService.login(response);         
         utilityService.redirect('/');
         //this.props.history.push('/');
       }
       else{
          this.setState({ message : 'Login failed !!'});
       }
    });

  }


  render() {

    return (
      
        <div className="container">
          <div className="login-container">
              <h3>Login</h3>
              <div>
                <form onSubmit={this.handleSubmit}>
                  <div className="form-group">
                    <input className="form-control" type="text" name="email" value={this.state.email} onChange={this.handleInputChange}/>
                  </div>
                  <div className="form-group">
                    <input className="form-control" type="password" name="password" value={this.state.password} onChange={this.handleInputChange}/>
                  </div>                        
                    <button type='button' className="btn btn-primary btn-block" onClick={this.handleSubmit}>Login</button>  
                </form>
              </div>                
          </div>
        </div>    
    );
  }
}

export default Login