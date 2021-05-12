<template>
  <div>
    <el-table 
    :data="dataTable" 
    border width="100%" 
    :summary-method="getSummaries" 
    show-summary    
    v-for = "(item, index) in listColumn" :key="index"
    >
      <el-table-column  prop="item.propertyName" lable = "item.lable" width="item.width">
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
export default {
  name: "TableSummaryPaging",
  props: {
    dataTable: {
      type: Array,
      default: null
    },
    listColumn: {
      type: Array,
      default: null
    }
  },
  mounted: {},
  watch: {},
  methods: {
    /**
     * Hàm thực hiện tính tổng của từng cột trong bảng
     * created by vdthang 03.07.2020
     */
    getSummaries(param) {
      const { columns, data } = param;
      const sums = [];
      columns.forEach((column, index) => {
        if (index === 0) {
          sums[index] = "Tổng";
          return;
        }
        const values = data.map(item => Number(item[column.property]));
        if (!values.every(value => isNaN(value))) {
          sums[index] =
            "$ " +
            values.reduce((prev, curr) => {
              const value = Number(curr);
              if (!isNaN(value)) {
                return prev + curr;
              } else {
                return prev;
              }
            }, 0);
        } else {
          sums[index] = "--";
        }
      });

      return sums;
    }
  }
};
</script>

<style lang="scss" scoped>
</style>