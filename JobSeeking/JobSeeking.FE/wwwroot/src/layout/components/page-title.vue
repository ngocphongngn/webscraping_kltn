<template>
  <el-row v-if="haveData == false" :gutter="20" class="page-title" style="height: 52px;">
    <el-col class="d-flex" :span="16">
      <div id="img-back" class="pointer d-flex align-items-center" v-if="isBack" @click="goBack">
        <img src="@/icons/ico-expand.png" />
      </div>
      <div>
        <h1 style="font-size: 20px;">{{ title }}</h1>
      </div>
    </el-col>

    <el-col v-if="displayButtonInDetail()" class="button-area d-flex" :span="8" style="height:100%;align-items: center;">
      <slot />
    </el-col>
  </el-row>
  <!---->
  <el-row v-else :gutter="20" class="page-title d-flex" style="height: 68px;">
    <el-col class="d-flex" :span="16">
      <div id="img-back" class="pointer d-flex align-items-center" v-if="isBack" @click="goBack">
        <img src="@/icons/ico-expand.png" />
      </div>
      <div>
        <h1 style="font-size: 20px;">{{ title }}</h1>
      </div>
    </el-col>

    <el-col v-if="displayButtonInDetail()" class="button-area d-flex" :span="8" style="height:100%;align-items: center;">
      <slot />
    </el-col>
  </el-row>
  <!-- <div class="page-title d-flex">
    <div
      id="img-back"
      class="pointer d-flex align-items-center"
      v-if="isBack"
      @click="goBack"
    >
      <img src="@/icons/ico-expand.png" />
    </div>
    <h1 class="title-area" style="font-size: 20px;">{{ title }}</h1>
  </div> -->
</template>

<script>
// import Button from "@/components/buttons";

export default {
  data() {
    return {
      title: "",
      isBack: false,
    };
  },
  props: {
    haveData: Boolean // check xem có dữ liệu không
  },
  components: {
    // "m-btn": Button,
  },
  methods: {
    // quay trở lại trang trước đó
    goBack() {
      this.$router.go(-1);
    },

    //
    displayButtonInDetail() {
      let data = this.$store.getters.data;
      if (data.length != 0) {
        return true;
      } else {
        return false;
      }
    },

    /**
     * method xác định title tương ứng với xem, thêm, sửa
     * created by: N.T. Dũng 02.07.2020
     */
    // getMode(val) {
    //   switch (val) {
    //     // trường hợp xem
    //     case 1:
    //       return "Xem chi tiết " + sessionStorage.getItem("objectName");
    //     // trường hợp sửa
    //     case 2:
    //       return "Sửa chi tiết " + sessionStorage.getItem("objectName");
    //     case 3:
    //       return "Thêm mới chi tiết " + sessionStorage.getItem("objectName");
    //   }
    // },
  },
  watch: {
    $route: {
      handler(to) {
        // lấy tiêu đề trang
        this.title = sessionStorage.getItem("objectName");
        if (this.title == null || this.title == "undefined") {
          this.title = this.$route.meta.title;
        }
        this.isBack =
          typeof to.meta.isBack == "undefined" || to.meta.isBack == false
            ? false
            : true;
      },
      deep: true,
      immediate: true,
    },
  },
  created() {
    // this.title = this.$route.meta.title;
    this.isBack = this.$route.meta.isBack;
  },
};
</script>

<style lang="scss" scoped>
@import "~@/styles/variables.scss";

.page-title {
  background-color: black;
  margin: 0 -16px 0 -16px !important; 

  #img-back {
    img {
      padding: 0 10px 0 10px;
    }
  }

  .title-area {
    padding: 10px 0 25px 8px;
  }
}
</style>
