<script setup lang="ts">
import { ref } from 'vue';
import {Contact, updateContact} from "../../utils/contactUtils.ts";

let updateableContact = ref<Contact>({
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

let emit = defineEmits(['contactUpdated']);

let submitForm = async () => {
  try {
    await updateContact(updateableContact.value);
    console.log('Contact updated successfully');
    emit('contactUpdated');

    updateableContact.value = {
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
    console.error('Error updating contact:', error);
  }
};

</script>

<template>
  <div class="card">
    <h3>Update Contact</h3>
    <form>
      <div class="input-group">
        <label>Name</label>
        <input v-model="updateableContact.fullName" placeholder="Enter Contact name">
      </div>
      <div class="input-group">
        <label>First Name</label>
        <input v-model="updateableContact.firstName" placeholder="Enter first name">
      </div>
      <div class="input-group">
        <label>Last Name</label>
        <input v-model="updateableContact.lastName" placeholder="Enter second name">
      </div>
      <div class="input-group">
        <label>Email</label>
        <input v-model="updateableContact.email" placeholder="Enter Contact email">
      </div>
      <div class="input-group">
        <label>Phone</label>
        <input v-model="updateableContact.phone" placeholder="Enter Contact phone">
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Update Contact</button>
    </form>
  </div>
</template>