import signInActions from '../actions/index';

const initialState = {
    errorMessage: null,
    message: null,
    authenticated: false,
};

const signInReducers = (state = initialState, action) => {
    switch (action.type) {
        case signInActions.SIGN_IN_USER:
            return {
                ...state,
                authentication: true,
            };
        case signInActions.UNSIGN_IN_USER:
            return {
                ...state,
                authentication: false,
            };
        case signInActions.SIGN_IN_ERROR:
            return {
                ...state,
                error: action.payload,
            };
        default:
            return state;
    }
};

export default signInReducers;
