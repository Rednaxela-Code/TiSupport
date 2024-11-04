<script setup lang="ts">
import { ref } from 'vue';
import { Company } from '../../utils/companyUtils.ts';
import { updateCompany } from "../../utils/companyUtils.ts";

const updatableCompany = ref<Company>({
  id: 0,
  name: '',
  employees: null,
});

const emit = defineEmits(['companyUpdated']);

const submitForm = async () => {
  try {
    await updateCompany(updatableCompany.value);
    console.log('Company created successfully');
    emit('companyUpdated');

    updatableCompany.value = {
      id: 0,
      name: '',
      employees: null,
    };
  } catch (error) {
    console.error('Error updating company:', error);
  }
};

</script>

<template>
  <div class="card">
    <h3>Update Company</h3>
    <form>
      <div class="input-group">
        <label>ID</label>
        <input v-model="updatableCompany.id" placeholder="Enter Company ID">
      </div>
      <div class="input-group">
        <label>Name</label>
        <input v-model="updatableCompany.name" placeholder="Enter Company name">
      </div>
      <button @click="submitForm" type="button" class="btn btn-primary">Update Company</button>
    </form>
  </div>
</template>