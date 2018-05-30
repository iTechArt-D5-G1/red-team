import axios from 'axios';
import cookie from 'react-cookie';
import errorHandler from '../containers/errorHandler';
import { signInUser, signInError } from '../actions/actions';
import { ServerUrl } from './../../config';

const registerUser = (dispatch, {
    email, firstName, lastName, password,
}) => {
    axios.post(`${ServerUrl}/register`, {
        email, firstName, lastName, password,
    })
        .then((response) => {
            cookie.save('token', response.data.token, { path: '/' });
            dispatch(signInUser());
            window.location.href = `${ServerUrl}/hello`;
        })
        .catch((error) => {
            errorHandler(dispatch, error.response, signInError());
        });
};

export default registerUser;
