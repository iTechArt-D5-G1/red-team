import { Survey } from '../../models/survey';
import { AxiosInstance } from './axiosInstance.js';

class HttpUtility {
    static async GetSurveys() {
        try {
            const response = await AxiosInstance.get();
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
