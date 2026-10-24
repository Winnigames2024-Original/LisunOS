# ⚡ LisunOS Core Engine v1.4

## 📥 Скачать

| | |
|---|---|
| **[LisunOS.exe — последний релиз](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS.exe)** | один файл, установщик не нужен |
| [LisunOS-1.4.0.zip](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS-1.4.0.zip) | exe + документация RU/EN + готовые пакеты |
| [Все релизы](https://winnigames2024-original.github.io/LisunOS/releases.html) | что изменилось в каждой версии, прямые ссылки на файлы |
| [Сайт проекта](https://winnigames2024-original.github.io/LisunOS/) | описание и кнопка загрузки |

Как ставить утилиты: **[инструкция на русском](docs/install-ru.md)** ·
[in English](docs/install-en.md)

Требуется .NET Framework 4.8 (Windows 10 1903 и новее).

---

## 🆕 Что нового в 1.4.0

* **SuperUser** — право `superuser` больше не выдаётся командой `su`: она
  сообщает об ошибке. Пакет выбирают в списке приложения **SuperUser**
  (команда `superuser`), ставят флажок подтверждения и нажимают
  «Выдать superuser».
* **Вход по сети** — команда `ssh` показывает адрес этой машины, а
  приложение **«Доступ по сети»** (`ssh-app`) включает сервер, заводит
  пользователей и показывает, кто подключался. Подключаются с телефона или
  другого ПК: PuTTY (тип **Raw** или **Telnet**) либо `nc <адрес> 2222`.
  Пользователи: `user create|edit|remove <имя> <пароль>`.
* **Журнал** — приложение `logs`: поиск по записям, фильтр по источнику,
  выгрузка в файл.
* **`apt install <имя>`** качает пакет с сайта по каталогу, а не только по
  прямой ссылке на `.lnsh`. Встроенная копия остаётся запасным вариантом,
  когда сети нет.
* **Восемь типов пакетов** вместо одного `service`: `app`, `service`,
  `daemon`, `library`, `theme`, `locale`, `module`, `hall` — команда `types`.
* **Девятнадцать прав** вместо одиннадцати: добавлены `background`,
  `listen`, `manage_packages`, `manage_users`, `appearance`, `clipboard`,
  `run_external`, `read_log`.
* **Проводник** — вперёд/домой/обновить, правка пути в адресной строке,
  фильтр по имени, выделение нескольких объектов, копирование и
  перемещение, упаковка в `.zip` и распаковка, свойства, сортировка по
  столбцам, строка состояния, горячие клавиши.
* **Сервер** — список узлов из конфигурации, `Перечитать конфиг` без
  остановки сервера, фильтр журнала, счётчик отданных байт.
* **API 1.3** — добавлены `head`, `tail`, `grep`, `replace`, `touch`, `du`,
  `mime`, `json`, `csv`, `base64`, `zip`, `unzip`, `packages`.

---

---


Добро пожаловать в документацию проекта **LisunOS Core Engine** — легковесного расширяемого движка на базе **C# Windows Forms**, имитирующего работу операционной системы. Система поддерживает выполнение собственных скриптов развёртывания, работу со встроенным реестром, пакетную установку приложений из архивов и содержит интегрированную строку ввода.

---

## 🛠️ Архитектура и Структура Системы

После первого запуска исполняемого файла движок автоматически разворачивает рабочую среду в папке размещения `.exe` по следующему пути:

```text
[Директория .exe]
└── files/
    └── os/
        ├── root/
        │   └── regedit/
        │       ├── CONFIG       <- Системные конфигурационные параметры ядра
        │       └── DATA         <- Пользовательские переменные и настройки среды
        ├── sys/
        │   └── services/        <- Папка хранения всех установленных служб и приложений
        └── temp/                <- Изолированная папка для временных файлов и кэша
```

---

## 🖥️ Все Доступные Системные Команды

Введите эти инструкции в терминале `LisunOS:\>` для управления ядром:

### Базовые команды ядра
* `help` — Отобразить полный список доступных встроенных утилит и динамически зарегистрированных пространств имен.
* `clear` — Полная очистка экрана текстового лога консоли.

### Работа со встроенным веб-интерфейсом
* `webview <ссылка_или_запрос>` — Переключить интерфейс на встроенный браузер. Если передан обычный текст, откроется поиск Google.
  * **Примечание:** Для возврата обратно к истории логов нажмите красную кнопку **✕ Скрыть Панель** в верхнем правом углу веб-интерфейса.
  * **Безопасность:** При попытке открыть незащищенный сайт (`http://`) система заблокирует переход и выведет кастомный экран предупреждения со ссылкой возврата.
  * **Масштабирование:** Браузер снабжен функцией автоматического масштабирования контента (Auto-Zoom) под текущие физические размеры окна.

### Управление системным реестром
* `regedit -config` — Посмотреть текущую таблицу конфигурационных параметров ядра ОС из файла `CONFIG`.
* `regedit -data` — Посмотреть пользовательские переменные среды из файла `DATA`.
* `regedit -set:KEY -val:VALUE` — Записать новый параметр или обновить существующий ключ в реестре `DATA` с мгновенным сохранением изменений на диск.

### Пакетный менеджер
* `apt install <прямая_ссылка_на_пакет.lnsh>` — Пакетный установщик. Автоматически скачивает архив из сети во временную папку `/os/temp/`, проверяет целостность манифеста, выполняет сценарий установки `main.lsi`, размещает файлы в `/sys/services/` и регистрирует новые команды консоли без перезапуска программы.

### Динамические команды приложений
* `<namespace_установленного_приложения>` — Вызов любой команды, созданной установленными пакетами (например, команда `explorer` вызывает окно Проводника, а команда `template` вызовет окно Шаблона).


# ⚡ LisunOS Core Engine v1.4

## 📥 Download

| | |
|---|---|
| **[LisunOS.exe — latest release](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS.exe)** | a single file, no installer |
| [LisunOS-1.4.0.zip](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS-1.4.0.zip) | exe + RU/EN documentation + ready-made packages |
| [All releases](https://winnigames2024-original.github.io/LisunOS/releases.html) | what changed in every version, with direct file links |
| [Project site](https://winnigames2024-original.github.io/LisunOS/) | overview and a download button |

How to install the utilities: **[guide in English](docs/install-en.md)** ·
[на русском](docs/install-ru.md)

Requires .NET Framework 4.8 (Windows 10 1903 and newer).

---

## 🆕 What is new in 1.4.0

* **SuperUser** — the `superuser` right is no longer granted by `su`, which
  now reports an error. Pick the package in the **SuperUser** application
  (the `superuser` command), tick the confirmation box and press
  "Grant superuser".
* **Network sign-in** — the `ssh` command prints this machine's address, and
  the **Network access** application (`ssh-app`) starts the server, creates
  users and shows who connected. Connect from a phone or another PC with
  PuTTY (connection type **Raw** or **Telnet**) or `nc <address> 2222`.
  Users: `user create|edit|remove <name> <password>`.
* **Journal** — the `logs` application: search, a source filter and export
  to a file.
* **`apt install <name>`** downloads a package from the site catalog, not
  only from a direct `.lnsh` link. The built-in copy stays as the fallback
  when there is no network.
* **Eight package types** instead of a single `service`: `app`, `service`,
  `daemon`, `library`, `theme`, `locale`, `module`, `hall` — the `types`
  command.
* **Nineteen rights** instead of eleven: `background`, `listen`,
  `manage_packages`, `manage_users`, `appearance`, `clipboard`,
  `run_external`, `read_log` were added.
* **File manager** — forward/home/refresh, an editable address bar, a name
  filter, multiple selection, copy and move, packing into `.zip` and
  unpacking, properties, column sorting, a status bar and shortcuts.
* **Server** — the hosts from the configuration, "Reload config" without
  stopping the server, a log filter and a sent-bytes counter.
* **API 1.3** — `head`, `tail`, `grep`, `replace`, `touch`, `du`, `mime`,
  `json`, `csv`, `base64`, `zip`, `unzip` and `packages` were added.

---

---

Welcome to the documentation for **LisunOS Core Engine** — a lightweight, extensible shell engine based on **C# Windows Forms** that simulates basic operating system workflows. The system supports custom deployment script execution, an integrated text registry, package-based application deployment from compressed archives, and a modern terminal UI.

---

## 🛠️ Architecture and Directory Structure

Upon its first execution, the engine automatically deploys its operational subsystem relative to the `.exe` file path:

```text
[.exe Directory]
└── files/
    └── os/
        ├── root/
        │   └── regedit/
        │       ├── CONFIG       <- Core system parameters and engine state
        │       └── DATA         <- User environment variables and localized settings
        ├── sys/
        │   └── services/        <- Target deployment path for all installed modules
        └── temp/                <- Isolated workspace for caching and package download
```

---

## 🖥️ All Available System Commands

Enter these directives into the `LisunOS:\>` console line to manage the kernel:

### Core Commands
* `help` — Render a comprehensive list of all loaded built-in utilities and dynamically registered workspace namespaces.
* `clear` — Wipe the text buffer of the terminal output screen.

### Embedded WebView Shell
* `webview <url_or_search_query>` — Switch the window runtime to the integrated browser panel. Plain text queries redirect to Google.
  * **Note:** To exit the browser viewport and return to the log shell history, click the crimson **✕ Hide Panel** button in the upper-right corner of the view.
  * **Security:** Unsecured endpoints (`http://`) are automatically intercepted. The engine blocks the operation and prints a custom warning page.
  * **Auto-Zoom:** The viewport calculates scale coordinates dynamically to lock element sizing relative to the container frame width.

### Integrated Registry Management
* `regedit -config` — Dump the key-value core kernel variables from the `CONFIG` table state.
* `regedit -data` — Dump active runtime variables from the localized `DATA` table.
* `regedit -set:KEY -val:VALUE` — Commit a new parameter or update an existing descriptor in the `DATA` namespace with immediate disk serialization.

### Package Manager
* `apt install <direct_url_to_package.lnsh>` — Automated installer shell. Downloads the compressed asset array over the network to the `/os/temp/` folder, evaluates metadata validation, executes the `main.lsi` setup script, copies the binaries to `/sys/services/`, and mounts new namespaces on the fly without application reboots.

### Dynamic App Execution
* `<installed_app_namespace>` — Fire any command initialized by hot-loaded services (e.g., executing `explorer` opens the System File Explorer, while executing `template` brings up the App Template interface).
