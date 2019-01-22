<template>
  <div class="home container-fluid">
    <h1>Welcome Home {{this.user.username}}</h1>
    <button v-if="checkedLoggedIn2()" @click="logout">Logout</button>
    <form @submit.prevent="addKeep">
      <input type="text" placeholder="Title" v-model.trim="newKeep.name" maxlength="20" required>
      <input type="text" placeholder="Description" v-model.trim="newKeep.description" required>
      <input type="text" placeholder="Image URL" v-model.trim="newKeep.img" required>
      <button type="submit">Add Keep</button>
      <button type="reset">Reset Form</button>
    </form>

    <!-- Keeps -->
    <div class="row d-flex card-deck">
      <keep v-for="k in keeps" :kp="k" :key="k.id" />
    </div>
  </div>
</template>

<script>
  import keep from '@/components/Keep.vue'
  export default {
    name: "home",
    data() {
      return {
        loggedIn: false,
        newKeep: {
          name: "",
          description: "",
          img: ""
        }
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
      checkedLoggedIn2() {
        return (this.user.id) ? true : false;
      },
      checkedLoggedIn() {
        if (this.user.id) {
          this.loggedIn = true;
        }
      },
      getKeeps() {
        this.$store.dispatch('getPublicKeeps')
      },
      addKeep() {
        if (this.user.id)
          this.$store.dispatch('addKeep', this.newKeep)
      }
    }, components: {
      keep
    }
  };
</script>