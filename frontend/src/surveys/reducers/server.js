import { serverConstants } from '../actions/';

const server = (state = [], action) => {
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

export default server;
