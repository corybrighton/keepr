<template>
  <div class="dashboard container-fluid">

    <!-- Users Vaults -->
    <h3> {{this.user.username}}'s Vaults</h3>
    <form @submit.prevent="addVault">
      <input type="text" placeholder="Title of Vault" v-model.trim="newVault.name" maxlength="20" required>
      <input type="text" placeholder="Description" v-model.trim="newVault.description" maxlength="255" required>
      <button type="submit">Create</button>
      <button type="reset">Reset</button>
    </form>
    <div class="row d-flex card-deck">
      <vaultview v-for="(v, index) in vaults" :key="index" :vault="v" />
    </div>

    <!-- Users Keeps -->
    <h3> {{this.user.username}}'s Keeps </h3>
    <form @submit.prevent="addKeep">
      <input type="text" placeholder="Title" v-model.trim="newKeep.name" maxlength="20" required>
      <input type="text" placeholder="Description" v-model.trim="newKeep.description" required maxlength="255">
      <input type="text" placeholder="Image URL" v-model.trim="newKeep.img" required maxlength="255">
      <input type="radio" name="private" v-model="newKeep.isPrivate" value="true">private
      <input type="radio" name="private" v-model="newKeep.isPrivate" value="false">public
      <button type="submit">Add Keep</button>
      <button type="reset">Reset Form</button>
    </form>
    <div class="row d-flex card-deck">
      <keep v-for="k in keeps" :kp="k" :key="k.id" :view="'dashboard'" />
    </div>
  </div>
</template>

<script>
  import vaultview from '@/components/Vault.vue'
  import keep from '@/components/Keep.vue'
  export default {
    name: 'dashboard',
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          isPrivate: false
        },
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    mounted() {
      this.getVaults()
      this.getMyKeeps()
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      },
      keeps() {
        return this.$store.state.myKeeps
      }
    },
    components: {
      vaultview,
      keep
    },
    methods: {
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
      },
      getMyKeeps() {
        this.$store.dispatch('getMyKeeps')
      },
      addVault() {
        if (this.user.id) {
          this.$store.dispatch('addVault', this.newVault)
          this.newVault = {}
        }
      }
    }
  }

</script>

<style>


</style>