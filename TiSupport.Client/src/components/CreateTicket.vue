<script setup lang="ts">

</script>

<template>
    <div class="card">
      <h3>Create New Ticket</h3>
      <form>
        <div class="input-group">
          <label>Subject</label>
          <input type="text" placeholder="Enter ticket subject">
        </div>
        <div class="input-group">
          <label>Description</label>
          <textarea rows="3" placeholder="Enter ticket description"></textarea>
        </div>
        <div class="input-group">
          <label>Priority</label>
          <select>
            <option>Low</option>
            <option>Medium</option>
            <option>High</option>
          </select>
        </div>
        <button type="submit" class="btn btn-primary">Create Ticket</button>
      </form>
    </div>
</template>