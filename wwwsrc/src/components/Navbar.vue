<template>
  <div class="navbar">

    <!-- Logged in navbar -->
    <div v-if="user.id" class="row">
      <div>
        <router-link :to="{name: 'home' }"><button class="btn btn-primary">Home</button></router-link>
      </div>
      <div>
        <router-link :to="{name: 'dashboard' }"><button class="btn btn-primary">Dashboard</button></router-link>
      </div>
      <div>
        <button class="btn btn-primary" @click="logout">Logout</button>
      </div>
    </div>

    <!-- Not Logged in navbar -->
    <div v-else class="row">
      <router-link :to="{name: 'home' }"><button class="btn btn-primary">Home</button></router-link>
      <button class="btn btn-primary" v-if="loginForm" @click="loginForm = !loginForm">Register</button>
      <button class="btn btn-primary" v-else @click="loginForm = !loginForm">Login</button>
      <form v-if="loginForm" @submit.prevent="loginUser">
        <input type="email" v-model="creds.email" placeholder="email">
        <input type="password" v-model="creds.password" placeholder="password">
        <button class="btn btn-primary" type="submit">Login</button>
      </form>
      <form v-else @submit.prevent="register">
        <input type="text" v-model="newUser.username" placeholder="name">
        <input type="email" v-model="newUser.email" placeholder="email">
        <input type="password" v-model="newUser.password" placeholder="password">
        <button class="btn btn-primary" type="submit">Create Account</button>
      </form>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'navbar',
    data() {
      return {
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      },
      register() {
        this.$store.dispatch("register", this.newUser);
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
      }
    }
  }

</script>

<style scoped>
  .navbar {
    background-color: darkcyan;
    display: flex;
    justify-content: flex-end;
  }

  a {
    color: wheat;
  }
</style>