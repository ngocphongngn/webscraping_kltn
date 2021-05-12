<template>
  <div :class="{ hidden: hidden }"  class="pagination-container">
    <el-pagination
      :id="getPage"
      :background="background"
      :current-page.sync="currentPage"
      :page-size.sync="pageSize"
      :layout="layout"
      :page-sizes="pageSizes"
      :total="total"
      v-bind="$attrs"
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
    />
    <div class="page-show">Hiển thị {{startindex}} - {{startend}}/{{getTotal}} {{getTypepage}}</div>
    <el-button :id="getBackdb" class="btn-backdb" @click="backstart" :style="getStyleback">
      <img class="img-backbd" src="@/icons/Group 16785@2x.png"/>
    </el-button>
    <el-button :id="getNextdb" class="btn-nextdb" @click="nextend" :style="getStylenext">
      <img class="img-nextbd" src="@/icons/Group 17472@2x.png"/>
    </el-button>
  </div>
</template>

<script>
import { scrollTo } from "@/utils/scroll-to";
/**
 * Base chung phân trang cho table
 * Created by: CVCuong
 */
export default {
  name: "Pagination",
  props: {
    /**
     * Tổng bản ghi
     */
    total: {
      required: true,
      type: Number
    },
    /**
     * Trang hiện tại
     */
    page: {
      type: Number,
      default: 1
    },
    /**
     * Số bản ghi trên 1 trang
     */
    pageSizes: {
      type: Array,
      default() {
        return [15, 25, 50, 100];
      }
    },
    /**
     * Thứ tự sắp xếp các thành phần
     */
    layout: {
      type: String,
      default: "sizes, prev, pager, next, jumper"
    },
    background: {
      type: Boolean,
      default: true
    },
    autoScroll: {
      type: Boolean,
      default: true
    },
    hidden: {
      type: Boolean,
      default: false
    },
    /**
     * tên loại thành phần được phân trang
     */
    typepage:{
      type: String,
      default: "bảng tính thuế"
    }
  },
  data(){
    return{
      limit: 15
    }
  },
  computed: {
    currentPage: {
      get() {
        return this.page;
      },
      set(val) {
        this.$emit("page", val);
      }
    },
    pageSize:{
      get() {
        return this.limit;
      },
      set() {
      }
    },
    /**
     * Tính toán số thứ tự bản ghi đầu tiên hiển thị
     */
    startindex(){
      if(this.total == 0) return 0
      else return this.limit*(this.page-1)+1;
    },
    /**
     * Tính toán số thứ tự bản ghi cuối hiển thị
     */
    startend(){
      if(this.total ==0) return 0
      var number = this.total/(this.page*this.limit)
      if(number >= 1) return this.limit*this.page
      else{
        number = this.total-(this.page-1)*this.limit
        return this.limit*(this.page-1)+number;
      }
    },
    getTotal(){
      return this.total
    },
    getTypepage(){
      return this.typepage
    },
    /**
     * Xử lý khi ở trang đầu thì không click vào nút nhảy về đầu trang được
     */
    getStyleback(){
      if(this.page==1) return "cursor: no-drop;"
      return ""
    },
    /**
     * Xử lý khi ở trang cuối thì không click vào nút nhảy đến cuối trang
     */
    getStylenext(){
      if(((this.page)*this.limit) > this.total) return "cursor: no-drop;"
      return ""
    },
    /**
     * Xử lý hiển thị các nút với số trang tương ứng
     */
    getPage(){
      if((this.total/this.limit)<=1) return "page1"
      else if((this.total/this.limit)<=2) return "page2"
      else if((this.total/this.limit)<=3) return "page3"
      else if((this.total/this.limit)<=4) return "page4"
      else if((this.total/this.limit)<=5) return "page5"
      else if((this.total/this.limit)<=6) return "page6"
      else if((this.total/this.limit)<=7) return "page7"
      else{
        return "page8"
      }
    },
    getBackdb(){
      if((this.total/this.limit)<=1) return "back1"
      else if((this.total/this.limit)<=2) return "back2"
      else if((this.total/this.limit)<=3) return "back3"
      else if((this.total/this.limit)<=4) return "back4"
      else if((this.total/this.limit)<=5) return "back5"
      else if((this.total/this.limit)<=6) return "back6"
      else if((this.total/this.limit)<=7) return "back7"
      else{
        return "back8"
      }
    },
    getNextdb(){
      if((this.total/this.limit)<=1) return "next1"
      else if((this.total/this.limit)<=2) return "next2"
      else if((this.total/this.limit)<=3) return "next3"
      else if((this.total/this.limit)<=4) return "next4"
      else if((this.total/this.limit)<=5) return "next5"
      else if((this.total/this.limit)<=6) return "next6"
      else if((this.total/this.limit)<=7) return "next7"
      else{
        return "next8"
      }
    }
  },
  methods: {
    backstart(){
      this.$emit("page", 1);
      this.$emit("pagination", { page: 1, limit: this.limit });
    },
    nextend(){
      var number = this.total/this.limit
      number = parseInt(number) + 1
      this.$emit("page", number);
      this.$emit("pagination", { page: number, limit: this.limit });
    },
    handleSizeChange(val) {
      this.page = 1;
      this.limit = val
      this.$emit("pagination", { page: this.currentPage, limit: val });
      if (this.autoScroll) {
        scrollTo(0, 800);
      }
    },
    handleCurrentChange(val) {
      this.$emit("pagination", { page: val, limit: this.limit });
      if (this.autoScroll) {
        scrollTo(0, 800);
      }
    }
  }
};
</script>

