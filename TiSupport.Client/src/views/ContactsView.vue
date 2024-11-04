<script setup lang="ts">
import CreateContact from "../components/CreateContact.vue";
import {ref} from "vue";
import Contacts from "../components/Contacts.vue";
import UpdateContact from "../components/UpdateContact.vue";
import DeleteContact from "../components/DeleteContact.vue";

const contactComponentRef = ref();

const refreshContacts = () => {
  if (contactComponentRef.value && typeof contactComponentRef.value.refreshData === 'function') {
    contactComponentRef.value.refreshData();
  }
};
</script>

<template>
  <div class="main-content">
    <Contacts ref="contactComponentRef"/>
    <CreateContact @contactCreated="refreshContacts"/>
    <UpdateContact @contactUpdated="refreshContacts"/>
    <DeleteContact @contactDeleted="refreshContacts"/>
  </div>
</template>