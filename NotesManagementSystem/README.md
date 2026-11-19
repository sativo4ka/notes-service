\# Система управления заметками(NotesManagementSystem)



\## Описание проекта



Проект представляет собой систему управления заметками, построенную на основе микросервисной архитектуры.



Система позволяет создавать, просматривать, редактировать, удалять и искать заметки, а также управлять категориями.



\## Архитектура проекта



Проект состоит из трех микросервисов:



1\. NotesService - управление заметками(CRUD).

2\. CategoriesService - управление категориями(CRUD).

3\. SearchService - поиск заметок по названию и содержанию.



Для хранения данных используется PostgreSQL.



Микросервисы взаимодействуют друг с другом по HTTP.



\## Используемые технологии



\- C#

\- ASP.NET Core Web API

\- Entity Framework Core

\- PostgreSQL 16

\- Docker

\- Docker Compose

\- Swagger



\## Структура проекта



\- NotesService - сервис заметок.

\- CategoriesService - сервис категорий.

\- SearchService - сервис поиска.

\- docker-compose.yml - конфигурация запуска контейнеров.

\- C4\_Context.drawio - контекстная диаграмма.

\- C4\_Контейнеры.drawio - диаграмма контейнеров.

\- C4\_Компоненты.drawio - диаграмма компонентов.



\## Запуск проекта



Для запуска проекта необходимо установить Docker Desktop.



В терминале, находясь в папке NotesManagementSystem, выполнить команду:



docker compose up -d --build



Для остановки контейнеров:



docker compose down



\## Адреса Swagger



\- NotesService: http://localhost:8081/swagger

\- CategoriesService: http://localhost:8082/swagger

\- SearchService: http://localhost:8083/swagger



\## База данных



Используется PostgreSQL.



Название базы данных: notes\_db



Таблицы:

\- Notes

\- Categories



\## Проверка работы



Работа микросервисов проверяется через Swagger.



SearchService получает список заметок от NotesService и выполняет поиск по названию и содержанию.

