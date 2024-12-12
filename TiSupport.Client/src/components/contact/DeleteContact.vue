<script setup lang="ts">
import { ref } from 'vue';
import {Contact, deleteContact} from "../../utils/contactUtils.ts";

let contact = ref<Contact>({
  id: 0,
  name: '',
  email: null,
  fullName: null,
  firstName: null,
  lastName: null,
  addressId: null,
  phone: null,
  ticketIds: null,
  companyIds: null,
});

let emit = defineEmits(['contactDeleted']);

let submitForm = async () => {
  try {
    await deleteContact(contact.value);
    console.log('Contact deleted successfully');
    emit('contactDeleted');

    contact.value = {
      id: 0,
      name: '',
      email: null,
      fullName: null,
      firstName: null,
      lastName: null,
      addressId: null,
      phone: null,
      ticketIds: null,
      companyIds: null,
    };
  } catch (error) {
    console.error('Error deleting contact:', error);
  }
};
</script>

<template>
  <div class="card">
    <h2>Delete Contact</h2>
    <form>
      <div class="input-group">
        <label>Id</label>
        <input v-model.number="contact.id">
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Delete Contact</button>
    </form>
  </div>
</template>