<template>
  <div class="vaultView col-xl-2 col-lg-3 col-md-4 col-sm-6 mt-3">
    <div class="card">
      <div class="card-body" @click="getVault">
        <h4 class="card-title">
          {{vault.name}}
        </h4>
        {{vault.description}}
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaultView',
    props: ['vault'],
    data() {
      return {

      }
    },
    computed: {},
    methods: {
      getVault() {
        this.$store.dispatch('getVault', this.vault.id)
      }
    }
  }

</script>

<style>


</style>