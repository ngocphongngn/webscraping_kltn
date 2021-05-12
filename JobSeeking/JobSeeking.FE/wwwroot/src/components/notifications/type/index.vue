<template>
  <div>
  </div>
</template>
<script>
export default {
    name: "Notification",
    methods: {
    /**
     * Hiển thị thông báo thành công
     */
    success: function(title,content){
      this.$notify({
        title: title,
        message: content,
        type: "success",
        customClass: 'notification-success',
        duration: 2000
      });
    },
    /**
     * Hiển thị thông báo cảnh báo
     */
    warning: function(title,content){
      this.$notify({
        title: title,
        message: content,
        type: "warning",
        customClass: 'notification-warning',
        duration: 2000
      });
    },
    /**
     * Hiển thị thông báo lỗi
     */
    error: function(title,content) {
      this.$notify({
        title: title,
        message: content,
        type: "error",
        customClass: 'notification-error',
        duration: 2000
      });
    },
    /**
     * Hiển thị thông tin
     */
    info: function(title,content) {
      this.$notify({
        title: title,
        message: content,
        type: "info",
        customClass: 'notification-info',
        duration: 2000
      });
    },
  },
};
</script>

<style lang="scss" scoped></style>
