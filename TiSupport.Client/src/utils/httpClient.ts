import axios from "axios";

const httpClient = axios.create({
    baseURL: 'https://localhost:7151',
    timeout: 5000,
});

export default httpClient;