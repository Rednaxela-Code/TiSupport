import axios from "axios";
import Keycloak from "keycloak-js";

const keycloak = new Keycloak({
    url: 'http://localhost:8080/auth',
    realm: 'my-app',
    clientId: 'vue-client',
});

const httpClient = axios.create({
    baseURL: 'https://localhost:7151',
    timeout: 5000,
});

// Add a request interceptor to include the Keycloak token
httpClient.interceptors.request.use(async (config) => {
    // Ensure the Keycloak instance is initialized and has a token
    if (keycloak.authenticated) {
        // Optionally, you can refresh the token before each request to ensure it's valid
        await keycloak.updateToken(30); // Refresh if the token is going to expire in the next 30 seconds
        config.headers.Authorization = `Bearer ${keycloak.token}`;
    }
    return config;
}, (error) => {
    return Promise.reject(error);
});

export default httpClient;