<template>
  <div class="input-dropdown">
    <el-input placeholder="Please input" v-model="model" class="input-with-select">
      <el-select v-model="select" slot="append" placeholder="Select" style="max-width:552px">
        <el-option v-for="(i, item) in list" :key="item" :label="i[label]" :value="i[feild]"></el-option>
      </el-select>
    </el-input>
  </div>
</template>

<script>
export default {
  props: {
    list: {
      type: Array,
      default: null
    },
    label: {
      // label sử dụng như tên
      type: String,
      default: ""
    },
    field: {
      // Property sử dụng là biến
      type: String,
      default: ""
    }
  },
  data() {
    return {
      model: ""
    };
  },
  watch: {
    model(val) {
      this.$emit("input-model", val);
    }
  }
};
</script>

<style></style>
