import cookie from 'react-cookie';
import AuthActions from '../actions/index';
import { ServerUrl } from './../../config';

function logoutUser() {
    return (dispatch) => {
        dispatch({ type: AuthActions.UNAUTH_USER });
        cookie.remove('token', { path: '/' });
        window.location.href = `${ServerUrl}/login`;
    };
}

export default logoutUser;
