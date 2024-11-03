<script setup lang="ts">

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
        <th>Contact Person</th>
        <th>Email</th>
        <th>Status</th>
        <th>Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr>
        <td>#C001</td>
        <td>Tech Corp</td>
        <td>Jane Smith</td>
        <td>contact@techcorp.com</td>
        <td><span class="badge badge-success">Active</span></td>
        <td>
          <button class="btn btn-primary">Edit</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>