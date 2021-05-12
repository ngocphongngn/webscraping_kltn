<template>
  <div>
    <el-dialog :title="textMap[dialogStatus]" :visible.sync="dialog" @close="getClose">
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false">Cancel</el-button>
        <el-button type="primary" @click="dialogStatus==='create'?createData():updateData()">Confirm</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
export default {
  props: {
    dialogFormVisible: {
      type: Boolean,
      default: false
    },
    dialogStatus: {
      type: String,
      default: ""
    }
  },
  watch: {
    dialogFormVisible(val) {
      this.dialog = val;
    },
    dialog(val) {
      if (val == false) {
        this.$emit("close-dialog", false);
      }
    }
  },

  data() {
    return {
      textMap: {
        update: "Thêm mới người nộp thuế",
        create: "Sửa người nộp thuế"
      },
      dialog: false
    };
  },
  methods: {
    getClose(done) {
      this.$emit("close-dialog", done);
    }
  },
  created() {
    this.dialog = this.dialogFormVisible;
  }
};
</script>

<style>
</style>