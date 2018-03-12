import '../actions/surveyActionCreators';
import { surveyConstants } from '../actions/actions';
import { surveyService } from '../services/survey.js';

const surveys = (state = [], action) => {
    switch (action.type) {
        case surveyConstants.ADD_SURVEY:
            surveyService.addSurvey(action.survey);
            return state;
        case surveyConstants.GET_SURVEYS:
            return [
                ...state,
                {
                    surveys: action.surveys,
                },
            ];
        default:
            return state;
    }
};

export default surveys;
