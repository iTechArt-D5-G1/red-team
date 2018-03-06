import React from 'react';

import './forms.scss';
import './LoginPage.scss';

const LoginPage = onSubmit => (
    <section className='container' onSubmit={onSubmit}>
        <form className='form'>
            <p><input className='form__login-imput' type='text' /></p>
            <p><input className='form__password-input' type='text' /></p>
            <button className='form__login-btn'>Login</button>
        </form>
    </section>
);

export default LoginPage;
