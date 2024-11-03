<script setup lang="ts">
import {RouterLink} from "vue-router";
</script>

<template>
  <nav class="navbar">
    <div class="nav-container">
      <RouterLink to="/" class="nav-logo">TiSupport</RouterLink>
      <div class="nav-links">
        <RouterLink to="/" class="nav-link">Home</RouterLink>
        <RouterLink to="/tickets" class="nav-link">Tickets</RouterLink>
        <RouterLink to="/contacts" class="nav-link">Contacts</RouterLink>
        <RouterLink to="/companies" class="nav-link">Companies</RouterLink>
        <RouterLink to="/settings" class="nav-link">Settings</RouterLink>
      </div>
    </div>
  </nav>
</template>