FROM node:22.12-alpine
WORKDIR /src
COPY . .
WORKDIR "/src/WebApiWithReact.Frontend"
RUN npm install
RUN npm install -g dotenv-cli
RUN npm run build-docker
WORKDIR "/src/WebApiWithReact.Frontend/wwwroot"
EXPOSE 5210
CMD ["npm", "run", "preview"]