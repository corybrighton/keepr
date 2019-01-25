<template>
  <div class="navbar">

    <!-- Logged in navbar -->
    <div v-if="user.id" class="row">
      <div>
        <router-link :to="{name: 'home' }"><button class="bton">HOME</button></router-link>
      </div>
      <div>
        <router-link :to="{name: 'dashboard' }"><button class="bton mx-5">DASHBOARD</button></router-link>
      </div>
      <div>
        <button class="bton" @click="logout">LOGOUT</button>
      </div>
    </div>

    <!-- Not Logged in navbar -->
    <div v-else class="row">
      <router-link :to="{name: 'home' }"><button class="bton">HOME</button></router-link>
      <button class="bton" v-if="loginForm" @click="loginForm = !loginForm">REGISTER</button>
      <button class="bton" v-else @click="loginForm = !loginForm">LOGIN</button>
      <form v-if="loginForm" @submit.prevent="loginUser">
        <input type="email" v-model="creds.email" placeholder="email">
        <input type="password" v-model="creds.password" placeholder="password">
        <button class="bton" type="submit">LOGIN</button>
      </form>
      <form v-else @submit.prevent="register">
        <input type="text" v-model="newUser.username" placeholder="name">
        <input type="email" v-model="newUser.email" placeholder="email">
        <input type="password" v-model="newUser.password" placeholder="password">
        <button class="bton" type="submit">CREATE ACCOUNT</button>
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
    background-color: black;
    display: flex;
    justify-content: center;
  }

  .bton {
    color: white;
    background-color: black;
    border: black;
  }

  .bton:focus {
    outline: none;
  }
</style>