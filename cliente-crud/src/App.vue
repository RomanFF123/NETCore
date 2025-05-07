<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title>Ejercicio 1 (CRUD) RFF </v-toolbar-title>
      <v-spacer />
      <v-btn text to="/clientes">Listado</v-btn>
      <v-btn text to="/clientes/nuevo">Nuevo</v-btn>
    </v-app-bar>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>
