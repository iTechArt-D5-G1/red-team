import { combineReducers } from 'redux';
import surveys from './surveys';

const surveyApp = combineReducers({
    surveys,
});

export default surveyApp;
