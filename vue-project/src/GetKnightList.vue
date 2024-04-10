<template>
  <div id="getListTab" class="tab-content">
    <h2>Buscar Lista de Knights</h2>
    <div class="cadastro-scroll">
    <label for="heroCheckbox">Heróis:</label>
    <input type="checkbox" id="heroCheckbox" name="heroCheckbox" v-model="isHero">
    <button @click="searchKnightList">Buscar Lista</button>
    <table id="knightTable">
      <thead>
        <tr>
          <th style="text-align: center;">_id</th>
          <th style="text-align: center;">Nome</th>
          <th style="text-align: center;">Idade</th>
          <th style="text-align: center;">Armas</th>
          <th style="text-align: center;">Atributo</th>
          <th style="text-align: center;">Ataque</th>
          <th style="text-align: center;">Exp</th>
        </tr>
      </thead>
      <tbody id="knightList">
        <tr v-for="knight in knightList" :key="knight._id">
          <td>{{ knight._id }}</td>
          <td>{{ knight.name }}</td>
          <td>{{ knight.age }}</td>
          <td>{{ knight.weapons }}</td>
          <td>{{ knight.keyAttribute }}</td>
          <td>{{ knight.attack }}</td>
          <td>{{ knight.experience }}</td>
        </tr>
      </tbody>
    </table>
  </div>
  </div>
</template>

<script>
import config from './config';
export default {
  data() {
    return {
      isHero: false,
      knightList: []
    };
  },
  methods: {
    
    async searchKnightList() {
      try {
        const filter = this.isHero ? '?filter=heroes' : '';
        const response = await fetch(`${config.apiBaseUrl}${filter}`);
        
        if (response.ok) {
          this.knightList = await response.json();
        } else {
          console.error('Erro ao buscar lista de cavaleiros:', response.statusText);
        }
      } catch (error) {
        console.error('Erro ao buscar lista de cavaleiros:', error);
      }
    }
  }
};
</script>

<style>
table {
  border-collapse: collapse;
  width: 100%;
}

th, td {
  border: 1px solid #a7a0a0;
  text-align: center;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #383434;
}
</style>
