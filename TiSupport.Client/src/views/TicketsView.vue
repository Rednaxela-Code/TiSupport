<script setup lang="ts">
import CreateTicket from "../components/CreateTicket.vue";
import Tickets from "../components/Tickets.vue";
import {ref} from "vue";
import UpdateTicket from "../components/UpdateTicket.vue";
import DeleteTicket from "../components/DeleteTicket.vue";

const ticketsComponentRef = ref();

const refreshTickets = async () => {
  if (ticketsComponentRef.value && typeof ticketsComponentRef.value.refreshData === 'function') {
    ticketsComponentRef.value.refreshData();
  }
}
</script>

<template>
  <div class="main-content">
    <Tickets ref="ticketsComponentRef"/>
    <CreateTicket @ticketCreated="refreshTickets" />
    <UpdateTicket @ticketUpdated="refreshTickets" />
    <DeleteTicket @ticketDeleted="refreshTickets" />
  </div>
</template>