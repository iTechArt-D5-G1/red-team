const server = (state = { isFetching: false, surveysArr: [] }, action) => {
    switch (action.type) {
        case 'Start_Dev_Search':
            return {
                isFetching: true,
            };

        case 'End_Dev_Search':
            return {
                isFetching: false,
                surveysArr: action.surveysArr,
            };
        default:
            return state;
    }
};

export default server;
