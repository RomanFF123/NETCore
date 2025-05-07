<template>
  <v-container>
    <v-row justify="space-between" align="center">
      <h1>Clientes</h1>
      <v-btn color="primary" @click="goToNew">Nuevo</v-btn>
    </v-row>
    <v-data-table
      :headers="headers"
      :items="clientes"
      item-key="id"
      class="elevation-1"
    >
      <template v-slot:[`item.actions`]="{ item }">
        <v-btn icon @click="edit(item)">
          <v-icon>mdi-pencil</v-icon>
        </v-btn>
        <v-btn icon @click="confirmDelete(item.id)">
          <v-icon color="red">mdi-delete</v-icon>
        </v-btn>
      </template>
    </v-data-table>

    <v-dialog v-model="dialog" max-width="400">
      <v-card>
        <v-card-title class="headline">Confirmar eliminación</v-card-title>
        <v-card-text>¿Eliminar este cliente?</v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn text @click="dialog = false">Cancelar</v-btn>
          <v-btn color="red" text @click="remove">Eliminar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script setup>
import { ref, computed } from "vue";
import { useStore } from "vuex";
import { useRouter } from "vue-router";

const store = useStore();
const router = useRouter();

const clientes = computed(() => store.getters["clientes/all"]);
const headers = [
  { text: "Nombre", value: "name" },
  { text: "Correo", value: "email" },
  { text: "Teléfono", value: "phone" },
  { text: "Acciones", value: "actions", sortable: false },
];

const dialog = ref(false);
const toDelete = ref(null);

function goToNew() {
  router.push({ name: "ClienteNuevo" });
}

function edit(item) {
  router.push({ name: "ClienteEditar", params: { id: item.id } });
}

function confirmDelete(id) {
  toDelete.value = id;
  dialog.value = true;
}

function remove() {
  store.dispatch("clientes/deleteCliente", toDelete.value);
  dialog.value = false;
}
</script>
