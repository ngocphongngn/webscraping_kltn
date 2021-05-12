<template>
  <div class="message-boxs">
    <el-button type="success" @click="openMessageBox">message-box</el-button>
  </div>
</template>

<script>
export default {
  name: "MessageBoxs",
  props: {
    nameTile: String, // Tiêu đề message box
    content: String, // Nội dung thông báo chung
    objectName: String // Tên đối tượng muốn thông báo đến
  },
  watch: {},
  methods: {
    openMessageBox() {
      const h = this.$createElement;
      this.$msgbox({
        title: this.nameTile,
        // tùy chỉnh nội dung thông báo
        message: h("div", null, [
          h("p", null),
          h("span", null, this.content),
          h("i", { style: "color: teal" }, this.objectName)
        ]),
        showCancelButton: true, // true-hiển thị/false-ẩn button cancel
        confirmButtonText: "Đồng ý", // nội dung button OK
        cancelButtonText: "Hủy" // nội dung button cancel
      }).then(action => {
        // xử lý event khi click vào button OK
        this.$message({
          type: "success",
          message: "action: " + action
        });
      });
    }
  }
};
</script>

<style lang="scss" scoped>
</style>