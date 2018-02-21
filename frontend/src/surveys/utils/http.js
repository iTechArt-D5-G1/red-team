import { ServerUrl } from '../../server.config';
import { Survey } from '../../models/survey';

const axios = require('axios');


class HttpUtility {
    static async GetSurveys() {
        try {
            const response = await axios.get(ServerUrl);
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
