import { combineReducers } from 'redux';
import surveys from './surveys';
import serverSurveys from './serverSurveys';

const surveyApp = combineReducers({
    surveys,
    serverSurveys,
});

export default surveyApp;
