<template>
  <div id="app">
    <router-view />
    <error-log
      v-if="isError"
      :message="message"
      :decription="decription"
      :dialogFormVisible="isError"
      :close="closeError"
      icon="img-warning.png"
    ></error-log>
  </div>
</template>
<script>
import ErrorLog from "@/components/dialog/modules/message.vue";
// import Cookies from "js-cookie";
// import Vueroute from "vue-router";
export default {
  name: "App",
  components: {
    "error-log": ErrorLog,
  },
  data() {
    return {
      //organizationId: "2ef7003b-c2a3-11ea-9491-5203cfc96bc9",
      abc: 0,
      message: "Hệ thống đang gặp lỗi",
      decription: "Sorry and wait me a little !",
      windowHeight: 0,
      windowWidth: 0,
    };
  },
  watch: {
    windowWidth(val) {
      if (val < 1366) {
        if (this.$store.getters.sidebar.opened == true)
          this.$store.dispatch("app/toggleSideBar");
      } else {
        if (this.$store.getters.sidebar.opened == false)
          this.$store.dispatch("app/toggleSideBar");
      }
    },
  },
  computed: {
    isError() {
      var logs = this.$store.getters.logs;
      if (typeof logs != "undefined") {
        if (logs.length > 0) return true;
        else return false;
      } else return false;
    },
  },
  methods: {
    /**
     * Sự kiên close modal
     */
    closeError() {
      this.$store.dispatch("errorLog/clearErrorLog");
    },
    handleResize() {
      this.windowHeight = screen.height;
      this.windowWidth = window.innerWidth;
    },
  },
  created() {
    window.addEventListener("resize", this.handleResize);
  },
};
</script>