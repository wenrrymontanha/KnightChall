# Use uma imagem base com Node.js instalado
FROM node:14-alpine as build

# Defina o diretório de trabalho no contêiner
WORKDIR /app

# Copie o arquivo package.json e o arquivo package-lock.json (se existir)
COPY package*.json ./

# Instale as dependências do projeto
RUN npm install

# Copie todos os arquivos do projeto para o diretório de trabalho no contêiner
COPY . .

# Compile o projeto Vue.js para produção
RUN npm run build

# Use uma imagem base leve com Nginx para servir o aplicativo compilado
FROM nginx:alpine

# Copie os arquivos compilados do diretório de compilação do contêiner de compilação para o diretório padrão do servidor web do Nginx
COPY --from=build /app/dist /usr/share/nginx/html

# Expõe a porta 80 para que o aplicativo possa ser acessado a partir do exterior
EXPOSE 80

# Comando padrão para iniciar o servidor Nginx
CMD ["nginx", "-g", "daemon off;"]
