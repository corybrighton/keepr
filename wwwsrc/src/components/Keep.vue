<template>
  <div class="Keep col-xl-2 col-lg-3 col-md-4 col-sm-6 mt-3">
    <div class="card h-100">
      <img :src=this.kp.img class="card-img-top" @click="showModal">
      <div class="card-body" @click="showModal">
        <h5 class="card-title">
          {{this.kp.name}}
        </h5>
        <p>
          {{this.kp.description}}
        </p>
      </div>
      <div class="card-footer">
        <small class="text-muted justify-content-between d-flex">
          <!-- How many times the post has been viewed -->
          <div>
            <i class="fas fa-eye"></i>{{this.kp.views}}
          </div>
          <!-- Share post -->
          <div class="fb-share-button" data-href="https://developers.facebook.com/docs/plugins/" data-layout="button_count"
            data-size="small" data-mobile-iframe="true"><a target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2Fplugins%2F&amp;src=sdkpreparse"
              class="fb-xfbml-parse-ignore"><i class="fas fa-share" id="fb-root"></i></a>{{this.kp.shares}}
          </div>
          <!-- Dropdown list of vaults to add to -->
          <div class="dropup">
            <i class="fas fa-bookmark  dropdown-toggle" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true"
              aria-expanded="false">
              {{this.kp.keeps}}
            </i>
            <div v-if="user.id" class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton">
              <a v-for="(vault, index) in vaults" :key="index" class="dropdown-item" @click="addToVault(vault.id)">{{vault.name}}</a>
            </div>
            <div v-else class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton">
              <a class="dropdown-item" href="#">Please Log in</a>
            </div>
          </div>
          <!-- Trash -->
          <div v-if="view == 'dashboard'">
            <i class="fas fa-trash" @click="deleteKeep"></i>
          </div>
          <div v-else-if="view == 'vv'">
            <i class="fas fa-trash" @click="deleteKeepFromVault"></i>
          </div>
        </small>
      </div>
    </div>
    <keepModal v-show="isModalVisible" @close="closeModal" />
  </div>
</template>

<script>
  import keepModal from '@/components/KeepModal.vue'
  export default {
    name: 'Keep',
    props: ['kp', 'view', 'vaultId'],
    data() {
      return {
        isModalVisible: false
      }
    },
    components: {
      keepModal
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      showModal() {
        this.$store.dispatch('getKeep', this.kp.id)
        this.isModalVisible = true;
      },
      closeModal() {
        this.isModalVisible = false;
      },
      addToVault(id) {
        let vaultkeep = { UserId: "", VaultId: id, KeepId: this.kp.id }
        this.$store.dispatch('addToVault', vaultkeep)
      },
      deleteKeep() {
        this.$store.dispatch('deleteKeep', this.kp.id)
      },
      deleteKeepFromVault() {
        let vaultkeep = { UserId: "", VaultId: this.vaultId, KeepId: this.kp.id }
        this.$store.dispatch('deleteKeepFromVault', vaultkeep)
      }
    }
  }

</script>

<style>
  .card {
    color: black;
  }
</style>