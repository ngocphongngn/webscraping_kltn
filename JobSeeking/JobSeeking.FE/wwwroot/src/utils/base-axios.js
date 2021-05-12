import axios from "axios";
//import Cookie from "js-cookie";
export const api = function(baseURL) {
  return axios.create({
    baseURL,
    validateStatus: function(status) {
      return status >= 100 && status <= 500;
    },
    headers: {
      
    },
  });
};
