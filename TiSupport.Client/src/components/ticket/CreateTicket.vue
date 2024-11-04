<script setup lang="ts">
import { ref } from "vue";
import { Ticket, createTicket } from "../../utils/ticketUtils.ts";

const newTicket = ref<Ticket>({
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

const emit = defineEmits(['ticketCreated']);

const submitForm = async () => {
  try {
    await createTicket(newTicket.value);
    console.log('Ticket created successfully');
    emit('ticketCreated');
    
    newTicket.value = {
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
    console.error('Error creating ticket:', error);
  }
};
</script>

<template>
    <div class="card">
      <h3>Create New Ticket</h3>
      <form>
        <div class="input-group">
          <label>Subject</label>
          <input v-model="newTicket.name" placeholder="Enter ticket subject">
        </div>
        <div class="input-group">
          <label>User</label>
          <input v-model="newTicket.userId" placeholder="Enter ticket user id">
        </div>
        <div class="input-group">
          <label>Description</label>
          <textarea v-model="newTicket.content" rows="3" placeholder="Enter ticket description"></textarea>
        </div>
        <button @click="submitForm" type="button" class="btn btn-primary">Create Ticket</button>
      </form>
    </div>
</template>