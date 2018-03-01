import { combineReducers } from 'redux';
import surveys from './surveys';
import server from './server';

const surveyApp = combineReducers({
    surveys,
    server,
});

export default surveyApp;
