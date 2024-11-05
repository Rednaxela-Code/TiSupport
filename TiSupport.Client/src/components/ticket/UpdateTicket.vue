<script setup lang="ts">
import { ref } from "vue";
import {
  Ticket,
  ticketCategoryOptions,
  ticketPriorityOptions,
  ticketStatusOptions,
  updateTicket
} from "../../utils/ticketUtils.ts";

const updateableTicket = ref<Ticket>({
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

const emit = defineEmits(['ticketUpdated']);

const submitForm = async () => {
  try {
    await updateTicket(updateableTicket.value);
    console.log('Ticket updated successfully');
    emit('ticketUpdated');

    updateableTicket.value = {
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
    console.error('Error updating ticket:', error);
  }
};
</script>

<template>
  <div class="card">
    <h3>Update Ticket</h3>
    <form>
      <div class="input-group">
        <label>ID</label>
        <input v-model.number="updateableTicket.id">
      </div>
      <div class="input-group">
        <label>Subject</label>
        <input v-model="updateableTicket.name" placeholder="Enter ticket subject">
      </div>
      <div class="input-group">
        <label>Status</label>
        <select v-model="updateableTicket.status">
          <option disabled value="">Please select one</option>
          <option v-for="option in ticketStatusOptions" :key="option.value" :value="option.value">
            {{ option.name }}
          </option>
        </select>
      </div>
      <div class="input-group">
        <label>Priority</label>
        <select v-model="updateableTicket.priority">
          <option disabled value="">Please select one</option>
          <option v-for="option in ticketPriorityOptions" :key="option.value" :value="option.value">
            {{ option.name }}
          </option>
        </select>
      </div>
      <div class="input-group">
        <label>Category</label>
        <select v-model="updateableTicket.category">
          <option disabled value="">Please select one</option>
          <option v-for="option in ticketCategoryOptions" :key="option.value" :value="option.value">
            {{ option.name }}
          </option>
        </select>
      </div>
      <div class="input-group">
        <label>User</label>
        <input v-model="updateableTicket.userId" placeholder="Enter ticket user id">
      </div>
      <div class="input-group">
        <label>Attachments</label>
        <input v-model="updateableTicket.attachments" placeholder="Enter attachments">
      </div>
      <div class="input-group">
        <label>Description</label>
        <textarea v-model="updateableTicket.content" rows="3" placeholder="Enter ticket description"></textarea>
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Update Ticket</button>
    </form>
  </div>
</template>