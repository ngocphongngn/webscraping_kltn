<template>
  <div>

    <span
        @mouseover = " hover = true "
        @mouseleave = " hover = false ">
    <!-- Input number thường -->
    <el-input :id="id" class="input-number" v-if="type=='field-input'" v-model="getInput"  maxlength="18" :style="getStyleinput" :disabled="disabled"/>

    <!-- Field Input Icon -->
      <el-input id="input-icon" :style="getStyleinput" v-if="type=='input-icon'" maxlength="18" v-model.lazy="input" v-money="money" :disabled="disabled" >
        <i slot="prefix" class="el-input__icon el-icon-search"></i>
      </el-input>

    <!-- Input có đuôi disabled -->
    <div id="input-append" v-if="type=='input-append'">
      <el-input :id="id" class="input-number"  v-model="getInput" maxlength="18"  :style="getStyleinput" :disabled="disabled">
        <template slot="append">{{append}}</template>
      </el-input>
    </div>

    <!-- Input có phần đầu disabled -->
    <div id="input-prepend" v-if="type=='input-prepend'">
      <el-input :id="id" class="input-number"  v-model="input" maxlength="18"  :style="getStyleinput"  :disabled="disabled">
        <template slot="prepend">{{prepend}}</template>
      </el-input>
    </div>

    <!-- Input số điện thoại -->
    <el-input :id="id" class="input-number" v-if="type=='input-phoneNumber'"  v-model="input" maxlength="18"  :style="getStyleinput"/>
    </span>
  </div>
</template>

<script>
export default {
  name: "InputMoney",
  props: {
    /**
     * Truyền xuống id để check validate
     */
    id:{
      type: String,
      default: ""
    },
    /**
     * Truyền vào loại input cần dùng
     */
    type:{
      type: String,
      default: "field-input"
    },
    /**
     * Có disable trường nhập liệu không
     */
    disabled:{
      type: Boolean,
      default: false
    },
    /**
     * Giá trị ô nhập liệu
     */
    valueInput: {
      type: Number,
      default: null
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
  },
  data() {
    return {
      hover: false,
      input: 0,
    };
  },
  method:{
    check(ent){
      if(ent.which < 48 || ent.which > 57) return false
    }
  },
  computed:{
    getStyleinput(){
      return "min-width: 200px; width: "+this.width +";"
    },
    getInput:{
      get(){
        return this.valueInput.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')
      },
      set(val,){
        val=val.split("").filter((x) => x !== ",").join("");
        val=val.replace(/\D/g,'');
        this.$emit("value",val*1)
      },
    }
  },
  watch:{
    hover(val){
      this.$emit("hover",val)
    }
  },
};
</script>

<style lang="scss" scoped>
</style>