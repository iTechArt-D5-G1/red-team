import React from 'react';
import { connect } from 'react-redux';
import { Field, reduxForm } from 'redux-form';
import { loginUser } from './../../containers/loginUser';
import './log-in-page.scss';

const form = reduxForm({
    form: 'login',
});

class LogInPage extends React.Component() {
    componentWillMount() {
        this.props.logoutUser();
    }
    handleFormSubmit(formProps) {
        this.props.loginUser(formProps);
    }

    renderAlert() {
        if (this.props.errorMessage) {
            return (
                <div>
                    <span><strong>Error!</strong> {this.props.errorMessage}</span>
                </div>
            );
        } else {
            return null;
        }
    }

    render() {
        const { handleSubmit } = this.props;

        return (
            <div className='log-in-page'>
                <form onSubmit={handleSubmit(this.handleFormSubmit.bind(this))}>
                    {this.renderAlert()}
                    <p className='log-in-page__header'>Log in</p>
                    <div className='log-in-page__form form'>
                        <Field className='form__fieldEmail' name='email' component='input' placeholder='Email' type='email' />
                    </div>
                    <div>
                        <Field className='form__button' name='password' component='input' placeholder='Password' type='password' />
                    </div>
                    <button className='form__button' type='submit'>Login</button>
                </form>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    errorMessage: state.auth.error,
    message: state.auth.message,
    authenticated: state.auth.authencticated,
});

export default connect(mapStateToProps, { loginUser })(form(LogInPage));
