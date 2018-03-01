import { serverConstants } from '../actions/';

const serverSurveys = (state = [], action) => {
    switch (action.type) {
        case serverConstants.GET_SURVEYS:
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

export default serverSurveys;
