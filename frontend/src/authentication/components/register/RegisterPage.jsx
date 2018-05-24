import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { Field, reduxForm } from 'redux-form';
import { registerUser } from './../../containers/registerUser.js';

const form = reduxForm({
    form: 'register',
});

class RegisterPage extends React.Component {
    handleFormSubmit(formProps) {
        this.props.registerUser(formProps);
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
            <form onSubmit={handleSubmit(this.handleFormSubmit.bind(this))}>
                {this.renderAlert()}
                <div>
                    <div>
                        <Field name='firstName' component='input' type='text' />
                    </div>
                    <div>
                        <Field name='lastName' component='input' type='text' />
                    </div>
                </div>
                <div>
                    <div>
                        <Field name='email' component='input' placeholder='Email' type='text' />
                    </div>
                </div>
                <div>
                    <div>
                        <Field name='password' component='input' placeholder='Password' type='password' />
                    </div>
                </div>
                <button type='submit'>Register</button>
            </form>
        );
    }
}

function mapStateToProps(state) {
    return {
        errorMessage: state.auth.error,
        message: state.auth.message,
        authenticated: state.auth.authenticated,
    };
}

RegisterPage.propTypes = {
    registerUser: PropTypes.func.isRequired,
    errorMessage: PropTypes.func.isRequired,
    handleSubmit: PropTypes.func.isRequired,
};

export default connect(mapStateToProps, { registerUser })(form(RegisterPage));
