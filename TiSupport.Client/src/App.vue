<script setup lang="ts">
import Navbar from "./components/Navbar.vue";
import RecentTickets from "./components/RecentTickets.vue";
import CreateTicket from "./components/CreateTicket.vue";
import TicketStats from "./components/TicketStats.vue";
import AllTickets from "./components/AllTickets.vue";
import Companies from "./components/Companies.vue";
import UserManagment from "./components/UserManagment.vue";
</script>

<template>
  <Navbar/>
  <div class="main-content">
    <RecentTickets/>
    <div class="grid">
      <CreateTicket/>
      <TicketStats/>
    </div>
    <AllTickets/>
    <Companies/>
    <UserManagment/>
  </div>
</template>