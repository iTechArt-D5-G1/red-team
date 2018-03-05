import { HttpUtility } from '../utils/http.js';
import { serverConstants } from './actions';
import { Survey } from '../../models/survey';

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

export const getSurveys = () => ({
    type: serverConstants.GET_SURVEYS,
    surveys: getSurveysFromServerSide(),
});
