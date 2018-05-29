import axios from 'axios';
import cookie from 'react-cookie';
import errorHandler from '../containers/errorHandler';
import signInActions from '../actions/index';
import { ServerUrl } from './../../config';

function signInUser(email, password) {
    return (dispatch) => {
        axios.post(`${ServerUrl}/register`, {
            email, password,
        })
            .then((response) => {
                cookie.save('token', response.data.token, { path: '/' });
                dispatch({ type: signInActions.SIGN_IN_USER });
                window.location.href = `${ServerUrl}/hello`;
            })
            .catch((error) => {
                errorHandler(error.response, signInActions.SIGN_IN_ERROR);
            });
    };
}

export default signInUser;
