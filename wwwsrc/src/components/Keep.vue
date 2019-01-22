<template>
  <div class="Keep col-xl-2 col-lg-3 col-md-4 col-sm-6 mt-3" @click="getKeep()">
    <div class="card h-100">
      <img :src=this.kp.img class="card-img-top">
      <div class="card-body">
        <h5 class="card-title">
          {{this.kp.name}}
        </h5>
        <p>
          {{this.kp.description}}
        </p>
      </div>
      <div class="card-footer">
        <small class="text-muted justify-content-between d-flex">
          <i class="fas fa-eye"></i>{{this.kp.views}}
          <i class="fas fa-share"></i>{{this.kp.shares}}
          <i class="fas fa-bookmark"></i>{{this.kp.keeps}}
        </small>
      </div>

    </div>
  </div>
</template>

<script>
  export default {
    name: 'Keep',
    props: ['kp'],
    data() {
      return {

      }
    },
    computed: {},
    methods: {
      getKeep() {
        this.$store.dispatch('getKeep', this.kp.id)
      }
    }
  }

</script>

<style>


</style>