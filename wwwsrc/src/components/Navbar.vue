<template>
  <div class="navbar">
    <router-link :to="{name: 'home' }"><a>Home</a></router-link>

    <!-- Logged in navbar -->
    <div v-if="user.id">
      <router-link :to="{name: 'dashboard' }"><a>Dashboard</a></router-link>
    </div>

    <!-- Not Logged in navbar -->
    <div v-else>
      <form v-if="loginForm" @submit.prevent="loginUser">
        <input type="email" v-model="creds.email" placeholder="email">
        <input type="password" v-model="creds.password" placeholder="password">
        <button type="submit">Login</button>
      </form>
      <form v-else @submit.prevent="register">
        <input type="text" v-model="newUser.username" placeholder="name">
        <input type="email" v-model="newUser.email" placeholder="email">
        <input type="password" v-model="newUser.password" placeholder="password">
        <button type="submit">Create Account</button>
      </form>
      <div @click="loginForm = !loginForm">
        <p v-if="loginForm">Or Register</p>
        <p v-else>Or Login</p>
      </div>
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
  }

  a {
    color: wheat;
  }
</style>