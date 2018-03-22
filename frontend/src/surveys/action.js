import { surveyService } from './services/survey.js';
import { Survey } from '../models/survey';

export const SURVEYS_REQUEST_INIT = 'SURVEYS_REQUEST_INIT';
export const SURVEYS_REQUEST_SUCCESS = 'SURVEYS_REQUEST_SUCCESS';
export const SURVEYS_REQUEST_ERROR = 'SURVEYS_REQUEST_ERROR';
export const ADD_SURVEY = 'ADD_SURVEY';

let nextSurveyId = 0;

function IdInc() {
    nextSurveyId += 1;
    return nextSurveyId;
}

export const requestSuccess = requestedData => ({
    type: SURVEYS_REQUEST_SUCCESS,
    surveys: requestedData,
});
export const requestError = () => ({
    type: SURVEYS_REQUEST_ERROR,
});

export const requestInit = () => ({
    type: SURVEYS_REQUEST_INIT,
});

export function surveysRequest() {
    return async (dispatch) => {
        try {
            const surveys = await surveyService.getSurveys();
            dispatch(requestSuccess(surveys));
        } catch (err) {
            dispatch(requestError());
        }
    };
}

export function addSurvey(text) {
    return async (dispatch) => {
        try {
            const survey = await surveyService.addSurvey(new Survey(IdInc(), text));
            dispatch(requestSuccess(survey));
        } catch (err) {
            dispatch(requestError());
        }
    };
}
