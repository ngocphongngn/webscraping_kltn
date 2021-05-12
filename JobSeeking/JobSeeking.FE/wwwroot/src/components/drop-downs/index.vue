<template>
  <div class = "block" id="dropdown">
    <el-dropdown :style="getWidth" :trigger="trigger" id="drop-downs">
      <span class="el-dropdown-link">
        <i :class="icon"></i>
        <i :class="iconel" id="icon"></i>
        {{value}}
        <i class="el-icon-arrow-down el-icon--right icon"></i>
      </span>
      <el-dropdown-menu slot="dropdown" :style="getStyleMenu">
        <el-dropdown-item class="item" v-for="(item,index) in data" :key="index" v-on:click.native="changeValue(item)">{{item}}</el-dropdown-item>
      </el-dropdown-menu>
    </el-dropdown>
  </div>
</template>

<script>
/**
 * @author CVCuong
 * @CreatedDate 6/7/2020
 * Menu-drop-down dùng chung
 */
export default {
  //name: "DropDowns",
  props: {
    /**
     * Giá trị được chọn của Drop Downs
     */
    value:{
      type:String,
      default: "Chọn"
    },
    /**
     * Mảng các giá trị để lựa chọn
     */
    data:{
      type: Array,
      default: null
    },
    /**
     * Độ dài của drop downs. examp: {width: "110px"}
     */
    width:{
      type: String,
      default: "100px"
    },
    /**
     * Hiệu ứng active là click hoặc hover
     */
    trigger:{
      type: String,
      default: "click"
    },
    /**
     *  icon muốn truyền vào examp: "el-icon-edit"
     */
    icon:{
      type: String,
      default: null
    },
    /**
     * icon của thư viện element UI
     */
    iconel:{
      type: String,
      default: null
    }
  },
  data(){
    return{
    }
  },
  watch: {},
  computed:{
    getWidth(){
      return "width: "+this.width+";";
    },
    getStyleMenu(){
      return "height: 180px; overflow: auto; width: "+this.width+";";
    }
  },
  methods: {
    /**
     * Hàm thay đổi giá trị được chọn và gửi giá trị được chọn lên component cha
     */
    changeValue(item){
      this.value = item
      this.$emit("valuedropdown",this.value)
    },
  }
};
</script>

<style lang="scss">
// @import "@/styles/drop-downs.scss";
#dropdown{
  .el-icon--right{
    position: absolute;
    right: 10px;
    line-height: 40px;
  }
}
</style>