<template>
  <transition name="modal-fade">
    <div class="modal-backdrop">
      <div class="modal">
        <header class="modal-header">
          <slot name="header">
            {{keep.name}}
          </slot>
        </header>
        <section class="modal-body">
          <slot name="body">
            <img :src=this.keep.img class="modal-img">
          </slot>
        </section>
        <footer class="modal-footer">
          <slot name="footer">
            <p>
              {{keep.description}}
            </p>
            <div><i class="fas fa-eye"></i> {{keep.views}} </div>
            <div><i class="fas fa-share"></i> {{keep.shares}} </div>
            <div> <i class="fas fa-bookmark"></i>{{keep.keeps}} </div>
            <button class="btn-green" @click="close">Close</button>
          </slot>
        </footer>
      </div>
    </div>
  </transition>

</template>

<script>
  export default {
    name: 'keepModal',
    data() {
      return {

      }
    },
    computed: {
      keep() {
        return this.$store.state.keepView
      }
    },
    methods: {
      close() {
        this.$emit('close')
      }
    }
  }

</script>

<style>
  .modal-fade-enter,
  .modal-fade-leave-active {
    opacity: 0;
  }

  .modal-fade-enter-active,
  .modal-fade-leave-active {
    transition: opacity .5s ease
  }

  .modal-img {
    border-radius: 8px;
    width: 100%;
    max-width: 525px;
    max-height: 350px;
  }

  .modal-backdrop {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.3);
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .modal {
    background: #FFFFFF;
    top: auto;
    left: auto;
    width: 50%;
    height: 50%;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
  }

  .modal-header,
  .modal-footer {
    padding: 15px;
    display: flex;
  }

  .modal-header {
    border-bottom: 1px solid #eeeeee;
    color: #4AAE9B;
    justify-content: space-between;
  }

  .modal-footer {
    border-top: 1px solid #eeeeee;
    justify-content: flex-end;
  }

  .modal-body {
    position: relative;
    padding: 20px 10px;
  }

  .btn-close {
    border: none;
    font-size: 20px;
    padding: 20px;
    cursor: pointer;
    font-weight: bold;
    color: #4AAE9B;
    background: transparent;
  }

  .btn-green {
    color: white;
    background: #4AAE9B;
    border: 1px solid #4AAE9B;
    border-radius: 2px;
  }
</style>