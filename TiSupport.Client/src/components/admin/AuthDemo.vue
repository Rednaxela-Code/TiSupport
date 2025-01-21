<script setup lang="ts">
import { useAuthStore } from '../../stores/userStore.ts';

const authStore = useAuthStore();
authStore.loadRoles();

const roles = authStore.roles;
</script>

<template>
  <div>
    <button v-if="roles.includes('admin')">Alleen zichtbaar voor Admin</button>
  </div>
</template>

<style scoped>

</style>

<!--Verbeterde UX: Rollen Gebruiken voor Condities-->

<!--Skeleton Loading: Wacht met het tonen van UI totdat de rollen zijn geladen.-->
<!--Fallbacks: Toon meldingen als een gebruiker probeert toegang te krijgen tot een niet-toegestane pagina.-->
<!--<template>-->
<!--  <div v-if="rolesLoaded">-->
<!--    <p v-if="!roles.includes('admin')">Geen toegang tot adminfunctionaliteiten.</p>-->
<!--    <button v-else>Admin Actie</button>-->
<!--  </div>-->
<!--</template>-->

<!--<script setup>-->
<!--import { ref, onMounted } from 'vue';-->
<!--import { useAuthStore } from '@/store/auth';-->

<!--const rolesLoaded = ref(false);-->
<!--const authStore = useAuthStore();-->

<!--onMounted(async () => {-->
<!--  await authStore.loadRoles();-->
<!--  rolesLoaded.value = true;-->
<!--});-->
<!--</script>-->