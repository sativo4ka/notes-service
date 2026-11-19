@'
# Система управления заметками

## Описание проекта

Система управления заметками на основе микросервисной архитектуры.

Позволяет создавать, просматривать, редактировать, удалять и искать заметки, а также управлять категориями.

## Архитектура

Проект состоит из трех микросервисов:

- **NotesService** — управление заметками (CRUD).
- **CategoriesService** — управление категориями (CRUD).
- **SearchService** — поиск заметок по названию и содержанию.

Для хранения данных используется PostgreSQL. Микросервисы взаимодействуют по HTTP.

## Технологии

- C#
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL 16
- Docker и Docker Compose
- Swagger

## Структура проекта

- `NotesService/` — сервис заметок.
- `CategoriesService/` — сервис категорий.
- `SearchService/` — сервис поиска.
- `NotesManagementSystem.slnx` — решение Visual Studio.
- `docker-compose.yml` — запуск контейнеров.
- `C4_Context.drawio` — контекстная диаграмма.
- `C4_Container.drawio` — диаграмма контейнеров.
- `C4_Component.drawio` — диаграмма компонентов.

## Запуск

Установите Docker Desktop. В корневой папке репозитория выполните:

```bash
docker compose up -d --build
```

## Остановка:

```
docker compose down
```

## Swagger

- NotesService: http://localhost:8081/swagger
- CategoriesService: http://localhost:8082/swagger
- SearchService: http://localhost:8083/swagger
- 
## База данных
- СУБД: PostgreSQL 16
- База данных: notes_db
- Таблицы: Notes, Categories
- 
## Проверка работы

Работа микросервисов проверяется через Swagger. SearchService получает список заметок от NotesService и выполняет поиск по названию и содержанию.
'@ | Set-Content -Encoding UTF8 .\README.md
