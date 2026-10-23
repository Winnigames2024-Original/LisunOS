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

👉 **A ready-made skeleton and the full specification live in [`template/`](template/README.MD).**
