<template>
  <v-container>
    <h1>{{ isEdit ? "Editar Cliente" : "Nuevo Cliente" }}</h1>

    <v-form
        ref="formRef"
        v-model="valid"
        @submit.prevent="save"
    >
      <v-text-field
        v-model="form.name"
        label="Nombre"
        :rules="nameRules"
        required    
      />
      <v-text-field
        v-model="form.email"
        label="Correo"
        :rules="emailRules"
        required    
      />
      <v-text-field
        v-model="form.phone"
        label="Teléfono"
        :rules="phoneRules"
        required    
      />
      <v-btn
        type="submit"
        color="primary"
        :disabled="!valid"
      >
        {{ isEdit ? "Actualizar" : "Crear" }}
      </v-btn>
    </v-form>
  </v-container>
</template>

<script setup>
import { reactive, ref, computed, onMounted } from "vue";
import { useStore } from "vuex";
import { useRouter, useRoute } from "vue-router";

const store = useStore();
const router = useRouter();
const route = useRoute();

const isEdit = computed(() => Boolean(route.params.id));

const valid = ref(false);
const formRef = ref(null);

const form = reactive({
  name:  "",
  email: "",
  phone: "",
});

const nameRules = [
  (v) => !!v || "El nombre es requerido",
  (v) => v.length >= 3 || "Mínimo 3 caracteres",
];

const emailRules = [
  (v) => !!v || "El correo es requerido",
  (v) => /.+@.+\..+/.test(v) || "Email inválido",
];

const phoneRules = [
  (v) => !!v || "El teléfono es requerido",
  (v) => /^\d+$/.test(v) || "Solo números",
  (v) => v.length >= 7 || "Mínimo 7 dígitos",
];

onMounted(() => {
  if (isEdit.value) {
    const existing = store.getters["clientes/getById"](route.params.id);
    if (existing) {
      form.name  = existing.name;
      form.email = existing.email;
      form.phone = existing.phone;
    } else {
      router.push({ name: "ClienteLista" });
    }
  }
});

function save() {
  if (!formRef.value.validate()) return;

  if (isEdit.value) {
    store.dispatch("clientes/updateCliente", {
      id:    route.params.id,
      name:  form.name,
      email: form.email,
      phone: form.phone,
    });
  } else {
    store.dispatch("clientes/addCliente", {
      name:  form.name,
      email: form.email,
      phone: form.phone,
    });
  }

  router.push({ name: "ClienteLista" });
}
</script>
