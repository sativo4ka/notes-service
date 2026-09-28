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

<img width="1412" height="69" alt="{597DF307-F76B-457C-9135-962708AAAE3A}" src="https://github.com/user-attachments/assets/fa8abe21-b21d-4e80-bf34-72b635893a31" />


Проверка логов контейнера:

<img width="646" height="49" alt="{8B5F5D0A-2B24-4D06-BC17-E356C831DE97}" src="https://github.com/user-attachments/assets/dbef558a-d301-4381-9c31-b38bdcac44ae" />
<img width="800" height="328" alt="{83C25FCE-D4BB-4584-A158-A2662C9C7734}" src="https://github.com/user-attachments/assets/4e5121ed-035c-4e8d-a486-1c041396a91f" />


Запрос к API через браузер и curl:

<img width="436" height="247" alt="{00DEA84E-ABD5-4380-AF84-647786AD77F4}" src="https://github.com/user-attachments/assets/4490f707-b75a-4c4a-995e-609e92d6cdaa" />
<img width="1470" height="664" alt="{7BA3F3F0-7E72-4695-8B5A-A955068C36B1}" src="https://github.com/user-attachments/assets/0f7ec760-2f3d-4c58-87dc-7284b4ba63a8" />


