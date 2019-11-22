import Vue from "vue";
import VueRouter from "vue-router";

import Main from "@/components/Main";
import Login from "@/components/Login";
import Register from "@/components/Register";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    component: Main
  },
  {
    path: "/login",
    component: Login
  },
  {
    path: "/register",
    component: Register
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;