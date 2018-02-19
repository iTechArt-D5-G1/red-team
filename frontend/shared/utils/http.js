import { ServerUrl } from '../../server/server.config';

const axios = require('axios');


class HttpUtility {
    static GetSurveys() {
        return axios.get(ServerUrl).then(
            (response) => {
                console.log(response);
            },
            (err) => {
                console.log(err);
            },
        );
    }
}

export default HttpUtility;
