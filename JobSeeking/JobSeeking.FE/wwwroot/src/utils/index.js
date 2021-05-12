/**
 * @param {*} date Ngày muốn định dạng
 * @param {*} formatType Kiểu định dạng = {"dd/mm/yyyy", "yyyy/mm/dd", "dd-mm-yyyy", "yyyy-mm-dd"}
 * Description: Hàm format ngày theo dd/mm/yyyy | yyyy/mm/dd | dd-mm-yyyy | yyyy-mm-dd
 */
const formatDate = function(date, formatType) {
  if (date) {
    var dt = date.slice(0, 10);
    var splitDate = [];

    if (dt.indexOf("/") != -1) splitDate = dt.split("/");
    else if (dt.indexOf("-") != -1) splitDate = dt.split("-");
    else return null;

    var year = splitDate[0].length == 4 ? splitDate[0] : splitDate[2];
    var month = splitDate[1];
    var day = splitDate[0].length == 4 ? splitDate[2] : splitDate[0];

    if (formatType == "dd/mm/yyyy") return `${day}/${month}/${year}`;
    else if (formatType == "dd-mm-yyyy") return `${day}-${month}-${year}`;
    else if (formatType == "yyyy/mm/dd") return `${year}/${month}/${day}`;
    else if (formatType == "yyyy-mm-dd") return `${year}-${month}-${day}`;
    else if (formatType == "mm-dd-yyyy") return `${month}-${day}-${year}`;
  } else {
    return "---";
  }
};

/**
 * Created by nhoanh (7/7/2020)
 * @param {*} value Giá trị cần format
 * @param {*} splitType Kiểu ngăn cách = {'.', ',', ...}
 * Description: Hàm format tiền tệ theo ngăn cách 3 số
 */
const formatMoney = function(value, splitType) {
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, splitType);
};

const formatMoney2 = function(value, splitType) {
  var number = value
    .split("")
    .filter((x) => x !== ",")
    .join("");
  return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, splitType);
};

/**
 * Created by nhoanh (7/7/2020)
 * @param {*} money Giá trị tiền muốn chuyển
 * Description: Hàm chuyển giá trị hiển thị của tiền về dạng sô
 */
const convertMoneyToNumber = function(money) {
  var moneyStr = money.toString();
  var splitChar = moneyStr[moneyStr.search(/[^\d]/)]; // Tìm ký tự phân cách
  var splitMoney = moneyStr.split(splitChar);
  var value = "";
  for (let i = 0; i < splitMoney.length; i++) {
    value += splitMoney[i];
  }
  return parseInt(value);
};

/**
 * Created by nhdoanh (27/7/2020)
 * @param {Sting} str giá trị muốn chuẩn hóa
 * Description: Hàm chuẩn hóa giá trị Input nhập liệu họ và tên người, địa danh
 *              (Viết hoa các chữ cái đầu mỗi từ)
 */
const convertName = function(str) {
  str.toString();
  // Các ký tự có dấu trong Tiếng Việt
  let vnChar =
    "(à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|ì|í|ị|ỉ|ĩ|" +
    "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|ỳ|ý|ỵ|ỷ|ỹ|đ)";

  // Regex cho viết hoa các ký tự đầu tiên của một từ trong chuỗi cho trước
  let regex = new RegExp(`^([a-z])|^${vnChar}|\\s+([a-z])|\\s+${vnChar}`, "g");
  return str.replace(regex, function(char) {
    return char.toUpperCase();
  });
};

/**
 * method sắp xếp list theo alphabet
 * @param {Array} data list dữ liệu truyền vào
 * created by: N.T. Dũng 28.07.2020
 */
const sortData = (data) => {
  if (data) {
    data.sort((a, b) => {
      // loại bỏ phụ thuộc chữ hoa thường
      let firstName = a.LocationName.toUpperCase(),
        SecondName = b.LocationName.toUpperCase();
      return firstName.localeCompare(SecondName);
    });
  }
};

export {
  formatDate,
  formatMoney,
  formatMoney2,
  convertMoneyToNumber,
  convertName,
  sortData,
};
