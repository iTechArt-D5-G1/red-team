import { surveyConstants } from './actions';

let nextSurveyId = 0;

function IdInc() {
    nextSurveyId += 1;
    return nextSurveyId;
}

export const addSurvey = text => ({
    type: surveyConstants.ADD_SURVEY,
    id: IdInc(),
    text,
});
