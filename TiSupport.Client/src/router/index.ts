import { createRouter, createWebHistory} from "vue-router";
import HomeView from "../views/HomeView.vue";
import CompaniesView from "../views/CompaniesView.vue";
import TicketsView from "../views/TicketsView.vue";
import ContactsView from "../views/ContactsView.vue";
import SettingsView from "../views/SettingsView.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView,
        },
        {
            path: '/tickets',
            name: 'Tickets',
            component: TicketsView,
        },
        {
            path: '/contacts',
            name: 'Contacts',
            component: ContactsView,
        },
        {
            path: '/companies',
            name: 'Companies',
            component: CompaniesView,
        },
        {
            path: '/settings',
            name: 'Settings',
            component: SettingsView,
        },
    ],
});

export default router;