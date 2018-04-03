import { http } from '../../shared/utils/http.js';
import { Survey } from '../../models/survey.js';
import { SurveysApiUrl } from './../../config';

async function getSurveys() {
    const response = await http.get(SurveysApiUrl);
    return response.data.map(s => Survey(s.id, s.text));
}

async function addSurvey(survey) {
    await http.post(SurveysApiUrl, survey.text);
    return survey;
}

export const surveyService = {
    getSurveys,
    addSurvey,
};
