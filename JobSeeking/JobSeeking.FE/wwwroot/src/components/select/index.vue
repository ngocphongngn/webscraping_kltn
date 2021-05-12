<template>
  <div>
    <!-- Selevt dropdown với label nằm trên  -->
    <div class="label-input" :class="className" type="label-top" v-if="type == 'label-top'">
      <div class="label mb-4">{{labelForm}}</div>
      <el-select
        clearable
        v-if="filterable==true"
        v-model="value "
        :placeholder="placeholder"
        filterable
        :popper-class="customSelect"
        :disabled="disabled"
      >
        <el-option
          v-for="(item, index) in list"
          :key="index"
          :label="item[label]"
          :value="item[field]"
          :class="{ 'el-icon-check': item[field]== value}"
        ></el-option>
      </el-select>
      <el-select
        clearable
        v-if="filterable==false"
        v-model="value "
        :placeholder="placeholder"
        :popper-class="customSelect"
        :disabled="disabled"
      >
        <el-option
          v-for="(item, index) in list"
          :key="index"
          :label="item[label]"
          :value="item[field]"
          :class="{ 'el-icon-check': item[field]== value}"
        ></el-option>
      </el-select>
    </div>

    <!-- Select dropdown voi label nằm trái -->
    <el-form-item
      clearable
      :label="labelForm"
      label-position="left"
      type="label-left"
      v-else-if="type == 'label-left'"
    >
      <el-select
        v-if="filterable==true"
        v-model="value"
        filterable
        :placeholder="placeholder"
        :popper-class="customSelect"
        :disabled="disabled"
      >
        <el-option
          v-for="(item, index) in list"
          :key="index"
          :label="item[label]"
          :value="item[field]"
          :popper-class="customSelect"
          :class="{ 'el-icon-check': item[field]== value}"
        ></el-option>
      </el-select>
      <el-select
        clearable
        v-if="filterable==false"
        v-model="value"
        :placeholder="placeholder"
        :popper-class="customSelect"
        :disabled="disabled"
      >
        <el-option
          v-for="(item, index) in list"
          :key="index"
          :label="item[label]"
          :value="item[field]"
          :popper-class="customSelect"
          :class="{ 'el-icon-check': item[field]== value}"
        ></el-option>
      </el-select>
    </el-form-item>

    <!-- Select không có label -->
    <div v-else-if="type == 'label-none'">
      <el-select
        clearable
        v-if="allowCreate==true && filterable==true"
        v-model="value"
        allow-create
        filterable
        :placeholder="placeholder"
        id="idSelect"
        :popper-class="customSelect"
        :disabled="disabled"
      >
        <el-option
          v-for="(item, index) in list"
          :key="index"
          :label="item[label]"
          :value="item[field]"
          :class="{ 'el-icon-check': item[field]== value}"
        ></el-option>
      </el-select>
      <el-select
        clearable
        v-if="allowCreate==false && filterable==true"
        v-model="value"
        :placeholder="placeholder"
        id="idSelect"
        filterable
        :popper-class="customSelect"
        :disabled="disabled"
      >
        <el-option
          v-for="(item, index) in list"
          :key="index"
          :label="item[label]"
          :value="item[field]"
          :class="{ 'el-icon-check': item[field]== value}"
        ></el-option>
      </el-select>
      <el-select
        clearable
        v-if="filterable==false"
        v-model="value"
        :placeholder="placeholder"
        id="idSelect"
        :popper-class="customSelect"
        :disabled="disabled"
      >
        <el-option
          v-for="(item, index) in list"
          :key="index"
          :label="item[label]"
          :value="item[field]"
          :class="{ 'el-icon-check': item[field]== value}"
        ></el-option>
      </el-select>
    </div>
  </div>
</template>

<script>
export default {
  name: "TableSummaryPaging",
  props: {
    // Danh sách các
    list: {
      type: Array,
      default: null,
    },
    // dạng label. top- bên trên, left- bên trái
    type: {
      type: String,
      default: "",
    },
    // label cho form
    labelForm: {
      type: String,
      default: "",
    },
    label: {
      // label sử dụng như tên
      type: String,
      default: "",
    },
    field: {
      // Property sử dụng là biến
      type: String,
      default: "",
    },
    placeholder: {
      type: String,
      default: "",
    },
    defaultNumber: {
      type: Number,
      default: null,
    },
    defaultString: {
      type: String,
      default: null,
    },
    customSelect: {
      type: String,
      default: "",
    },
    className: {
      type: String,
      default: "w-100",
    },
    disabled: {
      type: Boolean,
      default: false,
    },
    /**
     * Có cho phép nhập vào để lọc không
     */
    filterable: {
      type: Boolean,
      default: false,
    },
    /** Cho phép thêm trường */
    allowCreate: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      value: null,
    };
  },
  watch: {
    value(val) {
      this.$emit("value", val);
    },
    defaultString(val) {
      this.value = val;
    },
  },
  methods: {},
  mounted() {
    if (this.defaultString == null) {
      this.value = this.defaultNumber;
    } else {
      this.value = this.defaultString;
    }
  },
};
</script>

<style lang="scss">
</style>
