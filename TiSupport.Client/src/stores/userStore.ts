import { defineStore } from 'pinia';
import { keycloak } from '../utils/httpClient.ts';

export const useAuthStore = defineStore('auth', {
    state: () => ({
        roles: [] as string[],
    }),
    actions: {
        loadRoles() {
            const tokenParsed = keycloak.tokenParsed;
            this.roles = tokenParsed?.resource_access?.vue?.roles || [];
        },
    },
});
