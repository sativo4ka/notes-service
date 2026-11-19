# Система управления заметками

## 1. Описание проекта

Микросервисная система для создания, просмотра, редактирования и удаления заметок, управления категориями и поиска заметок.

Проект разработан на C# с использованием ASP.NET Core Web API и Entity Framework Core.

## 2. Архитектура системы

Система состоит из трёх микросервисов:

- **NotesService** — создание, получение, изменение и удаление заметок.
- **CategoriesService** — создание, получение, изменение и удаление категорий.
- **SearchService** — поиск заметок по названию и содержимому. Для получения заметок обращается к NotesService по HTTP.

Для хранения данных используется PostgreSQL 16.

NotesService и CategoriesService работают с базой данных через Entity Framework Core и Npgsql. SearchService получает данные через HTTP API NotesService.

## 3. Используемые технологии

- C#
- ASP.NET Core Web API
- Entity Framework Core
- Npgsql
- PostgreSQL 16
- Docker
- Docker Compose
- Swagger / OpenAPI

## 4. Структура проекта

- `NotesService/` — микросервис управления заметками.
- `CategoriesService/` — микросервис управления категориями.
- `SearchService/` — микросервис поиска.
- `NotesManagementSystem.slnx` — решение Visual Studio.
- `docker-compose.yml` — конфигурация запуска контейнеров.
- `C4_Context.drawio` — контекстная диаграмма.
- `C4_Container.drawio` — диаграмма контейнеров.
- `C4_Component.drawio` — диаграмма компонентов.
- `docs/architecture/` — документация архитектуры.

## 5. Запуск проекта

Для запуска необходимы Docker Desktop и Docker Compose.

В корневой папке проекта выполнить:

```bash
docker compose up -d --build
```

Проверить состояние контейнеров:

```bash
docker compose ps
```

## 6. Swagger

После запуска документация API доступна по адресам:

- NotesService: http://localhost:8081/swagger
- CategoriesService: http://localhost:8082/swagger
- SearchService: http://localhost:8083/swagger

## 7. Хранение данных

Для хранения данных используется PostgreSQL 16.

Docker Compose настраивает именованный том `db_data`, поэтому данные базы сохраняются при обычном перезапуске контейнеров.

Не следует использовать `docker compose down -v`, если требуется сохранить данные.

## 8. Остановка проекта

Для остановки контейнеров выполнить:

```bash
docker compose down
```

Команда останавливает и удаляет контейнеры и сеть, но не удаляет том с данными PostgreSQL.
