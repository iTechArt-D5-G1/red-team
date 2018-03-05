import { HttpUtility } from '../utils/http.js';
import { Survey } from '../../models/survey.js';

async function getSurveysFromServerSide() {
    try {
        const axiosInstance = HttpUtility.axiosInstanceCreate();
        const response = await axiosInstance.get('/surveys');
        const { data } = response.data;
        const surveys = data.map(s => Survey(s.id, s.text));
        console.log(`console log: data log: ${data}`);
        return surveys;
    } catch (err) {
        console.log(`console log: error log:  ${err}`);
        throw err;
    }
}

export const surveyService = {
    getSurveys: getSurveysFromServerSide,
};
