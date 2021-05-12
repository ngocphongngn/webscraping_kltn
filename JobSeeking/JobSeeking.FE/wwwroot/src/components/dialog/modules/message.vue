<template>
  <div>
    <el-dialog
      :title="textMap[dialogStatus]"
      :visible.sync="dialog"
      @close="getClose"
      :width="width"
    >
      <div class="d-flex">
        <img :src="getIcon('img',icon)" :alt="icon" width="80px" height="80px" />
        <div style="padding:10px 10px">
          <b>{{message}}</b>
          <br />
          <div style="margin-top:20px;">{{decription}}</div>
        </div>
      </div>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="close">Xác nhận</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import MixinIco from "@/utils/icon.js";

export default {
  props: {
    dialogFormVisible: {
      type: Boolean,
      default: false
    },
    dialogStatus: {
      type: String,
      default: ""
    },
    message: {
      type: String,
      default: ""
    },
    close: {
      type: Function,
      default: () => {}
    },
    icon: {
      type: String,
      default: ""
    },
    decription: {
      type: String,
      default: ""
    },
    width: {
      type: String,
      default: "25%"
    }
  },
  mixins: [MixinIco],
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
  computed: {
    iconBuf() {
      return this.getIcon("icon", this.icon);
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
    },
    // getIcoMessage() {
    //   return this.getIcon("icon", this.icon);
    // },
    /**
     * Sự kiện nhấn nút xác nhận message
     */
    emitClose() {
      this.dialog = false;
      this.$emit("close", false);
    }
  },
  created() {
    this.dialog = this.dialogFormVisible;
  }
};
</script>

<style>
</style>