#for local run - Start docker first
# -------- Stage 1: Build Angular App --------
FROM node:22-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --prod

# -------- Stage 2: Serve with Nginx --------
FROM nginx:alpine
COPY --from=build /app/dist/angularwebapp /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

### To build the docker image, run the following command in the terminal:
### docker build -t angualarapp:v1 .
### To run the docker container, use the following command:
### docker run -d -p 80:80 angularapp:v1