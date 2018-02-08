import React, { Component } from 'react';
import './Styles/forms.scss'

class LoginPageContent extends Component{

    render(){
        return(
            <div className = 'container'>
            <form className = 'login_form'>
                <input type='text' value = 'input text value'/>
            </form>
            </div>
        );
    }
}

export default LoginPageContent;