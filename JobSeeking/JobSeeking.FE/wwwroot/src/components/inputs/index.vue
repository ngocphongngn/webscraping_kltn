<template>
  <div class="input-component">

    <div class="label-input" :class="className" type="label-top" v-if="type == 'label-top'">
      <div class="label mb-8">{{ labelForm}}</div>
      <el-input :placeholder="placeholder" v-model="input" :disabled="disabled" clearable></el-input>
    </div>
    <div
      class="label-input d-flex"
      :class="className"
      type="label-left"
      v-if="type == 'label-left'"
    >
      <div class="label pb-10">{{ labelForm}}</div>
      <el-input :placeholder="placeholder" :value="input" :disabled="disabled" clearable></el-input>
    </div>
    <span
        @mouseover = " hover = true "
        @mouseleave = " hover = false ">
    <!-- Field Input -->
    <el-input :id="id" :style="getStyleinput" v-if="type=='field-input'" v-model="getInput" :placeholder="placeholder" :disabled="disabled" ref="fieldinput" clearable></el-input>

    <!-- Field Input Icon -->
      <el-input id="input-icon" :style="getStyleinput" v-if="type=='input-icon'" v-model="getInput" :placeholder="placeholder"  :disabled="disabled" clearable>
        <i slot="prefix" :class="getIcon"></i>
      </el-input>


    <!-- Input có đuôi disabled -->
    <div id="input-append">
      <el-input :id="id" :style="getStyleinput" v-if="type=='input-append'"  v-model="getInput" :placeholder="placeholder"  :disabled="disabled"  clearable>
        <template slot="append">{{append}}</template>
      </el-input>
    </div>

    <!-- Input có phần đầu disabled -->
    <div id="input-prepend">
      <el-input :id="id" :style="getStyleinput" v-if="type=='input-prepend'"  v-model="getInput" :placeholder="placeholder"  :disabled="disabled"  clearable>
        <template slot="prepend">{{prepend}}</template>
      </el-input>
    </div>

    </span>
  </div>
</template>

<script>
import { convertName } from '@/utils/index.js';
export default {
  props: {
    id:{
      type: String,
      default: ""
    },
    placeholder: {
      // Thông tin placeholder của input
      type: String,
      default: ""
    },
    type: {
      // Dạng của input : 'label-top' Input có label nằm trên
      type: String,
      default: ""
    },
    disabled: {
      // Không cho nhập vào input hay không
      type: Boolean,
      default: false
    },
    labelForm: {
      // Tên của label
      type: String,
      default: ""
    },
    className: {
      type: String,
      default: "w-100"
    },
    /**
     * Truyền giá trị cho ô nhập liệu text
     */
    valueInput: {
      type: String,
      default: ""
    },
    /**
     * Truyền vào chiều dài của trường input
     */
    width:{
      type: String,
      default: "100%"
    },
    /**
     * Truyền vào đuôi append
     */
    append:{
      type: String,
      default: ""
    },
    /**
     * Truyền vào đầu prepend
     */
    prepend:{
      type: String,
      default: ""
    },
    /**
     * Có bật chế độ viết hoa chữ cái đầu không
     */
    isUpercasefirst:{
      type: Boolean,
      default: false
    },    
    /**
     * Truyền xuống tên icon thư viện element UI
     */
    iconel:{
      type: String,
      default: "el-icon-search"
    }
  },
  data() {
    return {
      // Giá trị của the input khi nhập vào
      hover: false,
      input: "",
    };
  },
  computed:{
    getStyleinput(){
      return "min-width: 100px; width: "+this.width +";"
    },
    getIcon(){
      return "el-input__icon "+this.iconel
    },
    getInput:{
      get(){
        return this.valueInput;
      },
      set(val){
        if(val != this.valueInput)
        if(this.isUpercasefirst==true) val = convertName(val)
          this.$emit("value",val);
      }
    }
  },
  methods:{
  },
  watch: {
    //Hiển thị message validate
    hover(val){
        this.$emit("hover",val)
    }
  },
  }
</script>

<style lang="scss">
#input-icon{
    padding-left: 40px;
    
    .el-input__icon{
      margin-left: 16px;
      padding-right: 16px;
      width: 16px;
      font-size: 13px;
    }
}
.el-input__prefix{
  left: 0px;
}
//Chỉnh sửa icon clear ô input
.el-input--medium .el-input__icon{
  // margin-left: 12px;
  // // margin-right: 8px;
  // line-height: 40px;
}
.el-input .el-input__clear{
  font-size: 18px;
}
</style>