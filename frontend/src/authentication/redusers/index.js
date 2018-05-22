import { combineRedusers } from 'redux';
import authReducer from './auth_reducers';

const rootReducer = combineRedusers({
    auth: authReducer,
});

export default rootReducer;
