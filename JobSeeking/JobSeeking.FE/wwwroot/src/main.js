import Vue from "vue";
import Cookies from "js-cookie";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import Element from "element-ui";
import "./styles/element-variables.scss";
import "@/styles/index.scss";
import viLang from "@/localize/vi";
import "./utils/error-log";
import VueDatePicker from "@mathieustan/vue-datepicker";
import money from "v-money";
import "@mathieustan/vue-datepicker/dist/vue-datepicker.min.css";
import Popup from "@/components/dialog/popups";
import Notification from "@/components/notifications";
import VueProgress from 'vue-progress-path';

Vue.use(VueProgress)
Vue.use(Notification);
Vue.use(Popup);

Vue.use(Element, {
  size: Cookies.get("size") || "medium",
  locale: viLang,
});

Vue.use(VueDatePicker);
Vue.use(money);

Vue.config.performance = true;
// Vue.config.devtools = false;
Vue.config.productionTip = false;
new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
