import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { Field, reduxForm } from 'redux-form';
import loginUser from './../../containers/loginUser';
import './log-in-page.scss';

const form = reduxForm({
    form: 'login',
});

class LogInPage extends React.Component {
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
                        <Field className='form__fieldEmail' name='email' placeholder='Email' type='email' component='input' required />
                    </div>
                    <br />
                    <div>
                        <Field className='form__button' name='password' placeholder='Password' type='password' component='input' required />
                    </div>
                    <br /><br />
                    <button className='form__button' type='submit'>Login</button>
                </form>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    errorMessage: state.error,
    message: state.message,
    authenticated: state.authencticated,
});

LogInPage.propTypes = {
    errorMessage: PropTypes.string.isRequired,
    handleSubmit: PropTypes.func.isRequired,
    loginUser: PropTypes.func.isRequired,
};

export default connect(mapStateToProps, { loginUser })(form(LogInPage));
