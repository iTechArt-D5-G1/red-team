import React from 'react';
import { Link } from 'react-router-dom';
import '../LogIn/log-in-page.scss';
import { registrationPage, forgetThePasswordPage } from '../../shared/routePath';

const LogInPage = () => (
    <section className='log-in-page'>
        <p className='log-in-page__header'>Log in</p>
        <form className='log-in-page__form form' >
            <input className='form__fieldEmail' type='email' placeholder='Email' required />
            <br /><br />
            <input className='form__fieldPassword' type='password' placeholder='Password' required />
            <br /><br />
            <input className='form__button' type='submit' value='Submit' />
        </form>
        <div className='log-in-page__optionalBtns optionalBtn'>
            <Link to={registrationPage} className='optionalBtn__SignUp'>Sign Up</Link><pre />
            <Link to={forgetThePasswordPage} className='optionalBtn__forgetPass'>Forgot your password?</Link>
        </div>
    </section>
);
export default LogInPage;
