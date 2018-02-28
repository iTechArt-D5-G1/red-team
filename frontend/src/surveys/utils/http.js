import { Survey } from '../../models/survey';
import { ServerUrl } from '../../server.config';

const axios = require('axios');

class HttpUtility {
    static async GetSurveys() {
        try {
            const response = axios.get(ServerUrl);
            console.log(response);
            const { data } = response.data;
            const surveys = data.map(s => Survey(s.id, s.text));
            console.log(data);
            return surveys;
        } catch (err) {
            console.log(err);
            return null;
        }
    }
}

export default HttpUtility;
