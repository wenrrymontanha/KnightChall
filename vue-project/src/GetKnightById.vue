<template>
  <div id="getKnightTab" class="tab-content">
    <h2>Buscar Knight pelo ID</h2>    
    <div class="cadastro-scroll">
    <label for="searchId">ID do Cavaleiro:</label>
    <input type="text" id="searchId" name="searchId" v-model="knightId">
    <button @click="searchKnightById">Buscar</button>
    <div id="knightInfo">
      <h3>Informações do Cavaleiro</h3>
      <p>ID: {{ knightForm._id }}</p>
      <p>Nome: {{ knightForm.name }}</p>
      <p>Apelido: {{ knightForm.nickname }}</p>
      <p>Data de Nascimento: {{ knightForm.birthday }}</p>
      <h4>Armas:</h4>
      <ul>
        <li v-for="weapon in knightForm.weapons" :key="weapon.name">
          Nome: {{ weapon.name }}, Mod: {{ weapon.mod }}, Atributo: {{ weapon.attr }}, Equipada: {{ weapon.equipped }}
        </li>
      </ul>
      <h4>Atributos:</h4>
      <p>Força: {{ knightForm.attributes.strength }}</p>
      <p>Destreza: {{ knightForm.attributes.dexterity }}</p>
      <p>Constituição: {{ knightForm.attributes.constitution }}</p>
      <p>Inteligência: {{ knightForm.attributes.intelligence }}</p>
      <p>Sabedoria: {{ knightForm.attributes.wisdom }}</p>
      <p>Carisma: {{ knightForm.attributes.charisma }}</p>
      <p>Atributo Chave: {{ knightForm.keyAttribute }}</p>
    </div>
    </div>
  </div>
</template>

<script>
import config from './config';
export default {
  data() {
    return {
      knightId: '',
      knightForm: {
        _id: '',
        name: '',
        nickname: '',
        birthday: '',
        weapons: [],
        attributes: {
          strength: '',
          dexterity: '',
          constitution: '',
          intelligence: '',
          wisdom: '',
          charisma: ''
        },
        keyAttribute: ''
      }
    };
  },
  methods: {
    async searchKnightById() {
      try {
        const response = await fetch(config.apiBaseUrl+`/${this.knightId}`, {
          method: 'GET'
        });

        if (response.ok) {
          const knight = await response.json();
          if(knight._id == undefined) {
            alert('Id Invalido de Knight');
          }
          else{
            this.knightForm = knight;
          }
        } else {
          throw new Error('Erro ao buscar cavaleiro');
        }
      } catch (error) {
        console.error('Erro ao buscar cavaleiro:', error);
      }
    }
  }
};
</script>
<style>
.cadastro-scroll {
  max-height: 600px;
  overflow-y: auto;
}
</style>