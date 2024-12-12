<script setup lang="ts">
import { companiesLogic } from "./Companies.ts";

let { companies } = companiesLogic();
</script>

<template>
  <div class="card">
    <h2>Companies</h2>
    <button class="btn btn-primary" style="margin-bottom: 1rem;">New Company</button>
    <table class="table">
      <thead>
      <tr>
        <th>ID</th>
        <th>Company Name</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="company in companies" :key="company.id">
        <td>{{ company.id }}</td>
        <td>{{ company.name }}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>
