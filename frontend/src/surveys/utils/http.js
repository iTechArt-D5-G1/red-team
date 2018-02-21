import { ServerUrl } from '../../server/server.config';

const axios = require('axios');


class HttpUtility {
    static async GetSurveys() {
        try {
            const response = await axios.get(ServerUrl);
            const { data } = response.data;
            console.log(data);
            return data;
        } catch (err) {
            console.log(err);
            return null;
        }
    }
}

export default HttpUtility;
