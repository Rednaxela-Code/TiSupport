<script setup lang="ts">
import { ref } from 'vue';
import { Company } from '../utils/companyUtils.ts';
import { createCompany} from "../utils/companyUtils.ts";

const newCompany = ref<Company>({
  id: 0,
  name: '', 
});

const submitForm = async () => {
  try {
    await createCompany(newCompany.value);
    console.log('Company created successfully');
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
        <input v-model="newCompany.name" placeholder="Enter Company name">
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Create Company</button>
    </form>
  </div>
</template>