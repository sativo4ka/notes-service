Отчет по лабораторной работе: Контейнеризация Notes Service

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
<img width="1387" height="47" alt="{9614C6C5-0A36-4F58-80D6-27C4FD312FFF}" src="https://github.com/user-attachments/assets/3f491ce5-27cf-40c9-bcdd-b394bd57313e" />

Проверка логов контейнера:
<img width="373" height="26" alt="{6687A747-2885-4E7C-ADF8-E99657294CB9}" src="https://github.com/user-attachments/assets/8a16e22b-d0cd-4ae6-a0bf-3cc6acec9bf1" />
<img width="800" height="328" alt="{83C25FCE-D4BB-4584-A158-A2662C9C7734}" src="https://github.com/user-attachments/assets/4e5121ed-035c-4e8d-a486-1c041396a91f" />


Запрос к API через браузер:
<img width="436" height="247" alt="{00DEA84E-ABD5-4380-AF84-647786AD77F4}" src="https://github.com/user-attachments/assets/4490f707-b75a-4c4a-995e-609e92d6cdaa" />

