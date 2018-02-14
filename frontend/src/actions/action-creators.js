import { ADD_SURVEY } from './actions';

let nextSurveyId = 0;

function IdInc() {
    nextSurveyId += 1;
    return nextSurveyId;
}

export const addSurvey = text => ({
    type: ADD_SURVEY,
    id: IdInc(),
    text,
});
