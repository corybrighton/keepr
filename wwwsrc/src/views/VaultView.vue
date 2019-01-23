<template>
  <div class="vault-view container-fluid">
    <div class="row d-flex card-deck">
      <keep v-for="(k, index) in vault" :key="index" :kp="k" />
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
    methods: {}
  }

</script>

<style>


</style>