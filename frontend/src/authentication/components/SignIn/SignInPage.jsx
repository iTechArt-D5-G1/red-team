import React, { Component } from 'react';
import { PropTypes } from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import './sign-in-page.scss';
import { signInRequest } from './../../actions/actions';

class SignInPage extends Component {
    static defaultProps = {
        errorMessage: null,
    }

    static propTypes = {
        errorMessage: PropTypes.string,
        submit: PropTypes.func.isRequired,
    }

    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: '',
            submitted: false,
        };
    }

    handleChange = (e) => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    handleSubmit = (e) => {
        e.preventDefault();

        this.setState({ submitted: true });
        const { username, password } = this.state;
        if (username && password) {
            this.props.submit(username, password);
        }
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
        const { username, password, submitted } = this.state;
        return (
            <div className='sign-in-page'>
                <h2 className='sign-in-page__header'>Sign In</h2>
                <br />
                <form name='sign-in-form' onSubmit={this.handleSubmit}>
                    <div>
                        <input
                            type='email'
                            className={submitted && !username ? 'sign-in-validation' : 'sign-in-form__field'}
                            name='username'
                            placeholder='Email'
                            value={username}
                            onChange={this.handleChange}
                        />
                        {submitted && !username &&
                            <div className='sign-in-validation__help-block'>Username is required</div>
                        }
                    </div>
                    <br />
                    <div>
                        <input
                            type='password'
                            className={submitted && !username ? 'sign-in-validation' : 'sign-in-form__field'}
                            name='password'
                            placeholder='Password'
                            value={password}
                            onChange={this.handleChange}
                        />
                        {submitted && !password &&
                            <div className='sign-in-validation__help-block'>Password is required</div>
                        }
                    </div>
                    <br /><br />
                    <div className='form-group'>
                        <button className='sign-in-form__button'>Sign In</button>
                    </div>
                </form>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    errorMessage: state.error,
});

const mapDispatchToProps = dispatch => ({
    submit: (username, password) => bindActionCreators(signInRequest(username, password), dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(SignInPage);
