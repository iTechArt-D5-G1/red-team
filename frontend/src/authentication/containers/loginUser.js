import axios from 'axios';
import cookie from 'react-cookie';
import errorHandler from '../containers/errorHandler';
import AuthActions from '../actions/index';
import ServerUrl from './../../config';

function loginUser(email, password) {
    return (dispatch) => {
        axios.post(`${ServerUrl}/register`, {
            email, password,
        })
            .then((response) => {
                cookie.save('token', response.data.token, { path: '/' });
                dispatch({ type: AuthActions.AUTH_USER });
                window.location.href = `${ServerUrl}/hello`;
            })
            .catch((error) => {
                errorHandler(error.response, AuthActions.AUTH_ERROR);
            });
    };
}

export default loginUser;
