<template>
  <div class="vault-view container-fluid">
    <h3>{{vault.name}}</h3>
    <h4> {{vault.description}} </h4>
    <i class="fas fa-trash" @click="deleteVault"></i>
    <div class="row d-flex card-deck">
      <keep v-for="(k, index) in vault.vaultsKeeps" :key="index" :kp="k" :view="'vv'" :vaultId="vault.id" />
    </div>
  </div>
</template>

<script>
  import keep from '@/components/Keep.vue'
  export default {
    name: 'vault-view',
    data() {
      return {

      }
    },
    computed: {
      vault() {
        return this.$store.state.vaultView
      }
    },
    components: {
      keep
    },
    methods: {
      deleteVault() {
        this.$store.dispatch('deleteVault', this.vault.id)
      }
    }
  }

</script>

<style>


</style>