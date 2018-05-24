import cookie from 'react-cookie';
import { AuthActions } from '../actions/index';
import { ServerUrl } from './../../config';

const logoutUser = (dispatch) => {
    dispatch({ type: AuthActions.UNAUTH_USER });
    cookie.remove('token', { path: '/' });
    window.location.href = `${ServerUrl}/login`;
};

export default logoutUser;
