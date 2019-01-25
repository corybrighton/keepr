<template>
  <div id="app">
    <div class="space"></div>
    <router-view />
    <div class="space">
      <navbar class="fixed-top" />
    </div>
  </div>
</template>

<script>
  import navbar from '@/components/Navbar.vue'
  export default {
    components: {
      navbar
    }
  }
</script>

<style>
  body {
    background-color: #102372;
    color: white;
    font-family: cursive;
  }

  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .space {
    margin-bottom: 5rem;
  }
</style>