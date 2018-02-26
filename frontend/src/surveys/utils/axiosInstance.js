import { ServerUrl } from '../../server.config';

const axios = require('axios');

const AxiosInstance = axios.create({
    baseURL: ServerUrl,
    timeout: 10000,
})
    .interceptors.request.use(
        config => config,
        error =>
            Promise.reject(error),
    );

export default AxiosInstance;
