import AuthActions from '../actions/index';

const initialState = {
    errorMessage: null,
    message: null,
    authenticated: false,
};

const authenticationHandler = (state = initialState, action) => {
    switch (action.type) {
        case AuthActions.AUTH_USER:
            return {
                ...state,
                authentication: true,
            };
        case AuthActions.UNAUTH_USER:
            return {
                ...state,
                authentication: false,
            };
        case AuthActions.AUTH_ERROR:
            return {
                ...state,
                error: action.payload,
            };
        default:
            return state;
    }
};

export default authenticationHandler;
