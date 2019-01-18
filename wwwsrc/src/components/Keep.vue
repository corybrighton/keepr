<template>
  <div class="Keep card col-2">
    <img :src=this.kp.img class="card-img-top">
    <div class="card-body">
      <h5 class="card-title">
        {{this.kp.name}}
      </h5>
      {{this.kp.description}}
      <div class="card-footer">
        <small>
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
    methods: {}
  }

</script>

<style>


</style>