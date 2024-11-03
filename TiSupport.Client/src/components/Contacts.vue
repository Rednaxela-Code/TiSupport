<script setup lang="ts">
import {onMounted, ref} from "vue";
import {Contact, getAllContacts} from "../utils/contactUtils.ts";

const contacts = ref<Contact[]>([]);

const fetchContacts = async () => {
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
      </tr>
      </thead>
      <tbody>
      <tr v-for="company in contacts" :key="company.id">
        <td>{{company.id}}</td>
        <td>{{company.name}}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>