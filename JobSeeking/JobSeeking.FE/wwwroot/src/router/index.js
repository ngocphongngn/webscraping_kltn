import Vue from "vue";
import VueRouter from "vue-router";
import VueCookier from "vue-cookies";
import Layout from "@/layout";
import Admin from "@/views/admin-layout/admin.vue"
import "../styles/nprogress.scss";
import NProgress from "nprogress";
//mport Cookies from "js-cookie";

Vue.use(VueRouter);
Vue.use(VueCookier);

export const routes = [
  {
    path: "",
    redirect: { name: "JobSeeking" },
  },
  {
    path: "/job-seeking",
    name: "JobSeeking",
    component: Layout,
    redirect: { name: "JobSeeking" },
    children: [
      {
        path: "",
        name: "JobSeeking",
        component: () => import("@/views/job-seeking/index.vue"),
        meta: {
          title: "Trang chủ",
        },
      },
      {
        path: "/topcv",
        name: "TopCV",
        component: () => import("@/views/job-seeking/topcv/topcv.vue"),
        meta: {
          title: "https://www.topcv.vn",
        },
      },
      {
        path: "/vnindeed",
        name: "VNIndeed",
        component: () => import("@/views/job-seeking/vnindeed/vnindeed.vue"),
        meta: {
          title: "https://vn.indeed.com",
        },
      },

    ]
  },
  {
    path: "/admin",
    name: "Admin",
    component: Admin,
    children: [
      {
        path: "",
        redirect: { name: "ManageData" },
      },
      {
        path: "/manage-data",
        name: "ManageData",
        component: () => import("@/views/admin-views/manage-data.vue"),
        meta: {
          title: "Quản lý dữ liệu",
        },
      },
      {
        path: "/manage-user",
        name: "ManageUser",
        component: () => import("@/views/admin-views/manage-user.vue"),
        meta: {
          title: "Quản lý người dùng",
        },
      },
      {
        path: "/manage-system",
        name: "ManageSystem",
        component: () => import("@/views/admin-views/manage-system.vue"),
        meta: {
          title: "Quản lý dữ liệu",
        },
      },
    ]
  },
  {
    path: "/login",
    name: "Login",
    component: () => import("@/views/login/login.vue"),
  },
  {
    path: "/register",
    name: "Register",
    component: () => import("@/views/register/register.vue"),
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeResolve((to, from, next) => {
  if (to.name || from.name) {
    NProgress.start();
  }
  next();
});
router.afterEach((to, from) => {
  NProgress.done();
  if (to.name || from.name) {
    NProgress.done();
  } else NProgress.done();
});

router.beforeEach((to, from, next) => {
  //nếu là môi trường test
  if (process.env.NODE_ENV == "production") {
    next();
  }
  //nếu là môi trường phát triển
  else {
    next();
  }
});
export default router;
