<script setup lang="ts">
import { ref } from "vue";
import axios from 'axios';

const company = ref({
  id: 0,
  name: '',
});

const createCompany = async () => {
  try {
    const response = await axios.post('https://localhost:7151/company', company.value, {
      headers: {
        'Content-Type': 'application/json'
      },
      timeout: 15000
    });
    console.log('Company created successfully:', response.data);
  } catch (error) {
    console.error('Error creating company:', error);
  }
};
</script>

<template>
  <div class="card">
    <h3>Create New Company</h3>
    <form>
      <div class="input-group">
        <label>Name</label>
        <input v-model="company.name" placeholder="Enter Company name">
      </div>
      <button @click="createCompany" type="button" class="btn btn-primary">Create Ticket</button>
    </form>
  </div>
</template>