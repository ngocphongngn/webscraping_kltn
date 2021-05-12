<template>
  <div id="header" class="d-flex">
      <div class="fix-space"></div>
      <div class="contain-user">
        <div class="header-func">
          <a href="/introduce">Giới thiệu</a>
        </div>
        <div class="header-func">
          <a href="login">Đăng nhập</a>
        </div>
        <div class="header-func">
          <a href="/register">Đăng ký tài khoản</a>
        </div>
        <div class="header-func">
          <a href="">Tạo CV</a>
        </div>
        <div class="header-func">
          <a href="">Đăng việc làm lên JobSeeking</a>
        </div>
        <div class="header-func">
          <a href="">Trợ giúp</a>
        </div>

      </div>
      <div class="fix-space"></div>
  </div>
</template>
<script>
export default {
  props:{
    tittlename:{
      type: String,
    }
  },
  data() {
    return {
    };
  },
  methods: {

  },
  watch: {
  },
  computed:{
    getTitle(){
      return "hello";//this.$route.meta.title 
    }
  },
  created(){
  }
};
</script>
<style lang="scss" scoped>
@import "~@/styles/variables.scss";
.header-func{
  width: auto;
  padding-left: 20px;
  padding-right: 20px;
  border-right: 1px solid #ccc;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}
.header-func:last-child{
  border-right: none;
}
</style>
