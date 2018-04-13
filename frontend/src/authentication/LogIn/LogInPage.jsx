import React from 'react';
import { Link } from 'react-router-dom';
import './log-in-page.scss';
import { registrationPage, forggotThePasswordPage } from '../../../shared/routePath';

const SignedUpPage = () => (
    <section className='log-in-page'>
        <p className='log-in-page__header'>Log in</p>
        <form className='log-in-page__form form'>
            <input className='form__field' type='text' name='Login' placeholder='Login' />
            <br /><br />
            <input className='form__field' type='password' name='Password' placeholder='Password' />
            <br /><br />
        </form>
        <ul>
            <li><Link to={registrationPage} className='menu__link'>Sign Up</Link>qwe</li>
            <li><Link to={forggotThePasswordPage} className='menu__link'>Sign Up</Link>qwe</li>
        </ul>
        <div className='form__logInBtn button'>
            <button className='button__field'>Log in</button>
        </div>
    </section>
);
export default SignedUpPage;
