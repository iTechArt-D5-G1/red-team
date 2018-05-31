import cookie from 'react-cookie';
import axios from 'axios';
import errorHandler from '../containers/errorHandler';
import { ServerUrl } from './../../config';
import { signInUser, signInError, unSignInUser } from '../actions/actions';

export class AuthService {
    SignOutUser() {
        return (dispatch) => {
            dispatch(unSignInUser());
            cookie.remove('token', { path: '/' });
            this.window.location.href = `${ServerUrl}/sign_in`;
        };
    }

    SignInUser(email, password) {
        return (dispatch) => {
            axios.post(`${ServerUrl}/register`, {
                email, password,
            })
                .then((response) => {
                    cookie.save('token', response.data.token, { path: '/' });
                    dispatch(signInUser());
                    this.window.location.href = `${ServerUrl}/hello`;
                })
                .catch((error) => {
                    errorHandler(error.response, signInError());
                });
        };
    }

    RegisterUser(dispatch, {
        email, firstName, lastName, password,
    }) {
        axios.post(`${ServerUrl}/register`, {
            email, firstName, lastName, password,
        })
            .then((response) => {
                cookie.save('token', response.data.token, { path: '/' });
                dispatch(signInUser());
                this.window.location.href = `${ServerUrl}/hello`;
            })
            .catch((error) => {
                errorHandler(dispatch, error.response, signInError());
            });
    }
}
