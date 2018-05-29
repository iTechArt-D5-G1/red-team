import cookie from 'react-cookie';
import signInActions from '../actions/index';
import { ServerUrl } from './../../config';

function logoutUser() {
    return (dispatch) => {
        dispatch({ type: signInActions.UNSIGN_IN_USER });
        cookie.remove('token', { path: '/' });
        window.location.href = `${ServerUrl}/sign_in`;
    };
}

export default logoutUser;
