<template>
  <div id="menu">
      <div class="menu-item menu-title">
        <el-tooltip v-if="this.$store.getters.sidebar.opened == false" effect="light" content="Danh mục việc làm" placement="right">
            <img class="icon-menu" src="@/assets/images/icon-jobseeking1.jpg" alt="">
        </el-tooltip>
        <div v-else>
            <img class="icon-menu" src="@/assets/images/icon-jobseeking1.jpg" alt="">
        </div>
        <span class="txt-menu text-father">Danh mục hệ thống</span>
      </div>
      <router-link class="menu-item" to="/vnindeed">
        <div class="active"></div>
        <el-tooltip v-if="this.$store.getters.sidebar.opened == false" effect="light" content="https://vn.indeed.com" placement="right">
            <img class="icon-menu" src="@/assets/images/indeed.jpg" alt="">
        </el-tooltip>
        <div v-else>
            <img class="icon-menu" src="@/assets/images/indeed.jpg" alt="">
        </div>
        <span class="txt-menu">https://vn.indeed.com</span>
      </router-link>
      <router-link class="menu-item" to="/topcv">
        <div class="active"></div>
        <el-tooltip v-if="this.$store.getters.sidebar.opened == false" effect="light" content="https://www.topcv.vn" placement="right">
            <img class="icon-menu" src="@/assets/images/topcv.png" alt="">
        </el-tooltip>
        <div v-else>
            <img class="icon-menu" src="@/assets/images/topcv.png" alt="">
        </div>
        <span class="txt-menu">https://www.topcv.vn</span>
      </router-link>
      
      <img v-if="this.$store.getters.sidebar.opened == true" class="footer" src=""/>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
    data(){
        return{
            widthscreen: 0,
        }
    },
    created() {
    },
    computed: {
        ...mapGetters([
            'sidebar'
        ])
    },
    methods:{
      toggleSideBar() {
        this.$store.dispatch('app/toggleSideBar')
      },
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/sidebar.scss";
.icon-menu{
  fill: #000;
}

.router-link-active .icon-menu{
  fill: #fff;
}

@media only screen and (max-height: 580px) {
  #menu .footer{
    display: none;
  }
}
</style>