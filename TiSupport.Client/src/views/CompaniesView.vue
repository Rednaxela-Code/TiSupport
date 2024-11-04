<script setup lang="ts">
import { ref } from 'vue';
import CreateCompany from "../components/company/CreateCompany.vue";
import Companies from "../components/company/Companies.vue";
import DeleteCompany from "../components/company/DeleteCompany.vue";
import UpdateCompany from "../components/company/UpdateCompany.vue";

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