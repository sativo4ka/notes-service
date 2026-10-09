Отчет по лабораторной работе: Compose

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
## 3. Запуск системы

<img width="1675" height="528" alt="изображение" src="https://github.com/user-attachments/assets/a743c813-7cdd-4976-9d78-0aa4c9b8d56e" />

## 4. Статус сервисов

<img width="1775" height="108" alt="изображение" src="https://github.com/user-attachments/assets/f4a717ee-24ec-4046-8800-1811c91899bc" />

## 5. CRUD-запросы

<img width="1760" height="252" alt="изображение" src="https://github.com/user-attachments/assets/89587ce9-6777-4715-97de-9d3b03c2945b" />

## 6. Сохранение данных после перезапуска

<img width="1524" height="320" alt="изображение" src="https://github.com/user-attachments/assets/f7b281c7-a83f-4b93-a5db-77f6e36a94bc" />

## 7. Логи системы

<img width="1622" height="229" alt="изображение" src="https://github.com/user-attachments/assets/7d9e91aa-4075-47a9-944f-e5ab3b65782a" />

## 8. Проверка сохранения данных после перезапуска

<img width="1489" height="211" alt="изображение" src="https://github.com/user-attachments/assets/edcb0257-377c-4b05-ba43-4fb343003ceb" />

