<template>
  <el-popconfirm
    :confirmButtonText="confirmText"
    :cancelButtonText="cancelText"
    :icon="icon"
    :iconColor="iconColor"
    :title="title"
    :hideIcon="hideIcon"
    @onConfirm="confirm"
    @onCancel="cancel"
  >
    <el-button slot="reference">{{ text }}</el-button>
  </el-popconfirm>
</template>

<script>
/**
 * Tạo components popconfirm
 * NVHung (10/7/2020)
 */
export default {
  props: {
    text: String, // Text của nút
    title: String, // Tiều đề popconfirm
    confirmText: String, // Tiêu đề xác nhận
    cancelText: String, // Tiêu đề hủy
    icon: String, // Custom icon
    iconColor: String, // Màu icon
    hideIcon: {
      type: Boolean, // Ẩn icon
      default: false,
    },
  },
  methods: {
    // Sự kiện xác nhận popconfirm
    confirm() {
      this.$emit("confirm", true);
    },

    // Sự kiện hủy popconfirm
    cancel() {
      this.$emit("confirm", false);
    },
  },
};
</script>

<style></style>
