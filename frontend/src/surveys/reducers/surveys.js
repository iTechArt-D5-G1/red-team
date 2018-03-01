import '../actions/surveyActionCreators';
import { surveyConstants } from '../actions/actions';

const surveys = (state = [], action) => {
    switch (action.type) {
        case surveyConstants.ADD_SURVEY:
            return [
                ...state,
                {
                    id: action.id,
                    text: action.text,
                },
            ];
        default:
            return state;
    }
};

export default surveys;
