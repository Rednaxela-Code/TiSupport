<script setup lang="ts">
import { ref } from 'vue';
import {Contact, updateContact} from "../utils/contactUtils.ts";

const updateableContact = ref<Contact>({
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

const emit = defineEmits(['contactUpdated']);

const submitForm = async () => {
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
        <label>ID</label>
        <input v-model.number="updateableContact.id">
      </div>
      <div class="input-group">
        <label>Name</label>
        <input v-model="updateableContact.fullName" placeholder="Enter Contact name">
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Update Contact</button>
    </form>
  </div>
</template>