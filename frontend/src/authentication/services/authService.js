import errorHandler from '../containers/errorHandler';
import { signInUser, signInError, unSignInUser } from '../actions/actions';

export class AuthService {
    constructor(http) {
        this.http = http;
    }

    SignOutUser() {
        return (dispatch) => {
            dispatch(unSignInUser());
            localStorage.removeItem('token');
        };
    }

    SignInUser(email, password) {
        return (dispatch) => {
            this.http.post('/register', {
                email, password,
            })
                .then((response) => {
                    localStorage.setItem('token', response.data.token);
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
                localStorage.setItem('token', response.data.token);
                dispatch(signInUser());
            })
            .catch((error) => {
                errorHandler(dispatch, error.response, signInError());
            });
    }
}
