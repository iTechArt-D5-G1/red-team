import {
    SIGN_IN_USER,
    UNSIGN_IN_USER,
    SIGN_IN_ERROR,
} from '../actions/actions';

const initialState = {
    errorMessage: null,
    message: null,
    authenticated: false,
};

const signInReducers = (state = initialState, action) => {
    switch (action.type) {
        case SIGN_IN_USER:
            return {
                ...state,
                authentication: true,
            };
        case UNSIGN_IN_USER:
            return {
                ...state,
                authentication: false,
            };
        case SIGN_IN_ERROR:
            return {
                ...state,
                error: action.payload,
            };
        default:
            return state;
    }
};

export default signInReducers;
