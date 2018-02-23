import { HttpUtility } from '../utils/';

export const startDevSearch = () => ({
    type: 'Start_Dev_Search',
});

export const endDevSearch = surveysArr => ({
    type: 'End_Dev_Search',
    surveysArr,
});


// here we actually do the fetching
export const fetchDev = () => (dispatch) => {
    dispatch(startDevSearch());
    return HttpUtility.GetSurveys();
};
