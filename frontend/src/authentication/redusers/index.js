import { combineRedusers } from 'redux';
import signInReducers from './sign_in_reducers';

const rootReducer = combineRedusers({
    signInReducers,
});

export default rootReducer;
