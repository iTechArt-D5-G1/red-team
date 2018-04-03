import { http } from '../../shared/utils/http.js';
import { Survey } from '../../models/survey.js';
import { SurveysApiUrl } from './../../config';

async function getSurveys() {
    try {
        const instance = http();
        const response = await instance.get(SurveysApiUrl);
        const { data } = response.data;
        const surveys = data.map(s => Survey(s.id, s.text));
        return surveys;
    } catch (err) {
        throw err;
    }
}

async function addSurvey(survey) {
    try {
        const instance = http();
        await instance.post(SurveysApiUrl, survey.text);
        return survey;
    } catch (err) {
        throw err;
    }
}

export const surveyService = {
    getSurveys,
    addSurvey,
};
