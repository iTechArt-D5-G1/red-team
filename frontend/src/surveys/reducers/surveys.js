import '../actions/surveyActionCreators';
import { surveyConstants } from '../actions/actions';

const surveys = (state = [], action) => {
    switch (action.type) {
        case surveyConstants.ADD_SURVEY: return [
            ...state,
            {
                surveys: action.survey,
            },
        ];
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
