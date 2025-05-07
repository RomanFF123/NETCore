import { reactive } from "vue";

const state = reactive({
  clientes: [],
});

const getters = {
  all: () => state.clientes,
  getById: () => (id) => state.clientes.find((c) => c.id === id),
};

const mutations = {
  ADD_CLIENTE(state, cliente) {
    state.clientes.push(cliente);
  },
  UPDATE_CLIENTE(state, cliente) {
    const i = state.clientes.findIndex((c) => c.id === cliente.id);
    if (i !== -1) state.clientes.splice(i, 1, cliente);
  },
  DELETE_CLIENTE(state, id) {
    const i = state.clientes.findIndex((c) => c.id === id);
    if (i !== -1) state.clientes.splice(i, 1);
  },
};

const actions = {
  addCliente({ commit }, data) {
    const id = Date.now().toString();
    commit("ADD_CLIENTE", { id, ...data });
  },
  updateCliente({ commit }, cliente) {
    commit("UPDATE_CLIENTE", cliente);
  },
  deleteCliente({ commit }, id) {
    commit("DELETE_CLIENTE", id);
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
