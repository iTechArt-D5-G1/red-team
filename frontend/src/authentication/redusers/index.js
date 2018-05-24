import { combineRedusers } from 'redux';
import authReducer from './auth_reducers';

const rootReducer = combineRedusers({
    authReducer,
});

export default rootReducer;
