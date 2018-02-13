import { ADD_SURVEY } from './actions';

let nextSurveyId = 0;

export const addSurvey = (text) =>({
    type:ADD_SURVEY,
    id: nextSurveyId++,
    text
})