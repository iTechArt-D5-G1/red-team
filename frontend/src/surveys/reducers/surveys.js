import '../actions/surveyActionCreators';
import { ADD_SURVEY } from '../actions/actions';

const surveys = (state = [], action) => {
    switch (action.type) {
        case ADD_SURVEY:
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
