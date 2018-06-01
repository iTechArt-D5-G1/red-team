import errorHandler from '../containers/errorHandler';
import { signInUser, signInError, unSignInUser } from '../actions/actions';

export class AuthService {
    constructor(http) {
        this.http = http;
    }

    static SignOutUser(dispatch) {
        dispatch(unSignInUser());
        localStorage.removeItem('token');
    }

    async SignInUser(email, password, dispatch) {
        try {
            const response = await this.http.post('/register', { email, password });
            localStorage.setItem('token', response.data.token);
            dispatch(signInUser());
        } catch (error) {
            errorHandler(dispatch, error.response, signInError());
        }
    }

    async RegisterUser(dispatch, {
        email, firstName, lastName, password,
    }) {
        try {
            const response = await this.http.post('/register', {
                email, firstName, lastName, password,
            });
            localStorage.setItem('token', response.data.token);
            dispatch(signInUser());
        } catch (error) {
            errorHandler(dispatch, error.response, signInError());
        }
    }
}
