import React, { Component } from 'react';

import './LoginPage.scss';

// const LoginPage = onSubmit => (
class LoginPage extends Component {
    onSubmit = (e) => {
        e.preventDefault();
    }

    render() {
        return (
            <section>
                <form className='form' onSubmit={this.onSubmit}>
                    <p><input className='form__login-imput' type='text' /></p>
                    <p><input className='form__password-input' type='text' /></p>
                    <button className='form__login-btn'>Login</button>
                </form>
            </section>
        );
    }
}

export default LoginPage;
