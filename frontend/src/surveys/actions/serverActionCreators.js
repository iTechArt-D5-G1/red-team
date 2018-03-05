import { HttpUtility } from '../utils/http.js';
import { serverConstants } from './actions';

function fetchSurveysFromServerSide() {
    const data = HttpUtility.getSurveys();
    return data;
}

export const getSurveys = () => ({
    type: serverConstants.GET_SURVEYS,
    surveys: fetchSurveysFromServerSide(),
});
