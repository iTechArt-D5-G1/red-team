import { HttpUtility } from '../../utils/http.js';
import { Survey } from '../../models/survey.js';

async function getSurveys() {
    try {
        const instance = HttpUtility.InstanceCreate();
        const response = await instance.get('/surveys');
        const { data } = response.data;
        const surveys = data.map(s => Survey(s.id, s.text));
        return surveys;
    } catch (err) {
        throw err;
    }
}

async function addSurvey(survey) {
    try {
        const instance = HttpUtility.InstanceCreate();
        await instance.post('/surveys', survey.text);
        return survey;
    } catch (err) {
        throw err;
    }
}

export const surveyService = {
    getSurveys,
    addSurvey,
};
