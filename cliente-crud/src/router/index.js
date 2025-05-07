
import { createRouter, createWebHistory } from "vue-router";
import ClienteLista from "@/views/ClienteLista.vue";
import ClienteFormulario from "@/views/ClienteFormulario.vue";

const routes = [
  { path: "/", redirect: "/clientes" },
  { path: "/clientes", name: "ClienteLista", component: ClienteLista },
  {
    path: "/clientes/nuevo",
    name: "ClienteNuevo",
    component: ClienteFormulario,
  },
  {
    path: "/clientes/:id/editar",
    name: "ClienteEditar",
    component: ClienteFormulario,
    props: true,
  },
];

export default createRouter({
  history: createWebHistory(),
  routes,
});
