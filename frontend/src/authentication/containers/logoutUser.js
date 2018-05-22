import cookie from 'react-cookie';
import { connect } from 'react-redux';
import { AuthActions } from '../actions/index';
import { ServerUrl } from './../../config';
import LogOutPage from '../components/logout/LogOutPage.jsx';

const logoutUser = (dispatch) => {
    dispatch({ type: AuthActions.UNAUTH_USER });
    cookie.remove('token', { path: '/' });
    window.location.href = `${ServerUrl}/login`;// redirect to the Login page
};

export default connect(null, { logoutUser })(LogOutPage);

