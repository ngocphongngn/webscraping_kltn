<template>
  <div @click="toggleClick" class="pointer button-toggle">
    <i v-if="this.$store.getters.sidebar.opened == true" class="img-toggle el-icon-arrow-left"/>
    <i v-else class="img-toggle el-icon-arrow-right"/>
  </div>
</template>

<script>
export default {
  name: 'Hamburger',
  props: {
    isActive: {
      type: Boolean,
      default: false
    }
  },
  data(){
    return{
      isOpen: true
    }
  },
  methods: {
    toggleClick() {
      this.$emit('toggleClick')
    }
  }
}
</script>

<style lang="scss">
@import "@/styles/variables.scss";
.img-toggle{
  width: 15px;
  font-size: 17px;
  font-weight: bold !important;
  color: $primary;
}

</style>
