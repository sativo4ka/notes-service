
# Архитектура системы управления заметками

## 1. Общее описание

Система управления заметками — микросервисное приложение, предназначенное для создания, просмотра, изменения и удаления заметок, управления категориями и поиска заметок.

Система состоит из трёх независимых ASP.NET Core Web API:

- **NotesService** — управление заметками.
- **CategoriesService** — управление категориями.
- **SearchService** — поиск заметок.

Для постоянного хранения данных используется PostgreSQL 16. Все сервисы запускаются в Docker-контейнерах с помощью Docker Compose.

## 2. Используемые технологии

| Технология | Назначение |
|---|---|
| C# | Основной язык программирования |
| ASP.NET Core Web API | Реализация HTTP API |
| Entity Framework Core | Работа с базой данных |
| Npgsql | Подключение к PostgreSQL |
| PostgreSQL 16 | Хранение данных |
| Docker | Контейнеризация сервисов |
| Docker Compose | Совместный запуск контейнеров |
| Swagger | Документирование и проверка API |

## 3. C4 Level 1 — System Context

Внешний пользователь взаимодействует с системой через HTTP API.

Система предоставляет следующие возможности:

- создание и просмотр заметок;
- редактирование и удаление заметок;
- создание и просмотр категорий;
- редактирование и удаление категорий;
- поиск заметок по названию и содержимому.

На контекстном уровне система рассматривается как единое целое. Внутреннее устройство микросервисов здесь не раскрывается.

## 4. C4 Level 2 — Container

Система включает следующие контейнеры.

### 4.1 NotesService

ASP.NET Core Web API, отвечающий за управление заметками.

Основные операции:

- `GET /api/Notes` — получение списка заметок;
- `GET /api/Notes/{id}` — получение заметки по идентификатору;
- `POST /api/Notes` — создание заметки;
- `PUT /api/Notes/{id}` — изменение заметки;
- `DELETE /api/Notes/{id}` — удаление заметки.

Для работы с данными используется Entity Framework Core и `NotesDbContext`.

### 4.2 CategoriesService

ASP.NET Core Web API, отвечающий за управление категориями.

Основные операции:

- `GET /api/Categories` — получение списка категорий;
- `GET /api/Categories/{id}` — получение категории по идентификатору;
- `POST /api/Categories` — создание категории;
- `PUT /api/Categories/{id}` — изменение категории;
- `DELETE /api/Categories/{id}` — удаление категории.

Для доступа к данным используется Entity Framework Core и `CategoriesDbContext`.

### 4.3 SearchService

ASP.NET Core Web API, предназначенный для поиска заметок.

Основная операция:

- `GET /api/Search?query=текст` — поиск заметок по названию и содержимому.

Для получения заметок SearchService обращается к NotesService через HTTP с помощью `HttpClient`.

Поиск выполняется без учёта регистра символов. Результат возвращается в виде списка найденных заметок.

### 4.4 PostgreSQL

PostgreSQL 16 используется как общее хранилище данных для NotesService и CategoriesService.

Сервисы используют отдельные контексты Entity Framework Core:

- `NotesDbContext` — работает с заметками;
- `CategoriesDbContext` — работает с категориями.

Данные заметок и категорий хранятся в отдельных таблицах.

SearchService напрямую к базе данных не подключается: он получает данные через NotesService.

## 5. C4 Level 3 — Component

На уровне компонентов рассматривается внутреннее устройство NotesService.

### NotesController

Контроллер принимает HTTP-запросы и выполняет операции CRUD.

Он обрабатывает запросы GET, POST, PUT и DELETE, используя NotesDbContext.

### Note

Модель заметки содержит следующие свойства:

- `Id` — идентификатор;
- `Title` — название;
- `Content` — содержание;
- `CreatedAt` — дата создания.

### NotesDbContext

Контекст Entity Framework Core обеспечивает взаимодействие приложения с базой данных PostgreSQL.

Он содержит `DbSet<Note>`, через который выполняются операции с таблицей заметок.

### PostgreSQL

Хранит записи заметок. Изменения сохраняются через `SaveChangesAsync()`.

## 6. Взаимодействие микросервисов

Основной сценарий поиска:

1. Пользователь отправляет запрос в SearchService.
2. SearchService получает параметр `query`.
3. SearchService отправляет HTTP GET-запрос к NotesService по адресу `/api/Notes`.
4. NotesService получает список заметок из PostgreSQL.
5. NotesService возвращает список SearchService.
6. SearchService фильтрует заметки по названию и содержимому.
7. Пользователь получает список найденных заметок.

Сценарии управления заметками и категориями выполняются независимо через соответствующие сервисы.

## 7. Хранение данных и миграции

Для хранения данных используется PostgreSQL 16.

В проекте предусмотрены миграции Entity Framework Core для NotesService и CategoriesService.

В Docker Compose настроен постоянный том `db_data`, подключённый к каталогу данных PostgreSQL внутри контейнера.

Это позволяет сохранять данные при пересоздании контейнера базы данных, пока сам том не удалён.

Миграции находятся в каталогах `NotesService/Migrations` и `CategoriesService/Migrations`.

В текущей реализации автоматический вызов применения миграций при запуске приложений не добавлен. Поэтому создание или обновление структуры базы данных необходимо выполнять отдельно.

## 8. Запуск системы и проверка API

Для запуска всех сервисов из корневой папки проекта используется команда:

```bash
docker compose up -d --build
```

После запуска доступны следующие интерфейсы Swagger:

- NotesService: http://localhost:8081/swagger
- CategoriesService: http://localhost:8082/swagger
- SearchService: http://localhost:8083/swagger

Для просмотра состояния контейнеров:

```bash
docker compose ps
```

Для просмотра логов:

```bash
docker compose logs
```

Для остановки контейнеров без удаления постоянного хранилища данных:

```bash
docker compose down
```

## 9. Структура проекта

```text
notes-service/
├── NotesService/
│   ├── Controllers/
│   ├── Data/
│   ├── Migrations/
│   ├── Models/
│   └── Dockerfile
├── CategoriesService/
│   ├── Controllers/
│   ├── Data/
│   ├── Migrations/
│   ├── Models/
│   └── Dockerfile
├── SearchService/
│   ├── Controllers/
│   ├── Models/
│   └── Dockerfile
├── docs/
│   └── architecture/
│       └── architecture.md
├── C4_Context.drawio
├── C4_Container.drawio
├── C4_Component.drawio
├── docker-compose.yml
├── NotesManagementSystem.slnx
└── README.md
```

## 10. Ограничения текущей реализации

- API Gateway не используется.
- Redis Cache не используется.
- Аутентификация и авторизация пользователей не реализованы.
- CategoriesService и NotesService работают с разными наборами данных и не имеют реализованной связи между заметками и категориями.
- SearchService получает полный список заметок от NotesService и выполняет фильтрацию на своей стороне.

Документация описывает существующую реализацию проекта, а не предполагаемые будущие компоненты.
