FROM node:latest as build
WORKDIR /usr/local/app
COPY ./ /usr/local/app/
RUN npm install
RUN npm run build -- --configuration development

FROM nginx:latest
COPY --from=build /usr/local/app/dist/shop.web /usr/share/nginx/html

EXPOSE 80
