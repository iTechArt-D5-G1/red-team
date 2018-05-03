import { combineRedusers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import authReducer from './auth_reducers';

const rootReducer = combineRedusers({
    auth: authReducer,
    form: formReducer,
});

export default rootReducer;
