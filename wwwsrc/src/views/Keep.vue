<template>
  <div class="keepView">
    <h3> {{keep.name}} </h3>
    <img :src=this.keep.img>
    <h4> {{keep.description}} </h4>
    <small class="justify-content-around d-flex">
      <i class="fas fa-eye"></i>{{keep.views}}
      <i class="fas fa-share"></i>{{keep.shares}}
      <i class="fas fa-bookmark"></i>{{keep.keeps}}
    </small>
  </div>
</template>

<script>
  export default {
    name: 'keepView',
    data() {
      return {

      }
    },
    computed: {
      keep() {
        return this.$store.state.keepView
      }
    },
    methods: {}
  }

</script>

<style>


</style>