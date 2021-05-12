<template>
  <div class="tbl-main" style="height:100%">
    <el-table
      ref="reftable"
      v-loading="loading"
      :style="getHeight()"
      :data="dataTable"
      width="100%"
      :class="classTable"
      :pageSizes="pageSizes"
      :summary-method="getSummaries"
      :show-summary="summary"
      highlight-current-row
      tooltip-effect="light"
      @row-click="handleRowClick"
      @row-dblclick="handleRowDBLClick"
      @selection-change="handleSelectionChange"
      @select-all="handleSelectAll"
    >
      <el-table-column v-if="haveCheck" type="selection" width="40"></el-table-column>
      <el-table-column
        v-for="(item, index) in listColumn"
        :key="index"
        :label="item.label"
        :tooltip="item.label"
        :width="item.width"
        :align="item.align"
        :min-width="item.minWidth"
        :prop="item.prop"
        :sortable="item.sortable"
        :show-overflow-tooltip="true"
      >

        <template slot="header" v-if="tooltip">
          <el-tooltip v-if="item.tooltip" class="item" effect="light" :content="item.tooltip" placement="top">
            <span>{{item.label}}</span>
          </el-tooltip>
        </template>
        <template slot-scope="scope">
          <span>{{ scope.row.SomeData }}</span>
        </template>
        <template slot-scope="{ row }">
          <!-- Dạng thường -->
            <span
              v-if="typeof item.type == 'undefinded' || item.type == ''"
            >{{ row[item.propertyName] }}</span>
          <!-- Dạng ngày -->
            <span v-if="item.type === 'date'">{{ formatDate(row[item.propertyName]) }}</span>
          <!-- Dạng số -->
          <span v-if="item.type === 'decimal'">{{ formatMoney(row[item.propertyName]) }}</span>
          <!-- Dạng kiểu hiển thị chip -->
          <el-tag
            v-if="item.type === 'chip'"
            
            :type="convertType(row[item.propertyName])"
          >{{ convertName(row[item.propertyName]) }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column  v-if="haveAction" split-button="false" align="right" width="60">
        <template class="action" slot-scope="{ row }">
          <span>
            <el-dropdown trigger="click" >
              <span>
                <img style="width: 20px; height: 20px;" src="@/icons/ico-more@2x.png"/>
              </span>
              <el-dropdown-menu slot="dropdown">
                <el-dropdown-item v-for="(item,index) in listaction" :key="index" @click.native="handleUpdate(row,item)">{{item}}</el-dropdown-item>
              </el-dropdown-menu>
            </el-dropdown>
          </span>
        </template>
      </el-table-column>
    </el-table>
    <div style="height:60px;padding:0px;background-color:$light-grey" v-if="havePagination">
      <pagination
        v-show="total > 0"
        :total="total"
        :page="listQuery.page"
        :limit.sync="listQuery.limit"
        @page="listQuery.page = $event"
        @pagination="getPagination"
        :layout="layoutPaging"
        :pageSizes="pageSizes"
        :typepage="typepage"
      />
    </div>
  </div>
</template>

<script>
import chipEnum from "@/enums/chipEnum.js";
import Pagination from "@/components/pagination";
import { formatMoney } from "@/utils/index.js";
import { formatDate } from "@/utils/index.js";

export default {
  name: "TableSummaryPaging",
  components: {
    pagination: Pagination
  },
  props: {
    pageSizes: {
      type: Array,
      default() {
        return [15, 25, 50, 100];
      }
    },
    layoutPaging: {
      type: String,
      default: "prev, pager, next, sizes"
    },
    reftable: {
      type: String,
      default: ""
    },
    dataTable: {
      type: Array,
      default: null
    },
    listColumn: {
      type: Array,
      default: null
    },
    haveCheck: {
      type: Boolean,
      default: false
    },
    havePagination: {
      type: Boolean,
      default: true
    },
    haveAction: {
      type: Boolean,
      default: true
    },
    chipArray: {
      type: String,
      default: null
    },
    summary: {
      type: Boolean,
      default: false
    },
    total: {
      type: Number,
      default: 0
    },
    loading: {
      type: Boolean,
      default: true
    },
    classTable: {
      type: String,
      default: "tbl-summary"
    },
    positionSummary: {
      type: Object,
      default: null
    },
    tooltip: {
      type: Boolean,
      default: false
    },
    /**
     * Danh sách truyền vào cột hành động
     */
    listaction:{
      type: Array,
      default: null
    },
    /**
     *Truyền xuống tên loại bảng 
     */
    typepage:{
      type: String,
      default: null
    }
  },
  data() {
    return {
      listQuery: {
        page: 1,
        limit: 10,
        importance: undefined,
        title: undefined,
        type: undefined,
        sort: "+id"
      },
      selection: []
    };
  },
  watch: {},
  methods: {
    /**
     * Hàm thực hiện handle sự kiện dbClick
     * created by vdthang 04.07.2020
     */
    handleRowDBLClick(dataRow) {
      this.$emit("handleRowDBLClick", dataRow);
    },
    /**
     * Hàm thực hiện click một row
     */
    handleRowClick(data) {
      this.$refs.reftable.setCurrentRow(data);
      this.$emit("handleRowClick", data);
    },

    /**
     * Hàm thực hiện tính tổng của từng cột trong bảng
     * created by vdthang 03.07.2020
     */
    getSummaries(param) {
      var sums = [];
      var datas = param.data;
      var positionSummary = this.positionSummary.TextSummary;
      var listSum = this.positionSummary.Summary;
      if (positionSummary)
        sums[positionSummary.TextPosition] = positionSummary.TextString;

      //Thực hiện duyệt từng cột bản ghi tính tổng
      listSum.forEach((item,index) => {
        if(index == 0) sums[item.PropertyIndex] = "Tổng"
        else{
          sums[item.PropertyIndex] = 0;
          datas.forEach(data => {
            sums[item.PropertyIndex] += data[item.PropertyName];
          });
          sums[item.PropertyIndex] = this.formatMoney(sums[item.PropertyIndex]); 
        }
      });
      return sums;
    },

    /**
     * Hàm update hàng trong bảng,
     *
     */
    handleUpdate(row,name) {
      this.$emit("row-action", {row,name});
    },

    /**
     * Chuyen sang ten của chip
     */
    convertName(value) {
      var temp = chipEnum[this.chipArray];
      for (let i = 0; i < temp.length; i++) {
        if (temp[i].value == value) {
          return temp[i].name;
        }
      }
    },

    /**
     * Chhuyeenr sang type của chip
     */
    convertType(value) {
      var temp = chipEnum[this.chipArray];
      for (let i = 0; i < temp.length; i++) {
        if (temp[i].value == value) {
          return temp[i].type;
        }
      }
    },

    /**
     * Hàm xét chiều cao cho table dựa vào có hoặc không có phân trang
     */
    getHeight() {
      if (this.havePagination) {
        return "height:calc(100% - 60px); border-top-left-radius: 8px; border-top-right-radius: 8px;";
      } else return "height:100%; border-radius: 8px;";
    },

    /**
     * Handle select checkbox
     */
    handleSelectionChange(val) {
      this.$emit("handleSelectionChange", val);
    },

    /**
     * Handle select all
     */
    handleSelectAll(val) {
      this.$emit("handleSelectAll", val);
    },

    /**
     * Lấy thông tin phân trang
     */
    getPagination(val) {
      this.$emit("pagination", val);
    },

    /**
     * Hàm thực hiện format cột hiển thị số
     */
    formatMoney(data) {
      return formatMoney(data, ".");
    },

    /**
     * Hàm định dạng số tiền
     */
    formatDate(data) {
      return formatDate(data, "dd/mm/yyyy");
    },

    /**
     * Hàm bỏ chọn all checkbox
     */
    clearSelection(rows) {
      if (rows) {
        rows.forEach(row => {
          this.$refs.reftable.toggleRowSelection(row);
        });
      } else {
        this.$refs.reftable.clearSelection();
      }
    }
  }
};
</script>
<style lang="scss">
@import "@/styles/variables.scss";
.tbl-main .el-dropdown{
  border: none;
  right: 6px;
  top: 2px;
  height: 24px !important;
  width: 24px !important;
  // &:hover{
  //   background-color: $bg-color-3;
  // }
}
.el-table .el-dropdown{
  padding-left: 0px !important;
  padding-right: 2px !important;
  img{
    border-radius: 5px;
    &:hover{
      background-color: $bg-color-3 !important;
    }
  }
}
</style>