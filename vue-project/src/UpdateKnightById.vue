<template>
  <div id="updateKnightTab" class="tab-content">
    <h2>Atualizar Knight Nickname</h2>
    <label for="updateId">ID do Cavaleiro:</label>
    <input type="text" id="updateId" name="updateId" v-model="knightId">
    <label for="newNickname">Novo Nickname:</label>
    <input type="text" id="newNickname" name="newNickname" v-model="newNickname">
    <button @click="updateKnightNickname">Atualizar</button>
    <div id="updateMessage">{{ updateResponse }}</div>
  </div>
</template>

<script>
import config from './config';
export default {
  data() {
    return {
      knightId: '',
      newNickname: '',
      updateResponse: ''
    };
  },
  methods: {
    async updateKnightNickname() {
      try {
        const response = await fetch(`${config.apiBaseUrl}/${this.knightId}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({ name: this.newNickname })
        });

        if (response.ok) {
          this.updateResponse = `Nickname do Cavaleiro com o ID ${this.knightId} atualizado para ${this.newNickname}.`;
        } else {
          const errorMessage = await response.text();
          throw new Error(`Erro ao atualizar nickname: ${errorMessage}`);
        }
      } catch (error) {
        console.error('Erro ao atualizar nickname:', error);
        this.updateResponse = `Erro ao atualizar nickname: ${error.message}`;
      }
    }
  }
};
</script>
