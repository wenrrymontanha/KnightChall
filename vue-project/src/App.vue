<template>
  <div class="container">
    <button class="tab-button" @click="tab = 'Cadastro'">Cadastro do Knight</button>
    <button class="tab-button" @click="tab = 'GetKnightById'">GetKnightById</button>
    <button class="tab-button" @click="tab = 'GetKnightList'">GetKnightList</button>
    <button class="tab-button" @click="tab = 'DeleteKnightById'">DeleteKnightById</button>
    <button class="tab-button" @click="tab = 'UpdateKnightById'">UpdateKnightById</button>

    <component :is="tabComponent" />
  </div>
</template>

<script>
import Cadastro from './CadastroKnight.vue';
import GetKnightById from './GetKnightById.vue';
import GetKnightList from './GetKnightList.vue';
import DeleteKnightById from './DeleteKnightById.vue';
import UpdateKnightById from './UpdateKnightById.vue';

export default {
  data() {
    return {
      tab: 'Cadastro',
    };
  },
  computed: {
    tabComponent() {
      switch (this.tab) {
        case 'Cadastro':
          return Cadastro;
        case 'GetKnightById':
          return GetKnightById;
        case 'GetKnightList':
          return GetKnightList;
        case 'DeleteKnightById':
          return DeleteKnightById;
        case 'UpdateKnightById':
          return UpdateKnightById;
        default:
          return Cadastro;
      }
    },
  },
};
</script>
<style scoped>
.container {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
}
.tab-content.active {
  display: block;
}
.tab-button {
  background-color: #4CAF50;
  border: none;
  color: white;
  padding: 10px 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  border-radius: 4px;
}
.container {
  overflow-x: auto;
  overflow-y: auto;
  max-height: 100vh;
}
</style>