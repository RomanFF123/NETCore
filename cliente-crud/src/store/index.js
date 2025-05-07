import { createStore } from "vuex";
import clientes from "./modulos/clientes";

export default createStore({
  modules: {
    clientes,
  },
});
