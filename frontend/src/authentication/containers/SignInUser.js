import axios from 'axios';
import cookie from 'react-cookie';
import errorHandler from '../containers/errorHandler';
import { signInUser, signInError } from '../actions/actions';
import { ServerUrl } from './../../config';

function SignInUser(email, password) {
    return (dispatch) => {
        axios.post(`${ServerUrl}/register`, {
            email, password,
        })
            .then((response) => {
                cookie.save('token', response.data.token, { path: '/' });
                dispatch(signInUser());
                window.location.href = `${ServerUrl}/hello`;
            })
            .catch((error) => {
                errorHandler(error.response, signInError());
            });
    };
}

export default SignInUser;
