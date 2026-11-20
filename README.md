# Система управления заметками

## 1. Описание проекта

Микросервисная система для создания, просмотра, редактирования и удаления заметок, управления категориями и поиска заметок.

Проект разработан на C# с использованием ASP.NET Core Web API и Entity Framework Core.

## 2. Архитектура системы

Система состоит из трёх микросервисов:

- **NotesService** - создание, получение, изменение и удаление заметок.
- **CategoriesService** - создание, получение, изменение и удаление категорий.
- **SearchService** - поиск заметок по названию и содержимому. Для получения заметок обращается к NotesService по HTTP.

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

- `NotesService/` - микросервис управления заметками.
- `CategoriesService/` - микросервис управления категориями.
- `SearchService/` - микросервис поиска.
- `NotesManagementSystem.slnx` - решение Visual Studio.
- `docker-compose.yml` - конфигурация запуска контейнеров.
- `C4_Context.drawio` - контекстная диаграмма.
 
<img width="677" height="431" alt="image" src="https://github.com/user-attachments/assets/05ac3a33-80db-4307-a240-5965c4b95c08" />

- `C4_Container.drawio` - диаграмма контейнеров.

<img width="409" height="477" alt="image" src="https://github.com/user-attachments/assets/f5c4e4e1-28a5-491f-abe1-e6cd511a4df6" />

- `C4_Component.drawio` - диаграмма компонентов.

<img width="515" height="377" alt="image" src="https://github.com/user-attachments/assets/d2d63987-c047-4da7-b373-e887e4a3a15e" />

- `docs/architecture/` - документация архитектуры.

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

- NotesService: http://localhost:7269/swagger
- CategoriesService: http://localhost:7127/swagger
- SearchService: http://localhost:7222/swagger

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
