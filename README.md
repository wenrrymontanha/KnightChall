# KnightChall
full life cycle application front-to-back on a docker container 

-> Open terminal in */KNIGHTCHALL
//entra no projeto do vue.js
-> cd vue-project

//instalar as dependencias do vue.js
-> npm install

-> npm run build
//voltar pro diretorio do docker-compose.yml
-> cd..

//executar o docker-compose + buildar a application
-> Executar o Comando 'docker-compose up --build'

//abrir a pagina do front do projeto
-> Open Front Application on 'http://localhost:8080/'

-> BackEnd Application Listening on 'http://localhost:32785/api/Knights'


############## CONSIDERAÇÕES #############
Quantidade de weapons na lista de Knights  => contando só as weapons equipadas;

Attack weapon modifier => só soma quando o Knight.keyattr == weapon.attr && Knight.Equipped == true;

Get knight by Id == traz todas as informações do knight como consta no banco (diferente da lista de cavaleiros que traz informações calculadas);