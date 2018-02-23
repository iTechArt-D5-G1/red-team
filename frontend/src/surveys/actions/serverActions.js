const axios = require('axios');

export const startDevSearch = () => ({
    type: 'Start_Dev_Search',
});

export const endDevSearch = surveysArr => ({
    type: 'End_Dev_Search',
    surveysArr,
});


// here we actually do the fetching
export const fetchDev = (maxCount) => {
    const url = 'here server call';
    return (dispatch) => {
        dispatch(startDevSearch());
        return axios.get(url).then(
            (response) => {
                const surveysArr = response.data.items.slice(0, maxCount);
                dispatch(endDevSearch(surveysArr));
            },
            (err) => {
                console.log(err);
            },
        );
    };
};
