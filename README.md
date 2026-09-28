<img width="367" height="227" alt="{6D127B16-0AB9-4F94-9970-A999964CF639}" src="https://github.com/user-attachments/assets/858c03b8-36fa-4cdb-ab47-11ded9492e2d" /># Отчет по лабораторной работе: Контейнеризация Notes Service

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

```
## 3. Инструкция по сборке, запуску и проверке

1. Сборка Docker-образа
```
docker build -t notes-service-app .
```
2. Запуск контейнера
```
docker run -d -p 8080:8080 --name notes-container notes-service-app
```
3. Проверка работоспособности

Проверка запущенных контейнеров:
```
docker ps
```
Проверка логов контейнера:
```
docker logs notes-container
```
Запрос к API через браузер или curl:
```
curl http://localhost:8080/notes
```
