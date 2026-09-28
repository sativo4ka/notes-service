# Отчет по лабораторной работе: Контейнеризация Notes Service

## 1. Исходный код API
Проект содержит исходный код на Node.js:
- `server.js` — код API-приложения с эндпоинтами.
- `package.json` — конфигурация зависимостей.

## 2. Dockerfile
Файл `Dockerfile` создан вручную в корне проекта:
```dockerfile
FROM node:18-alpine
WORKDIR /app
COPY package.json .
RUN npm install
COPY . .
EXPOSE 8080
CMD ["node", "server.js"]