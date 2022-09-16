### STAGE 1: Build ###
FROM node:16.15-alpine AS build
WORKDIR /usr/src/app
COPY ["Taller.FullStack.Client/package.json","./"]
COPY ["Taller.FullStack.Client/package-lock.json","./"]
RUN npm install
COPY ["Taller.FullStack.Client/.","./"]
RUN npm run build
#RUN ng build --prod
### STAGE 2: Run ###
##FROM nginx:1.21.6-alpine
FROM nginxinc/nginx-unprivileged 
EXPOSE 8080
#COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/taller.full-stack.client /usr/share/nginx/html
