# 📁 APPS (sys/services) — Micro Docs

## 🇷🇺 RU

**Установка по имени (качает с сайта):** `apt install webserverv2`
**Установка из файла:** `apt install <ссылка.lnsh>` или `sudo apt install <ссылка.lnsh>`
**Сведения о пакете:** `apt update <name из meta.json>`
**Типы пакетов:** команда `types` — `app`, `service`, `daemon`, `library`,
`theme`, `locale`, `module`, `hall`.

**Формат:** `.lnsh` — это ZIP-архив:
* `meta.json` — манифест, массив локализаций (`lang: ruRU` / `enUS`), `type` и список `permissions`
* `main.lsi` — сценарий установки
* `*.service` — регистрация службы и формы, блоки `daemon ... end`
* `assets/` — `Form1.cs` и `Form1.designer.cs`

После установки файлы пакета шифруются. Приложение само запрашивает
права, выданные хранятся в `/os/root/regedit/PERMISSIONS`.
Право `superuser` из терминала не выдаётся — только приложением
**SuperUser** (`superuser`).

### Готовые пакеты

| Архив | Пакет | Команда запуска |
|-------|-------|-----------------|
| [`explorerApp.lnsh`](explorerApp.lnsh) | ExplorerApp 1.2.0 — проводник | `explorer`, `files` |
| [`webserverv2.lnsh`](webserverv2.lnsh) | WebServerV2 2.1.0 — панель сервера | `webserverv2`, `httpd` |
| [`sshapp.lnsh`](sshapp.lnsh) | SshApp 1.0.0 — доступ по сети с телефона и ПК | `ssh-app` |
| [`superuserapp.lnsh`](superuserapp.lnsh) | SuperUserApp 1.0.0 — выдача права superuser | `superuser`, `su-app` |
| [`logsapp.lnsh`](logsapp.lnsh) | LogsApp 1.0.0 — журнал ядра с поиском | `logs` |
| [`calcapp.lnsh`](calcapp.lnsh) | CalcApp 1.0.0 — калькулятор с историей | `calc`, `calculator` |
| [`settingsapp.lnsh`](settingsapp.lnsh) | SettingsApp 1.0.0 — параметры системы | `settings`, `options` |
| [`storeapp.lnsh`](storeapp.lnsh) | StoreApp 1.0.0 — каталог приложений | `store`, `apps-store` |
| [`TemplateApp.lnsh`](TemplateApp.lnsh) | TemplateApp 1.1.0 — шаблон | `template`, `tpl` |

Список для Каталога приложений — [`catalog.json`](catalog.json): его читает
пакет StoreApp, команда `store refresh` и `apt install <имя>`.

👉 **Готовый скелет и полная спецификация — в [`template/`](template/README.MD).**
👉 **Собрать свой пакет: распакуйте любой `.lnsh` — внутри обычный ZIP.**

---

## 🇺🇸 EN

**Install by name (downloads from the site):** `apt install webserverv2`
**Install from a file:** `apt install <url.lnsh>` or `sudo apt install <url.lnsh>`
**Package info:** `apt update <name from meta.json>`
**Package types:** the `types` command — `app`, `service`, `daemon`, `library`,
`theme`, `locale`, `module`, `hall`.

**Format:** `.lnsh` is a standard ZIP archive:
* `meta.json` — manifest: localizations (`lang: ruRU` / `enUS`), `type` and a `permissions` list
* `main.lsi` — deployment script
* `*.service` — service and form registration, `daemon ... end` blocks
* `assets/` — `Form1.cs` and `Form1.designer.cs`

Package files are encrypted after install. An application requests its own
permissions; granted ones live in `/os/root/regedit/PERMISSIONS`.
The `superuser` right is never granted from the terminal — only by the
**SuperUser** application (`superuser`).

### Ready-made packages

| Archive | Package | Launch command |
|---------|---------|----------------|
| [`explorerApp.lnsh`](explorerApp.lnsh) | ExplorerApp 1.2.0 — file manager | `explorer`, `files` |
| [`webserverv2.lnsh`](webserverv2.lnsh) | WebServerV2 2.1.0 — server panel | `webserverv2`, `httpd` |
| [`sshapp.lnsh`](sshapp.lnsh) | SshApp 1.0.0 — network access from a phone or PC | `ssh-app` |
| [`superuserapp.lnsh`](superuserapp.lnsh) | SuperUserApp 1.0.0 — grants the superuser right | `superuser`, `su-app` |
| [`logsapp.lnsh`](logsapp.lnsh) | LogsApp 1.0.0 — kernel journal with search | `logs` |
| [`calcapp.lnsh`](calcapp.lnsh) | CalcApp 1.0.0 — calculator with history | `calc`, `calculator` |
| [`settingsapp.lnsh`](settingsapp.lnsh) | SettingsApp 1.0.0 — system settings | `settings`, `options` |
| [`storeapp.lnsh`](storeapp.lnsh) | StoreApp 1.0.0 — application catalog | `store`, `apps-store` |
| [`TemplateApp.lnsh`](TemplateApp.lnsh) | TemplateApp 1.1.0 — template | `template`, `tpl` |

The list used by the catalog app is [`catalog.json`](catalog.json); StoreApp,
the `store refresh` command and `apt install <name>` read it.

👉 **A ready-made skeleton and the full specification live in [`template/`](template/README.MD).**
👉 **To build your own: unpack any `.lnsh` — it is a plain ZIP inside.**
