<script setup lang="ts">
import {onMounted, ref} from "vue";
import {getAllTickets, Ticket, getStatusString, getCategoryString, getPriorityString} from "../../utils/ticketUtils.ts";

const tickets = ref<Ticket[]>([]);

const fetchTickets = async () => {
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
        <th>Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="ticket in tickets" :key="ticket.id">
        <td>{{ticket.id}}</td>
        <td>{{ticket.name}}</td>
        <td>{{getStatusString(ticket.status)}}</td>
        <td>{{getPriorityString(ticket.priority)}}</td>
        <td>{{getCategoryString(ticket.category)}}</td>
        <td>
          <button class="btn btn">View</button>
          <button class="btn btn-primary">Edit</button>
          <button class="btn btn-warning">Delete</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>