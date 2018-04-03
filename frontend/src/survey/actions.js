import { surveyService } from './services/survey';

export const SURVEYS_REQUEST_INIT = 'SURVEYS_REQUEST_INIT';
export const SURVEYS_REQUEST_SUCCESS = 'SURVEYS_REQUEST_SUCCESS';
export const SURVEYS_REQUEST_ERROR = 'SURVEYS_REQUEST_ERROR';
export const ADD_SURVEY = 'ADD_SURVEY';

export const surveyRequestSuccess = requestedData => ({
    type: SURVEYS_REQUEST_SUCCESS,
    surveys: requestedData,
});
export const surveyRequestError = () => ({
    type: SURVEYS_REQUEST_ERROR,
});

export const surveyRequestInit = () => ({
    type: SURVEYS_REQUEST_INIT,
});

export function surveysRequest() {
    return async (dispatch) => {
        try {
            dispatch(surveyRequestInit());
            const surveys = await surveyService.getSurveys();
            dispatch(surveyRequestSuccess(surveys));
        } catch (err) {
            dispatch(surveyRequestError());
        }
    };
}

