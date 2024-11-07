import axios from "axios";
import Keycloak from "keycloak-js";

export const keycloak = new Keycloak({
    url: 'http://localhost:8080/',
    realm: 'tisupport',
    clientId: 'vue',
});

export const httpClient = axios.create({
    baseURL: 'https://localhost:7151',
    timeout: 5000,
});

export default httpClient;