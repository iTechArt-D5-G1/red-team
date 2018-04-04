import { Survey } from '../../models/survey';
import { SurveysApiUrl } from './../../config';

export class SurveyService {
    constructor(http) {
        this.http = http;
    }

    async getSurveys() {
        const response = await this.http.get(SurveysApiUrl);
        return response.data.map(s => Survey(s.id, s.text));
    }

    async addSurvey(survey) {
        await this.http.post(SurveysApiUrl, survey.text);
        return survey;
    }
}
