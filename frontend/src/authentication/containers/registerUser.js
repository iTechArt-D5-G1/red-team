import axios from 'axios';
import cookie from 'react-cookie';
import errorHandler from '../containers/errorHandler';
import signInActions from '../actions/index';
import { ServerUrl } from './../../config';

const registerUser = (dispatch, {
    email, firstName, lastName, password,
}) => {
    axios.post(`${ServerUrl}/register`, {
        email, firstName, lastName, password,
    })
        .then((response) => {
            cookie.save('token', response.data.token, { path: '/' });
            dispatch({ type: signInActions.SIGN_IN_USER });
            window.location.href = `${ServerUrl}/hello`;
        })
        .catch((error) => {
            errorHandler(dispatch, error.response, signInActions.SIGN_IN_ERROR);
        });
};

export default registerUser;
