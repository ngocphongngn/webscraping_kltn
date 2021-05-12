<template>
  <div id="menu">
      <div class="menu-item menu-title">
        <el-tooltip v-if="this.$store.getters.sidebar.opened == false" effect="light" content="Danh mục quản trị" placement="right">
          <img class="icon-menu" src="@/assets/images/icon-jobseeking1.jpg" alt="">
        </el-tooltip>
        <div v-else>
            <img class="icon-menu" src="@/assets/images/icon-jobseeking1.jpg" alt="">
        </div>
        <span class="txt-menu text-father">Danh mục quản trị</span>
      </div>
      <router-link class="menu-item" to="/manage-data">
        <div class="active"></div>
        <el-tooltip v-if="this.$store.getters.sidebar.opened == false" effect="light" content="Quản lý dữ liệu" placement="right">
          <svg class="icon-menu">
            <!-- <use xlink:href="@/assets/images/Group17818.svg#svgh"></use> -->
          </svg>
        </el-tooltip>
        <div v-else>
          <svg class="icon-menu">
            <!-- <use xlink:href="@/assets/images/Group17818.svg#svgh"></use> -->
          </svg>
        </div>
        <span class="txt-menu">Quản lý dữ liệu</span>
      </router-link>
      <router-link class="menu-item" to="/manage-user">
        <div class="active"></div>
        <el-tooltip v-if="this.$store.getters.sidebar.opened == false" effect="light" content="Quản lý người dùng" placement="right">
          <svg class="icon-menu">
            <!-- <use xlink:href="@/assets/images/Group17843.svg#svgh"></use> -->
          </svg>
        </el-tooltip>
        <div v-else>
          <svg class="icon-menu">
            <!-- <use xlink:href="@/assets/images/Group17843.svg#svgh"></use> -->
          </svg>
        </div>
        <span class="txt-menu">Quản lý người dùng</span>
      </router-link>
      <router-link class="menu-item" to="/manage-system">
        <div class="active"></div>
        <el-tooltip v-if="this.$store.getters.sidebar.opened == false" effect="light" content="Quản lý hệ thống" placement="right">
          <svg class="icon-menu">
            <!-- <use xlink:href="@/assets/images/bank.svg#svgh"></use> -->
          </svg>
        </el-tooltip>
        <div v-else>
          <svg class="icon-menu">
            <!-- <use xlink:href="@/assets/images/bank.svg#svgh"></use> -->
          </svg>
        </div>
        <span class="txt-menu">Quản lý hệ thống</span>
      </router-link>
      <img v-if="this.$store.getters.sidebar.opened == true" class="footer" src=""/>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
    data(){
        return{
            widthscreen: 0,
        }
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
@import "@/styles/sidebar-admin.scss";
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