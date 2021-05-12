<template>
  <div>
    <el-tree
      :data="data"
      :show-checkbox="showCheckbox"
      :node-key="nodeKey"
      :default-expand-all="expandAll"
      :default-checked-keys="checkKey"
      :props="defaultProps"
    ></el-tree>
  </div>
</template>

<script>
export default {
  name: "Tree",
  props: {
    showCheckbox: {
      type: Boolean,
      default: false
    },

    defaultProps: {
      type: Object,
      default: null
    },

    data: {
      type: Array,
      default: null
    },

    nodeKey: {
      type: String,
      default: "id"
    },

    expandAll:{
        type: Boolean,
        default: true
    },

    checkKey:{
        type: Array,
        default: null
    }
  }
};
</script>