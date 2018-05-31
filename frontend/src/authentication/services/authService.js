import cookie from 'react-cookie';
import errorHandler from '../containers/errorHandler';
import { signInUser, signInError, unSignInUser } from '../actions/actions';

export class AuthService {
    constructor(http) {
        this.http = http;
    }

    SignOutUser() {
        return (dispatch) => {
            dispatch(unSignInUser());
            cookie.remove('token', { path: '/' });
        };
    }

    SignInUser(email, password) {
        return (dispatch) => {
            this.http.post('/register', {
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
        this.http.post('/register', {
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
