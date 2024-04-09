# KnightChall
full life cycle application from front to back on a docker conteiner 

-> Open terminal in */KNIGHTCHALL

-> Run 'docker-compose up --build'

-> Open Front Application on 'http://localhost:8080/'

-> BackEnd Application Listening on 'http://localhost:32785/api/Knights'


############## CONSIDERAÇÕES #############

quantidade de weapons na lista de Knights  => contando só as weapons equipadas;

attack weapon modifier => só soma quando o Knight.keyattr == weapon.attr;

Get knight by Id == traz todas as informações do knight como consta no banco (diferente da lista de cavaleiros que traz informações calculadas);