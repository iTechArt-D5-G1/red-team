import { logoutUser } from './logoutUser';

const errorHandler = (dispatch, error, type) => {
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
        logoutUser();// fix it
    } else {
        dispatch({
            type,
            payload: errorMessage,
        });
    }
};

export default errorHandler;
