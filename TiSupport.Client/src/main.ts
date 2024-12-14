// Updated main.ts
import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import router from './router';
import { keycloak, httpClient } from './utils/httpClient.ts';

const app = createApp(App);

keycloak.init({ onLoad: 'login-required',
    checkLoginIframe: false })
    .then((authenticated) => {
        if (authenticated) {
            //console.log('Access Token:', keycloak.token);
            // Set up Axios interceptor to add the token to each request
            httpClient.interceptors.request.use(async (config) => {
                await keycloak.updateToken(30); // Refresh token if close to expiring
                config.headers.Authorization = `Bearer ${keycloak.token}`;
                return config;
            });

            app.use(router);
            app.mount('#app'); // Only call once here
        } else {
            console.log('User is not authenticated');
        }
    })
    .catch((error) => {
        console.error('Failed to initialize Keycloak', error);
    });
