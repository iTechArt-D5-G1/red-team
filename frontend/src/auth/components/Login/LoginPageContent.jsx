import React from 'react';

import './forms.scss';

const LoginPageContent = onSubmit => (
    <div className='container' onSubmit={onSubmit}>
        <form className='form'>
            <p><input className='form__login_imput' type='text' /></p>
            <p><input className='form__password_input' type='text' /></p>
            <button className='form__login_btn'>Login</button>
        </form>
    </div>
);


export default LoginPageContent;
