<script setup lang="ts">

</script>

<template>
  <div class="card">
    <h2>Recent Tickets</h2>
    <table class="table">
      <thead>
      <tr>
        <th>ID</th>
        <th>Subject</th>
        <th>Status</th>
        <th>Priority</th>
        <th>Assigned To</th>
        <th>Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr>
        <td>#1234</td>
        <td>Login Issues</td>
        <td><span class="badge badge-success">Open</span></td>
        <td>High</td>
        <td>John Doe</td>
        <td>
          <button class="btn btn-primary">Edit</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>