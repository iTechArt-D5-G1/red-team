import { HttpUtility } from '../utils/http.js';
import { Survey } from '../../models/survey.js';

async function getSurveysFromServerSide() {
    try {
        const axiosInstance = HttpUtility.axiosInstanceCreate();
        const response = await axiosInstance.get('/surveys');
        const { data } = response.data;
        const surveys = data.map(s => Survey(s.id, s.text));
        return surveys;
    } catch (err) {
        throw err;
    }
}

export const surveyService = {
    getSurveys: getSurveysFromServerSide,
};
