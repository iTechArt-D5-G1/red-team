import { ServerUrl } from './../../config';

const axios = require('axios');

const axiosInstanceOptions = {
    baseURL: ServerUrl,
};

const axiosInstanceCreate = () => {
    const instance = axios.create(axiosInstanceOptions);

    instance.interceptors.request.use(
        config => config,
        error =>
            Promise.reject(error),
    );
    return instance;
};

const Instance = axiosInstanceCreate();

export default Instance;
