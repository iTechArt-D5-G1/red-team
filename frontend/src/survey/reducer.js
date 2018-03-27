import {
    SURVEYS_REQUEST_INIT,
    SURVEYS_REQUEST_SUCCESS,
    SURVEYS_REQUEST_ERROR,
    ADD_SURVEY } from './action';
import { Survey } from '../models/survey';

const initialState = {
    isFetching: false,
    isError: false,
    surveys: [new Survey(1, 'First survey')],
};

const surveys = (state = initialState, action) => {
    switch (action.type) {
        case ADD_SURVEY: return [
            ...state,
            {
                surveys: action.survey,
            },
        ];
        case SURVEYS_REQUEST_INIT:
            return {
                ...state,
                isFetching: true,
            };
        case SURVEYS_REQUEST_ERROR:
            return {
                ...state,
                isError: true,
                isFetching: false,
            };
        case SURVEYS_REQUEST_SUCCESS:
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

