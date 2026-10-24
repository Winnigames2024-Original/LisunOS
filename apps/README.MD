# 📁 APPS (sys/services) — Micro Docs

## 🇷🇺 RU
**Установка:** `apt install <ссылка.lnsh>` или `sudo apt install <ссылка.lnsh>`  
**Сведения о пакете:** `apt update <name из meta.json>`  
**Формат:** `.lnsh` — это ZIP-архив:
* `meta.json` — манифест, массив локализаций (`lang: ruRU` / `enUS`) и список `permissions`
* `main.lsi` — сценарий установки
* `*.service` — регистрация службы и формы
* `assets/` — `Form1.cs` и `Form1.designer.cs`

После установки файлы пакета шифруются. Приложение само запрашивает
права, выданные хранятся в `/os/root/regedit/PERMISSIONS`.

### Готовые пакеты

| Архив | Пакет | Команда запуска |
|-------|-------|-----------------|
| [`explorerApp.lnsh`](explorerApp.lnsh) | ExplorerApp 1.1.0 — проводник | `explorer`, `files` |
| [`webserverv2.lnsh`](webserverv2.lnsh) | WebServerV2 2.0.0 — панель сервера | `webserverv2`, `httpd` |
| [`calcapp.lnsh`](calcapp.lnsh) | CalcApp 1.0.0 — калькулятор с историей | `calc`, `calculator` |
| [`settingsapp.lnsh`](settingsapp.lnsh) | SettingsApp 1.0.0 — параметры системы | `settings`, `options` |
| [`storeapp.lnsh`](storeapp.lnsh) | StoreApp 1.0.0 — каталог приложений | `store`, `apps-store` |
| [`template/TemplateApp.lnsh`](template/TemplateApp.lnsh) | TemplateApp 1.0.0 — шаблон | `template`, `tpl` |

Список для Каталога приложений — [`catalog.json`](catalog.json): его читает
пакет StoreApp и команда `store refresh`.

👉 **Готовый скелет и полная спецификация — в [`template/`](template/README.MD).**

---

## 🇺🇸 EN
**Install:** `apt install <url.lnsh>` or `sudo apt install <url.lnsh>`  
**Package info:** `apt update <name from meta.json>`  
**Format:** `.lnsh` is a standard ZIP archive:
* `meta.json` — manifest: an array of localizations (`lang: ruRU` / `enUS`) and a `permissions` list
* `main.lsi` — deployment script
* `*.service` — service and form registration
* `assets/` — `Form1.cs` and `Form1.designer.cs`

Package files are encrypted after install. An application requests its own
permissions; granted ones live in `/os/root/regedit/PERMISSIONS`.

### Ready-made packages

| Archive | Package | Launch command |
|---------|---------|----------------|
| [`explorerApp.lnsh`](explorerApp.lnsh) | ExplorerApp 1.1.0 — file manager | `explorer`, `files` |
| [`webserverv2.lnsh`](webserverv2.lnsh) | WebServerV2 2.0.0 — server panel | `webserverv2`, `httpd` |
| [`calcapp.lnsh`](calcapp.lnsh) | CalcApp 1.0.0 — calculator with history | `calc`, `calculator` |
| [`settingsapp.lnsh`](settingsapp.lnsh) | SettingsApp 1.0.0 — system settings | `settings`, `options` |
| [`storeapp.lnsh`](storeapp.lnsh) | StoreApp 1.0.0 — application catalog | `store`, `apps-store` |
| [`template/TemplateApp.lnsh`](template/TemplateApp.lnsh) | TemplateApp 1.0.0 — template | `template`, `tpl` |

The list used by the catalog app is [`catalog.json`](catalog.json); StoreApp
and the `store refresh` command read it.

👉 **A ready-made skeleton and the full specification live in [`template/`](template/README.MD).**
