import React from 'react';

import './forms.scss';

const LoginPageContent = onSubmit => (
    <div className='container' onSubmit={onSubmit}>
        <form className='login_form'>
            <p><input className='login_form__login_imput' type='text' /></p>
            <p><input className='login_form__password_input' type='text' /></p>
            <button >Login</button>
        </form>
    </div>
);


export default LoginPageContent;
