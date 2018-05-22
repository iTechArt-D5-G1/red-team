import axios from 'axios';
import cookie from 'react-cookie';
import { errorHandler } from '../containers/errorHandler';
import { AuthActions } from '../actions/index';
import { ServerUrl } from './../../config';

const loginUser = (dispatch, { email, password }) => {
    axios.post(`${ServerUrl}/auth/register`, {
        email, password,
    })
        .then((response) => {
            cookie.save('token', response.data.token, { path: '/' });
            dispatch({ type: AuthActions.AUTH_USER });
            window.location.href = `${ServerUrl}/dashboard`;// redirection to the helloWorld page
        })
        .catch((error) => {
            errorHandler(dispatch, error.response, AuthActions.AUTH_ERROR);
        });
};

export default loginUser;
