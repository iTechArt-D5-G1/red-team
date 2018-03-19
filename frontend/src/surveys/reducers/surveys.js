import '../actions/surveyActionCreators';
import { surveyConstants } from '../actions/actions';
import { Survey } from '../../models/survey';

const initialState = {
    isFetching: false,
    isError: false,
    surveys: [new Survey(1, 'First survey'), new Survey(2, 'Second survey')],
};

const surveys = (state = initialState, action) => {
    switch (action.type) {
        case surveyConstants.ADD_SURVEY: return [
            ...state,
            {
                surveys: action.survey,
            },
        ];
        case surveyConstants.SURVEYS_REQUEST_INIT:
            return {
                ...state,
                isFetching: true,
            };
        case surveyConstants.SURVEYS_REQUEST_ERROR:
            return {
                ...state,
                isError: true,
                isFetching: false,
            };
        case surveyConstants.SURVEYS_REQUEST_SUCCESS:
            return {
                ...state,
                isError: false,
                isFetching: false,
                surveys: action.surveys,
            };
        default:
            return state;
    }
};

export default surveys;
