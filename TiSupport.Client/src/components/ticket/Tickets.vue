<script setup lang="ts">
import {onMounted, ref} from "vue";
import {getAllTickets, Ticket} from "../../utils/ticketUtils.ts";

let tickets = ref<Ticket[]>([]);

let fetchTickets = async () => {
  try {
    tickets.value = await getAllTickets();
  } catch (error) {
    console.error(error);
  }
};

defineExpose({
  refreshData: fetchTickets
});

onMounted(() => {
  fetchTickets();
});
</script>

<template>
  <div class="card">
    <h2>All Tickets</h2>
    <button class="btn btn-primary" style="margin-bottom: 1rem;">New Ticket</button>
    <table class="table">
      <thead>
      <tr>
        <th>ID</th>
        <th>Subject</th>
        <th>Status</th>
        <th>Priority</th>
        <th>Category</th>
        <th>Content</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="ticket in tickets" :key="ticket.id">
        <td>{{ticket.id}}</td>
        <td>{{ticket.name}}</td>
        <td>{{ticket.status}}</td>
        <td>{{ticket.priority}}</td>
        <td>{{ticket.category}}</td>
        <td>{{ticket.content}}</td>
        <td>
          <button class="btn btn-primary">Edit</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>