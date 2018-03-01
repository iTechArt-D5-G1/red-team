import { Survey } from '../../models/survey';
import { ServerUrl } from '../../server.config';

const axios = require('axios');

const axiosInstanceCreate = () => axios.create({
    baseURL: ServerUrl,
    timeout: 10000,
})
    .interceptors.request.use(
        config => config,
        error =>
            Promise.reject(error),
    );

function getSurveys() {
    try {
        const response = axiosInstanceCreate.get(ServerUrl);
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

export const HttpUtility = {
    getSurveys,
};
