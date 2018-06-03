import errorHandler from '../containers/errorHandler';

export class AuthService {
    constructor(http) {
        this.http = http;
    }

    static SignOutUser() {
        localStorage.removeItem('token');
    }

    async SignInUser(email, password, dispatch) {
        try {
            const response = await this.http.post('/register', { email, password });
            localStorage.setItem('token', response.data.token);
        } catch (error) {
            errorHandler(dispatch, error.response);
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
        } catch (error) {
            errorHandler(dispatch, error.response);
        }
    }
}
