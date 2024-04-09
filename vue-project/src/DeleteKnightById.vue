<template>
  <div id="deleteTab" class="tab-content">
    <h2>Deletar Knight pelo Id</h2>
    <label for="searchId">ID do Cavaleiro:</label>
    <input type="text" id="searchId" name="searchId">
    <button @click="deleteKnightById">Deletar</button>
    <div id="knightInfo"></div>
  </div>
</template>

<script>
import config from './config';
export default {
  methods: {
    async deleteKnightById() {
      try {
        const knightId = document.getElementById('searchId').value;
        const response = await fetch(`${config.apiBaseUrl}/${knightId}`, {
          method: 'DELETE'
        });
        
        if (response.ok) {
          const knightInfoDiv = document.getElementById('knightInfo');
          knightInfoDiv.textContent = `Cavaleiro com o ID ${knightId} foi deletado com sucesso.`;
        } else {
          console.error('Erro ao deletar cavaleiro:', response.statusText);
          const knightInfoDiv = document.getElementById('knightInfo');
          knightInfoDiv.textContent = `Erro ao deletar cavaleiro: ${response.statusText}`;
        }
      } catch (error) {
        console.error('Erro ao deletar cavaleiro:', error);
        const knightInfoDiv = document.getElementById('knightInfo');
        knightInfoDiv.textContent = `Erro ao deletar cavaleiro: ${error.message}`;
      }
    }
  }
};
</script>

<style>
/* Estilos opcionais podem ser adicionados aqui */
</style>
