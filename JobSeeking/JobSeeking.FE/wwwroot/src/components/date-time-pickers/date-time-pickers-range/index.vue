<template>
  <div>
    <el-date-picker
      v-model="valueInput"
      type="daterange"
      :unlink-panels="unlinkPanels"
      :range-separator="rangeSeparator"
      :start-placeholder="startPlaceholder"
      :end-placeholder="endPlaceholder"
      :picker-options="pickerOptions"
      @change="getValue"
      format="dd/MM/yyyy"
      value-format="dd/MM/yyyy"
    ></el-date-picker>
  </div>
</template>

<script>
/**
 * Thêm component Date Picker Range
 * Author: NVHUNG - 6/7/2020
 */
export default {
  props: {
    /**
     * Giá trị
     */
    value: {
      type: Array,
      default: null,
    },
    unlinkPanels: {
      type: Boolean,
      default: false,
    },

    /**
     * Giá trị phân cách
     */
    rangeSeparator: {
      type: String,
      default: "--",
    },

    /**
     * Placeholder bắt đầu
     */
    startPlaceholder: {
      type: String,
      default: "Ngày bắt đầu",
    },

    /**
     * Placeholder kết thúc
     */
    endPlaceholder: {
      type: String,
      default: "Ngày kết thúc",
    },
  },
  data() {
    return {
      valueInput: this.value,

      /**
       * Tùy chọn ngày nhanh
       */
      pickerOptions: {
        shortcuts: [
          {
            text: "Tuần trước",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 7);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: "Tháng trước",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: "3 tháng trước",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 90);
              picker.$emit("pick", [start, end]);
            },
          },
        ],
      },
    };
  },
  methods: {
    getValue() {
      this.$emit("getValue", this.valueInput);
    },
  },
};
</script>
<style lang="scss">
@import "~@/styles/variables.scss";
.el-date-editor .el-range__icon{
  font-size: 16px;
  margin-left: 0px;
  color: $dark;
}
.el-range-editor--medium.el-input__inner{
  height: 40px;
}
</style>