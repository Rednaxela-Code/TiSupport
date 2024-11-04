<script setup lang="ts">
import { ref } from 'vue';
import {Company, deleteCompany} from "../../utils/companyUtils.ts";

const company = ref<Company>({
  id: 0,
  name: '',
  employees: null,
});

const emit = defineEmits(['companyDeleted']);

const submitForm = async () => {
  try {
    await deleteCompany(company.value);
    console.log('Company deleted successfully');
    emit('companyDeleted');

    company.value = {
      id: 0,
      name: '',
      employees: null,
    };
  } catch (error) {
    console.error('Error deleting company:', error);
  }
};
</script>

<template>
<div class="card">
  <h2>Delete Company</h2>
  <form>
    <div class="input-group">
      <label>Id</label>
      <input v-model.number="company.id">
    </div>
    <button @click="submitForm" type="button" class="btn btn-primary">Delete Company</button>
  </form>
</div>
</template>