<style lang="scss">
@import "@/styles/variables.scss";
.pagination-container {
  position: relative;
  background: #fff;
  display: flex !important;
  align-items: center;
  margin: 0px;
  height: 100%;
  #page1{
    .btn-prev{
      transform: translateX(-80px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(35px) translateY(-50%);
    }
  }
  #back1{
    transform: translateX(-125px);
  }
  #next1{
    transform: translateX(80px);
  }
  #page2{
    .btn-prev{
      transform: translateX(-100px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(55px) translateY(-50%);
    }
  }
  #back2{
    transform: translateX(-145px);
  }
  #next2{
    transform: translateX(100px);
  }
  #page3{
    .btn-prev{
      transform: translateX(-120px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(75px) translateY(-50%);
    }
  }
  #back3{
    transform: translateX(-165px);
  }
  #next3{
    transform: translateX(120px);
  }
  #page4{
    .btn-prev{
      transform: translateX(-140px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(95px) translateY(-50%);
    }
  }
  #back4{
    transform: translateX(-185px);
  }
  #next4{
    transform: translateX(140px);
  }
  #page5{
    .btn-prev{
      transform: translateX(-160px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(115px) translateY(-50%);
    }
  }
  #back5{
    transform: translateX(-205px);
  }
  #next5{
    transform: translateX(160px);
  }
  #page6{
    .btn-prev{
      transform: translateX(-190px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(145px) translateY(-50%);
    }
  }
  #back6{
    transform: translateX(-230px);
  }
  #next6{
    transform: translateX(185px);
  }
  #page7{
    .btn-prev{
      transform: translateX(-210px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(165px) translateY(-50%);
    }
  }
  #back7{
    transform: translateX(-250px);
  }
  #next7{
    transform: translateX(205px);
  }
  #page8{
    .btn-prev{
      transform: translateX(-235px) translateY(-50%) !important;
    }
    .btn-next{
      transform: translateX(190px) translateY(-50%);
    }
  }
  #back8{
    transform: translateX(-275px);
  }
  #next8{
    transform: translateX(230px);
  }
}
.pagination-container.hidden {
  display: none;
}
.page-show{
  position: absolute;
  left: 16px;
}
.img-backbd{
  width: 16px;
  height: 16px;
}
.btn-backdb{
  transition: none;
  position: absolute;
  left: 50%;
  width: 36px;
  height: 36px;
  padding: 10px;
  background-color: $white;
  border: none;
  &:hover{
    background-color: $bg-color-3;
  }
}
.img-nextbd{
  width: 16px;
  height: 16px;
}
.btn-nextdb{
  transition: none;
  position: absolute;
  left: 50%;
  width: 36px;
  height: 36px;
  padding: 10px;
  background-color: $white;
  border: none;
  &:hover{
    background-color: $bg-color-3;
  }
}
</style>
