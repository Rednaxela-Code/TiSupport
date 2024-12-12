<script setup lang="ts">
import {onMounted, ref} from "vue";
import {Contact, getAllContacts} from "../../utils/contactUtils.ts";

let contacts = ref<Contact[]>([]);

let fetchContacts = async () => {
  try {
    contacts.value = await getAllContacts();
  } catch (error) {
    console.error(error);
  }
};

defineExpose({
  refreshData: fetchContacts
});

onMounted(() => {
  fetchContacts();
});
</script>

<template>
  <div class="card">
    <h2>Contacts</h2>
    <button class="btn btn-primary" style="margin-bottom: 1rem;">New Contact</button>
    <table class="table">
      <thead>
      <tr>
        <th>ID</th>
        <th>Contact Name</th>
        <th>First Name</th>
        <th>Last Name</th>
        <th>Email</th>
        <th>Phone</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="contact in contacts" :key="contact.id">
        <td>{{contact.id}}</td>
        <td>{{contact.fullName}}</td>
        <td>{{contact.firstName}}</td>
        <td>{{contact.lastName}}</td>
        <td>{{contact.email}}</td>
        <td>{{contact.phone}}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>