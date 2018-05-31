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
            })
            .catch((error) => {
                errorHandler(dispatch, error.response, signInError());
            });
    }
}
