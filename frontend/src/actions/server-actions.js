let axios = require('axios');

//reducer to indicate that our api call has started
export const startDevSearch = () => {
    return {
        type : 'Start_Dev_Search'
    }
}

// reducer to indicate we have received all our data from the api
export const endDevSearch = (surveysArr) => {
    return {
        type : 'End_Dev_Search',
        surveysArr
    }
}


//here we actually do the fetching
export const fetchDev = (maxCount) => {
    const url = "https://api.github.com/search/users?q=language:javascript+location:lagos&sort:repositories&order:desc"
    return (dispatch) => {
        dispatch(startDevSearch())
        return axios.get(url).then(
            (response) => {
                const surveysArr = response.data.items.slice(0,maxCount)
                dispatch(endDevSearch(surveysArr))
            },
            (err) => {
                console.log(err);
            }
        )

    }
}