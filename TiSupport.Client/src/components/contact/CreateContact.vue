<script setup lang="ts">
import { ref } from 'vue';
import {Contact, createContact} from "../../utils/contactUtils.ts";

const newContact = ref<Contact>({
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

const emit = defineEmits(['contactCreated']);

const submitForm = async () => {
  try {
    await createContact(newContact.value);
    console.log('Contact created successfully');
    emit('contactCreated');

    newContact.value = {
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
    console.error('Error creating contact:', error);
  }
};

</script>

<template>
  <div class="card">
    <h3>Create New Contact</h3>
    <form>
      <div class="input-group">
        <label>Name</label>
        <input v-model="newContact.fullName" placeholder="Enter Contact name">
      </div>
      <div class="input-group">
        <label>First Name</label>
        <input v-model="newContact.firstName" placeholder="Enter first name">
      </div>
      <div class="input-group">
        <label>Last Name</label>
        <input v-model="newContact.lastName" placeholder="Enter second name">
      </div>
      <div class="input-group">
        <label>Email</label>
        <input v-model="newContact.email" placeholder="Enter Contact email">
      </div>
      <div class="input-group">
        <label>Phone</label>
        <input v-model="newContact.phone" placeholder="Enter Contact phone">
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Create Contact</button>
    </form>
  </div>
</template>