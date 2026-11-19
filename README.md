# Система управления заметками

## Описание проекта

Микросервисная система для создания, редактирования, удаления и поиска заметок, а также управления категориями.

## Архитектура

- **NotesService** — управление заметками.
- **CategoriesService** — управление категориями.
- **SearchService** — поиск заметок.

Для хранения данных используется PostgreSQL.

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

В корневой папке проекта выполни:

```bash
docker compose up -d --build
```
## Swagger
- NotesService: http://localhost:8081/swagger
- CategoriesService: http://localhost:8082/swagger
- SearchService: http://localhost:8083/swagger
