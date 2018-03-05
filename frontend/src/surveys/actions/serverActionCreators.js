import { serverConstants } from './actions';
import { surveyService } from '../services/surveyServer.js';

export const getSurveys = () => ({
    type: serverConstants.GET_SURVEYS,
    surveys: surveyService.getSurveys,
});
