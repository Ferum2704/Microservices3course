FROM nginx:stable-alpine as build
WORKDIR /app
COPY . .

RUN rm /usr/share/nginx/html/index.html
FROM build
COPY --from=build /app /usr/share/nginx/html
#COPY nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]