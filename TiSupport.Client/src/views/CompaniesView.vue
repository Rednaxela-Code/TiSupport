<script setup lang="ts">
import { ref } from 'vue';
import CreateCompany from "../components/CreateCompany.vue";
import Companies from "../components/Companies.vue";
import DeleteCompany from "../components/DeleteCompany.vue";
import UpdateCompany from "../components/UpdateCompany.vue";

const companiesComponentRef = ref();

const refreshCompanies = () => {
  if (companiesComponentRef.value && typeof companiesComponentRef.value.refreshData === 'function') {
    companiesComponentRef.value.refreshData();
  }
};
</script>

<template>
  <div class="main-content">
    <Companies ref="companiesComponentRef" />
    <CreateCompany @companyCreated="refreshCompanies" />
    <DeleteCompany @companyDeleted="refreshCompanies" />
    <UpdateCompany @companyUpdated="refreshCompanies" />
  </div>
</template>