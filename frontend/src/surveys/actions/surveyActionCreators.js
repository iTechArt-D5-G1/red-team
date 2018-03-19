import { surveyConstants } from './actions';
import { surveyService } from '../services/survey.js';
import { Survey } from '../../models/survey';

let nextSurveyId = 0;

function IdInc() {
    nextSurveyId += 1;
    return nextSurveyId;
}

export const requestSuccess = requestedData => ({
    type: surveyConstants.SURVEYS_REQUEST_SUCCESS,
    surveys: requestedData,
});
export const requestError = () => ({
    type: surveyConstants.SURVEYS_REQUEST_ERROR,
});

export const requestInit = () => ({
    type: surveyConstants.SURVEYS_REQUEST_INIT,
});

export function surveysRequest() {
    return (dispatch) => {
        requestInit();
        surveyService.getSurveys()
            .then((requestedData) => {
                dispatch(requestSuccess(requestedData));
            })
            .catch(() => {
                dispatch(requestError());
            });
    };
}

export function addSurvey(text) {
    return (dispatch) => {
        requestInit();
        surveyService.addSurvey(new Survey(IdInc(), text))
            .then((requestedData) => {
                dispatch(requestSuccess(requestedData));
            })
            .catch(() => {
                dispatch(requestError());
            });
    };
}
