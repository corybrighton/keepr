<template>
  <div class="home container-fluid">
    <h1>Welcome Home {{this.user.username}}</h1>

    <!-- Keeps -->
    <div class="row d-flex card-deck">
      <keep v-for="k in keeps" :kp="k" :key="k.id" :view="'home'" />
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
      this.getKeeps()
      this.getVaults()
    },
    methods: {
      getKeeps() {
        this.$store.dispatch('getPublicKeeps')
      },
      getVaults() {
        this.$store.dispatch('getVaults')
      },
      addKeep() {
        if (this.user.id) {
          this.$store.dispatch('addKeep', this.newKeep)
          this.newKeep = {
            name: "",
            description: "",
            img: ""
          }
        }
      }
    }, components: {
      keep
    }
  };
</script>

<style>
  .card-body:hover,
  .card-img-top:hover,
  .card-title:hover {
    cursor: pointer;
  }
</style>