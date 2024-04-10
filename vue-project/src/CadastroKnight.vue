<template>
  <div id="cadastroTab" class="tab-content active">
    <h2>Cadastro de Knight</h2>
    <div class="container">
    <div class="cadastro-scroll">
      <form @submit.prevent="submitKnightForm">
        <label for="name">Nome:</label>
        <input type="text" id="name" v-model="knightForm.name" @focus="clearField('name')" required><br><br>

        <label for="nickname">Apelido:</label>
        <input type="text" id="nickname" v-model="knightForm.nickname" @focus="clearField('nickname')"><br><br>

        <label for="birthday">Data de Nascimento:</label>
        <input type="text" id="birthday" v-model="knightForm.birthday" @focus="clearField('birthday')" @blur="validateDate" required><br><br>

        <fieldset>
          <legend>Armas:</legend>

          <div v-for="(weapon, index) in knightForm.weapons" :key="index">
            <label :for="'weaponName' + (index + 1)">Nome:</label>
            <input type="text" :id="'weaponName' + (index + 1)" v-model="weapon.name" @focus="clearWeaponField(index, 'name')" required><br><br>

            <label :for="'weaponMod' + (index + 1)">Modificador:</label>
            <input type="number" :id="'weaponMod' + (index + 1)" v-model="weapon.mod" @focus="clearWeaponField(index, 'mod')" required><br><br>

            <label :for="'weaponAttr' + (index + 1)">Atributo:</label>
            <input type="text" :id="'weaponAttr' + (index + 1)" v-model="weapon.attr" @focus="clearWeaponField(index, 'attr')" required><br><br>

            <label :for="'weaponEquipped' + (index + 1)">Equipada:</label>
            <input type="checkbox" :id="'weaponEquipped' + (index + 1)" v-model="weapon.equipped">
          </div>

          <button type="button" @click="addWeapon">Adicionar Arma</button>
        </fieldset>

        <br>

        <label for="strength">Força:</label>
        <input type="number" id="strength" v-model="knightForm.attributes.strength" @focus="clearField('attributes.strength')" required><br><br>

        <label for="dexterity">Destreza:</label>
        <input type="number" id="dexterity" v-model="knightForm.attributes.dexterity" @focus="clearField('attributes.dexterity')" required><br><br>

        <label for="constitution">Constituição:</label>
        <input type="number" id="constitution" v-model="knightForm.attributes.constitution" @focus="clearField('attributes.constitution')" required><br><br>

        <label for="intelligence">Inteligência:</label>
        <input type="number" id="intelligence" v-model="knightForm.attributes.intelligence" @focus="clearField('attributes.intelligence')" required><br><br>

        <label for="wisdom">Sabedoria:</label>
        <input type="number" id="wisdom" v-model="knightForm.attributes.wisdom" @focus="clearField('attributes.wisdom')" required><br><br>

        <label for="charisma">Carisma:</label>
        <input type="number" id="charisma" v-model="knightForm.attributes.charisma" @focus="clearField('attributes.charisma')" required><br><br>

        <label for="keyAttribute">Atributo Chave:</label>
        <input type="text" id="keyAttribute" v-model="knightForm.keyAttribute" @focus="clearField('keyAttribute')" @blur="validaKeyAttribute" required><br><br>

        <button class="button" type="submit">Cadastrar Cavaleiro</button>
      </form>
    </div>
  </div>
</div>
</template>

<script>
import config from './config';
export default {
  data() {
    return {
      knightForm: {
        name: 'john doe',
        nickname: 'doe jhon',
        birthday: '01/01/0001',
        weapons: [{ name: 'gun', mod: '5', attr: 'charisma', equipped: true }],
        attributes: {
          strength: '10',
          dexterity: '10',
          constitution: '5',
          intelligence: '2',
          wisdom: '1',
          charisma: '20'
        },
        keyAttribute: 'charisma'
      }
    };
  },
  methods: {
    addWeapon() {
      this.knightForm.weapons.push({ name: 'frog', mod: '0', attr: 'dexterity', equipped: true });
    },
    clearField(field) {
      this.knightForm[field] = '';
    },
    clearWeaponField(index, field) {
      this.knightForm.weapons[index][field] = '';
    },
    validateDate() {
      const dateRegex = /^\d{2}\/\d{2}\/\d{4}$/; // Expressão regular para validar o formato dd/mm/yyyy
      if (!dateRegex.test(this.knightForm.birthday)) {
        // Se a data não estiver no formato correto, limpa o campo
        this.knightForm.birthday = '01/01/0001';
        alert('Por favor, insira uma data válida no formato dd/mm/yyyy.');
      } else {
        // Se a data estiver no formato correto, verifica se é uma data válida
        const parts = this.knightForm.birthday.split('/');
        const day = parseInt(parts[0], 10);
        const month = parseInt(parts[1], 10) - 1;
        const year = parseInt(parts[2], 10);
        const date = new Date(year, month, day);
        if (isNaN(date.getTime())) {
          // Se a data não for válida, limpa o campo
          this.knightForm.birthday = '01/01/0001';
          alert('Por favor, insira uma data válida.');
        }
      }
    },
    validaKeyAttribute(){
      const validAttributes = ['strength', 'dexterity', 'constitution', 'intelligence', 'wisdom', 'charisma'];
      const keyAttribute = this.knightForm.keyAttribute.toLowerCase();
      if (!validAttributes.includes(keyAttribute)) {
        this.knightForm.keyAttribute = '';
        alert('Por favor, insira um atributo chave válido.');
      }
    },
    async submitKnightForm() {
      try {
        const response = await fetch(config.apiBaseUrl, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(this.knightForm)
        });

        if (response.ok) {
          this.knightForm = {
            name: 'john doe',
            nickname: 'doe john',
            birthday: '01/01/0001',
            weapons: [{ name: 'gun', mod: '20', attr: 'charisma', equipped: true }],
            attributes: {
              strength: '10',
              dexterity: '12',
              constitution: '9',
              intelligence: '5',
              wisdom: '2',
              charisma: '20'
            },
            keyAttribute: 'charisma'
          };
          alert('Cavaleiro cadastrado com sucesso!');
        } else {
          console.error('Erro ao cadastrar cavaleiro:', response.statusText);
          alert(`Erro ao cadastrar cavaleiro: ${response.statusText}`);
        }
      } catch (error) {
        console.error('Erro ao cadastrar cavaleiro:', error);
        alert(`Erro ao cadastrar cavaleiro: ${error.message}`);
      }
    }
  }
};
</script>

<style>
.cadastro-scroll {
  max-height: 80vh;
  overflow-y: auto;
}
</style>
