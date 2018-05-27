import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import loginUser from './../../containers/loginUser';
import './log-in-page.scss';

class LogInPage extends React.Component {
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
        const { dispatch } = this.props;
        if (username && password) {
            dispatch(loginUser(username, password));
        }
    }

    render() {
        const { username, password, submitted } = this.state;
        return (
            <div className='log-in-page'>
                <h2 className='log-in-page__header'>Login</h2>
                <br />
                <form name='form' onSubmit={this.handleSubmit}>
                    <div>
                        <input
                            type='email'
                            className={submitted && !username ? 'validation__error' : 'form__field'}
                            name='username'
                            placeholder='Email'
                            value={username}
                            onChange={this.handleChange}
                        />
                        {submitted && !username &&
                            <div className='help-block'>Username is required</div>
                        }
                    </div>
                    <br />
                    <div>
                        <input
                            type='password'
                            className={submitted && !username ? 'validation__error' : 'form__field'}
                            name='password'
                            placeholder='Password'
                            value={password}
                            onChange={this.handleChange}
                        />
                        {submitted && !password &&
                            <div className='help-block'>Password is required</div>
                        }
                    </div>
                    <br /><br />
                    <div className='form-group'>
                        <button className='form__button'>Login</button>
                    </div>
                </form>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    loggingIn: state.authencticated,
});

LogInPage.propTypes = {
    dispatch: PropTypes.func.isRequired,
};

export default connect(mapStateToProps)(LogInPage);
