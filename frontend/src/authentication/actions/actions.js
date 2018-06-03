export const SIGN_IN_USER = 'SIGN_IN_USER';
export const signInUser = () => ({
    type: SIGN_IN_USER,
});

export const UNSIGN_IN_USER = 'UNSIGN_IN_USER';
export const unSignInUser = () => ({
    type: UNSIGN_IN_USER,
});

export const SIGN_IN_ERROR = 'SIGN_IN_ERROR';
export const signInError = () => ({
    type: SIGN_IN_ERROR,
});

export const SIGN_IN_SUCCESS = 'SIGN_IN_SUCCESS';
export const signInSuccess = () => ({
    type: SIGN_IN_SUCCESS,
});

export function signInRequest() {
    return async (dispatch, services) => {
        try {
            dispatch(signInUser());
            await services.authServise.SignInUser();
            dispatch(signInSuccess());
        } catch (e) {
            dispatch(signInError());
        }
    };
}
