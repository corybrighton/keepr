<template>
  <div class="dashboard container-fluid">
    <h3> {{this.user.username}}'s Vaults</h3>
    <div class="row d-flex card-deck">
      <vaultview v-for="(v, index) in vaults" :key="index" :vault="v" />
    </div>
    <h3> {{this.user.username}}'s Keeps </h3>
  </div>
</template>

<script>
  import vaultview from '@/components/Vault.vue'
  export default {
    name: 'dashboard',
    data() {
      return {

      }
    },
    mounted() {
      this.getVaults()
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      }
    },
    components: {
      vaultview
    },
    methods: {
      getVaults() {
        this.$store.dispatch('getVaults')
      }
    }
  }

</script>

<style>


</style>