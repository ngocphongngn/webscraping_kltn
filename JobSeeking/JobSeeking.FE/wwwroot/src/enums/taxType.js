export default {
  TAX_TYPE: [
    {
      NAME: "Thu nhập từ tiền lương, tiền công",
      STYLE: "Tiền lương tiền công",
      VALUE: 1,
      GROUPTYPE:5
    },
    {
      NAME:"Thu nhập từ tiền phí mua bảo hiểm nhân thọ, bảo hiểm không bắt buộc khác của doanh nghiệp bảo hiểm không thành lập tại Việt Nam",
      STYLE: "Tiền phí mua bảo hiểm",
      VALUE: 2,
      GROUPTYPE:5

    },
    {
      NAME: "Thu nhập từ hoạt động đại lý xổ số",
      STYLE: "Hoạt động đại lý xổ số",
      VALUE: 3,
      GROUPTYPE:1

    },
    {
      NAME: "Thu nhập từ hoạt động đại lý bảo hiểm",
      STYLE: "Hoạt động đại lý xổ số",
      VALUE: 4,
      GROUPTYPE:1

    },
    {
      NAME: "Thu nhập từ hoạt động bán hàng đa cấp",
      STYLE: "Hoạt động đại lý bảo hiểm",
      VALUE: 5,
      GROUPTYPE:1

    },
    {
      NAME: "Thu nhập từ tiền phí tích lũy bảo hiểm nhân thọ, bảo hiểm không bắt buộc khác",
      STYLE: "Tiền phí tích lũy bảo hiểm",
      VALUE: 6,
      GROUPTYPE:1

    },
  
    // Tạm thời chỉ thêm được 6 loại bảng tính thuế này
    
    // {
    //   NAME: "Thu nhập từ đầu tư vốn",
    //   VALUE: 7,
    //   GROUPTYPE:6

    // },
    // {
    //   NAME: "Thu nhập từ chuyển nhượng chứng khoán",
    //   VALUE: 8,
    //   GROUPTYPE:6

    // },
    // {
    //   NAME: "Thu nhập từ trúng thưởng",
    //   VALUE: 9,
    //   GROUPTYPE:6

    // },
    // {
    //   NAME: "Thu nhập từ bản quyền, nhượng quyền thương mại",
    //   VALUE: 10,
    //   GROUPTYPE:6

    // },
    // {
    //   NAME: "Thu nhập từ kinh doanh của cá nhân không cư trú",
    //   VALUE: 11,
    //   GROUPTYPE:6

    // },
    // {
    //   NAME: "Thu nhập từ chuyển nhượng vốn của cá nhân không cư trú",
    //   VALUE: 12,
    //   GROUPTYPE:6

    // },
    // {
    //   NAME: "Thu nhập từ cho thuê tài sản",
    //   VALUE: 13,
    //   GROUPTYPE:2

    // },  
  ],

/**
 * Hàm thự hiện tìm name qua value (Lấy tên rút gọn)
 * @param {value} value 
 */
  findInArray(value){
    for(var i in this.TAX_TYPE){
      if(this.TAX_TYPE[i].VALUE == value){
        return this.TAX_TYPE[i].STYLE;
      }
    }
  },
  findGroupInArray(val){// tìm grouptype dựa vào value(lấy mã nhóm tờ khai)
    for(var i in this.TAX_TYPE){
      if(this.TAX_TYPE[i].VALUE == val){
        return this.TAX_TYPE[i].GROUPTYPE
      }
    }
  }
};
