<template>
  <div class="home container-fluid">
    <h1>Welcome Home {{this.user.username}}</h1>
    <button v-if="loggedIn" @click="logout">Logout</button>

    <!-- Keeps -->
    <div class="card-deck">
      <keep v-for="k  in keeps" :kp="k" />
    </div>
  </div>
</template>

<script>
  import keep from '@/components/Keep.vue'
  export default {
    name: "home",
    data() {
      return {
        loggedIn: false
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      keeps: {
        get: function () {
          return this.$store.state.keeps
        }
      }
    },
    mounted() {
      this.checkedLoggedIn()
      this.getKeeps()
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      },
      checkedLoggedIn() {
        if (this.user.id) {
          this.loggedIn = true;
        }
      },
      getKeeps() {
        this.$store.dispatch('getPublicKeeps')
      }
    }, components: {
      keep
    }
  };
</script>