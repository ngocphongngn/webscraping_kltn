<template>
  <div class="tool-bar d-flex align-items-center pl-10">
    <div class="mr-10">
      Đã chọn <b>{{ total }}</b>
    </div>
    <div class="mr-10">
       <el-button type="text" @click="disableAllSelected" class="unselected">Bỏ chọn</el-button>
    </div>
    <m-btn
      v-for="(i, index) in options"
      :type="i.type"
      :key="index"
      :name="i.name"
      class="mr-10"
      :id="'id' +index"
      :icon="i.icon"
      :disabled="i.disabled"
      :handleClick="clickButton"
    ></m-btn>
  </div>
</template>

<script>
import Button from "@/components/buttons";
export default {
  props: {
    options: {
      type: Array,
      default: null,
    },
    total: {
      type: Number,
      default: 0,
    }
  },
  data() {
    return {
    };
  },
  watch: {
    options(val) {
      console.log(val)
    },

  },
  components: {
    "m-btn": Button,
  },
  methods: {
    /**
     * Hàm xử lí sự kiện khi ấn vào nút
     * @param: event
     * Output: truyền lên Component cha tên button vừa click vào
     * Auth: NTNgoc
     * Created date: 10/7/2020 
     */
    clickButton($event){
      this.$emit('clickButton',$event.target.textContent);
    },
    disableAllSelected(){
      this.$emit('disableAllSelected')
    }
  }
};
</script>

<style scoped>
.tool-bar.d-flex.align-items-center.pl-10{
  border: 1px solid #EBEEF5;
   border-bottom:none;
    border-top-left-radius: 7px;
    border-top-right-radius: 7px;
    padding: 6px 0 6px 8px;
    background-color: #e5e5e5
}
</style>
