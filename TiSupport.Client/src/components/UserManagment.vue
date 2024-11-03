<script setup lang="ts">

</script>

<template>
  <div class="card">
    <h2>Users Management</h2>
    <button class="btn btn-primary" style="margin-bottom: 1rem;">New User</button>
    <table class="table">
      <thead>
      <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Email</th>
        <th>Role</th>
        <th>Status</th>
        <th>Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr>
        <td>#001</td>
        <td>John Doe</td>
        <td>john@example.com</td>
        <td>Support Agent</td>
        <td><span class="badge badge-success">Active</span></td>
        <td>
          <button class="btn btn-primary">Edit</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>

</style>