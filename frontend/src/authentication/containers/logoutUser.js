import cookie from 'react-cookie';
import { unSignInUser } from '../actions/actions';
import { ServerUrl } from './../../config';

function logoutUser() {
    return (dispatch) => {
        dispatch(unSignInUser());
        cookie.remove('token', { path: '/' });
        window.location.href = `${ServerUrl}/sign_in`;
    };
}

export default logoutUser;
