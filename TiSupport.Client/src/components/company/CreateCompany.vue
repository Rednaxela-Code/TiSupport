<script setup lang="ts">
import {computed, ref} from 'vue';
import { Company, CompanyType } from '../../utils/companyUtils.ts';
import { createCompany} from "../../utils/companyUtils.ts";

const newCompany = ref<Company>({
  id: 0,
  name: '',
  employees: null,
  companyType: 0,
});

const emit = defineEmits(['companyCreated']);

const submitForm = async () => {
  try {
    await createCompany(newCompany.value);
    console.log('Company created successfully');
    emit('companyCreated');

    newCompany.value = {
      id: 0,
      name: '',
      employees: null,
      companyType: 0,
    };
  } catch (error) {
    console.error('Error creating company:', error);
  }
};

const companyTypeOptions = computed(() => {
  return Object.keys(CompanyType)
      .filter(key => isNaN(Number(key)))
      .map(key => ({ name: key, value: CompanyType[key as keyof typeof CompanyType] }));
});
</script>

<template>
  <div class="card">
    <h3>Create New Company</h3>
    <form>
      <div class="input-group">
        <label>Name</label>
        <input v-model="newCompany.name" placeholder="Enter Company name">
      </div>
      <div class="input-group">
        <label>Type</label>
        <select v-model="newCompany.companyType">
          <option disabled value="">Please select one</option>
          <option v-for="option in companyTypeOptions" :key="option.value" :value="option.value">
            {{ option.name }}
          </option>
        </select>
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Create Company</button>
    </form>
  </div>
</template>