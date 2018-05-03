import axios from 'axios';
import cookie from 'react-cookie';
import {
    AUTH_USER,
    AUTH_ERROR,
    UNAUTH_USER,
    PROTECTED_TEST,
} from './types';
import { API_URL, CLIENT_ROOT_URL } from './index';

export function logoutUser(dispatch) {
    dispatch({ type: UNAUTH_USER });
    cookie.remove('token', { path: '/' });
    window.location.href = `${CLIENT_ROOT_URL}/login`;
}

export function errorHandler(dispatch, error, type) {
    let errorMessage = '';

    if (error.data.error) {
        errorMessage = error.data.error;
    } else if (error.data) {
        errorMessage = error.data;
    } else {
        errorMessage = error;
    }

    if (error.status === 401) {
        dispatch({
            type,
            payload: 'You are not authorized to do this. Please, login and try again.',
        });
        logoutUser();
    } else {
        dispatch({
            type,
            payload: errorMessage,
        });
    }
}

export function loginUser(dispatch, { email, password }) {
    axios.post(`${API_URL}/auth/register`, {
        email, password,
    })
        .then((response) => {
            cookie.save('token', response.data.token, { path: '/' });
            dispatch({ type: AUTH_USER });
            window.location.href = `${CLIENT_ROOT_URL}/dashboard`;
        })
        .catch((error) => {
            errorHandler(dispatch, error.response, AUTH_ERROR);
        });
}

export function registerUser(dispatch, {
    email, firstName, lastName, password,
}) {
    axios.post(`${API_URL}/auth/register`, {
        email, firstName, lastName, password,
    })
        .then((response) => {
            cookie.save('token', response.data.token, { path: '/' });
            dispatch({ type: AUTH_USER });
            window.location.href = `${CLIENT_ROOT_URL}/dashboard`;
        })
        .catch((error) => {
            errorHandler(dispatch, error.response, AUTH_ERROR);
        });
}

export function protectedTest(dispatch) {
    axios.get(`${API_URL}/protected`, {
        headerds: { Authorization: cookie.load('token') },
    })
        .then((response) => {
            dispatch({
                type: PROTECTED_TEST,
                payload: response.data.content,
            });
        })
        .catch((error) => {
            errorHandler(dispatch, error.response, AUTH_ERROR);
        });
}
