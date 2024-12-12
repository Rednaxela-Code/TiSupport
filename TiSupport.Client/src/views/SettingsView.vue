<script setup lang="ts">
const logout = () => {
  const logoutUrl = `http://localhost:8080/realms/tisupport/protocol/openid-connect/logout?redirect_uri=${encodeURIComponent('http://localhost:5173')}`;
  window.location.href = logoutUrl; // Redirect to Keycloak logout
};
</script>

<template>
  <div class="main-content">
  <button @click="logout">Logout</button>
  </div>
</template>