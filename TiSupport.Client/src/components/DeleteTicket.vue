<script setup lang="ts">
import { ref } from 'vue';
import {Ticket, deleteTicket} from "../utils/ticketUtils.ts";

const ticket = ref<Ticket>({
  id: 0,
  name: '',
  status: null,
  priority: null,
  category: null,
  created: null,
  content: null,
  attachments: null,
  userId: null,
  commentIds: null,
});

const emit = defineEmits(['ticketDeleted']);

const submitForm = async () => {
  try {
    await deleteTicket(ticket.value);
    console.log('Ticket deleted successfully');
    emit('ticketDeleted');

    ticket.value = {
      id: 0,
      name: '',
      status: null,
      priority: null,
      category: null,
      created: null,
      content: null,
      attachments: null,
      userId: null,
      commentIds: null,
    };
  } catch (error) {
    console.error('Error deleting ticket:', error);
  }
};
</script>

<template>
  <div class="card">
    <h2>Delete Ticket</h2>
    <form>
      <div class="input-group">
        <label>Id</label>
        <input v-model.number="ticket.id">
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Delete Ticket</button>
    </form>
  </div>
</template>