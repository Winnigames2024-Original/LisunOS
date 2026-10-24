# ⚡ LisunOS Core Engine v1.8

## 📥 Скачать

| | |
|---|---|
| **[LisunOS.exe — последний релиз](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS.exe)** | один файл, установщик не нужен |
| [LisunOS-1.8.4.zip](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS-1.8.4.zip) | exe + документация RU/EN + готовые пакеты |
| [Все релизы](https://winnigames2024-original.github.io/LisunOS/releases/) | что изменилось в каждой версии, прямые ссылки на файлы |
| [Сайт проекта](https://winnigames2024-original.github.io/LisunOS/) | описание и кнопка загрузки |

Как ставить утилиты: **[инструкция на русском](docs/install-ru.md)** ·
[in English](docs/install-en.md)

Требуется .NET Framework 4.8 (Windows 10 1903 и новее).

---

## 🆕 Что нового в 1.8.4

* **Система перестала подтормаживать.** Нашлось три причины, и все три
  убраны:
  * окно Wi-Fi каждые полторы секунды дважды запускало `netsh` — а это
    запуск `cmd.exe` и ещё процесса, примерно четверть секунды, прямо в
    потоке окна. Теперь ответ держится в памяти 5–30 секунд и
    перечитывается после подключения, отключения или поиска сетей;
  * список сетевых адаптеров опрашивался на каждый тик окна «Доступ по
    сети» — теперь он тоже кэшируется на три секунды;
  * журнал ядра рос без края: за долгий сеанс в нём набирались десятки
    тысяч строк, и окно журнала перебирало их целиком. Теперь предел —
    4000 строк.
* **`ssh autostart`** — удалённый вход поднимается вместе с системой:

  ```
  ssh autostart on          включить, порт запоминается
  ssh autostart on 2222     включить и задать порт
  ssh autostart off         выключить
  ssh autostart             что включено сейчас
  ```

  Порт запоминается и при обычном `ssh start`, так что автозапуск
  поднимет сервер на том же порту.

---

## 🆕 Что нового в 1.8.3

* **SuperUser живёт внутри системы** — `superuser install` ставит его из
  встроенного каталога, без сети вообще. С сайта он тоже ставится:
  `apt install superuser` — имена теперь ищутся по-человечески, `superuser`
  и `SuperUserApp` это одно и то же.
* **Специальные ключи SuperUser** — `enable_superuser` (может выдать
  другому пакету полный доступ) и `enable_su` (включает команду `su` в
  терминале). Пока такого приложения нет, `su` по-прежнему отвечает
  отказом.
* **Проводное соединение** — кабель теперь такое же подключение, как
  Wi-Fi: команда `net` показывает все адаптеры с адресами и шлюзами, а VPN
  и виртуальные коммутаторы (Radmin, Hamachi, Hyper-V, VMware, TAP) больше
  не выдают себя за кабель. Мастер и приложение Wi-Fi видят проводную сеть
  и не требуют искать точку доступа.
* **Права с официального сайта выдаются сами** — приложение, выбранное в
  каталоге или в мастере первого запуска, не спрашивает те же разрешения
  второй раз. Для чужих ссылок и файлов с диска окно запроса осталось.
* **Приложения работают сразу** — после установки ничего перезапускать не
  нужно: служба выполняется, команда регистрируется, окно открывается.

---

## 🆕 Что нового в 1.8.2

* **Мастер первого запуска** — при первом старте вместо терминала
  открывается окно с этапами, как при настройке телефона: язык, сеть со
  списком доступных Wi-Fi, выбор приложений из каталога на сайте,
  установка с полосой прогресса. Любой этап можно пропустить; вернуться —
  `setup`.
* **`store install apps.all`** ставит все приложения из каталога разом:
  установленные пропускаются, неудача одного не мешает остальным, в конце
  итог.
* **Пакет под паролем** — `pack <папка> <файл.lnsh> <пароль> [подсказка]`.
  Внутри такого `.lnsh` только `lock.json` и `payload.enc`: ключ из
  PBKDF2-SHA256 (120 000 проходов), шифрование AES-256-CBC, поверх
  HMAC-SHA256. При установке система спрашивает пароль в окне.
* **У каждой версии своё слово** — `ver list`. Слова идут по алфавиту в
  порядке выпусков: Aurora, Borealis, Cirrus… 1.8.2 — «Kelvin».
  Таблица лежит в `codenames.json`, оттуда её берут и система, и выпуск.
* **Нумерация** — номер растёт по младшей части: после 1.8.1 идёт 1.8.2.

---

## 🔧 1.8.1 — починен вход по ssh

В 1.8.0 клиент `ssh` отвечал `incorrect signature` и рвал соединение.
Причина: подпись обмена ключами считалась не от того значения — `SignHash`
в .NET подписывает переданный отпечаток как есть, а RFC 8332 требует
подпись над `SHA-256` от хеша обмена. Исправлено; рукопожатие проверено
настоящим клиентом OpenSSH 9.5 — до выдачи ключей сеанса и первого
зашифрованного пакета.

---

## 🆕 Что нового в 1.8.0

* **Приложение «Wi-Fi»** — отдельное окно со списком доступных сетей:
  имя, уровень сигнала полосками, защита и пометка «подключена» или
  «сохранена». Двойной щелчок подключает, пароль вводится рядом,
  список обновляется сам. Ставится как обычный пакет:
  `apt install wifiapp`, запуск — `wifi-app` или прежнее `wifi form`.
* **Загрузки** — одно место на всю систему: прогресс, скорость и остаток
  времени, зеркала, докачка оборванного файла с того же байта (Range),
  проверка sha256 и история в `/os/root/downloads`.
  Команда: `download <ссылка> [файл]`, `download list | history | cancel`.
* **Компоненты** — `lib list` показывает, что система может докачать
  (сборка PHP, документация, каталог пакетов, новый exe), а что уже
  внутри неё и качать нечего: SSH-2, Wi-Fi и движок PHP встроены в ядро.
  `lib install php`, `lib check`, `lib auto on|off`.
* **Обновление системы** — `update check` смотрит `releases.json` на сайте,
  `update download` качает новый `LisunOS.exe`, `update install`
  подменяет текущий файл и перезапускает систему. Прежний exe остаётся
  рядом как `.old`, подмена спрашивает подтверждение в окне.
* **Когда появился интернет**, система говорит, чего ей не хватает, —
  и ничего не качает молча.

---

## 🆕 Что нового в 1.7.0

* **Подтверждение паролем** — закрытое ограничением действие больше не
  отказ: система показывает окно, как контроль учётных записей в Windows,
  и спрашивает пароль администратора. Разрешение действует пять минут.
  Пароль задаётся при первом запуске, можно пропустить.
* **Токены вместо коротких имён** — `user limit www add PERMISSION_CREATE_FILES`.
  Работа с файлами разделена на чтение, создание, правку и удаление.
* **`ALLOW_PERMISSION_*_REQUEST`** закрывает приложению право *попросить*
  возможность: окно запроса не появится.
* **Сайт — это `www`** — веб-сервер и `api.php` работают от имени этой
  записи, её ограничения проверяются на входе в `api.php`.
* **Окно запроса прав** переделано: карточки, текущий пользователь,
  опасные права выделены.
* **Учётная запись без пароля** — `user create имя` работает локально,
  но по сети под ней не войти.

---

---

## 🆕 Что нового в 1.6.0

* **Настоящий SSH-2** — подключается обычный клиент `ssh`, с компьютера и
  с телефона: `ssh имя@192.168.0.5 -p 2222`. Обмен ключами
  diffie-hellman-group14-sha256, ключ хоста rsa-sha2-256, шифр aes128-ctr,
  контроль hmac-sha2-256. Собрано из того, что есть в .NET — скачивать и
  ставить ничего не нужно.
* **Простой режим остался** на том же порту: telnet, nc, PuTTY Raw.
  Протокол выбирается по первым байтам клиента.
* **Имя в приглашении** — `LisunOS root:\>`. Сменить: `user current set <имя>`.
* **Ограничения** для всех, кроме root: `user limit <имя> add <область>`.
  Семь областей — файлы, пакеты, сеть, пользователи, приложения, система,
  повышение прав. Проверка идёт до выполнения команды.

---

---

## 🆕 Что нового в 1.5.0

* **Сеанс по сети стал полноценным** — по ssh доступны все команды, включая
  добавленные приложениями. Окна при этом открываются в LisunOS на
  компьютере, а в ssh приходит строка об этом: форму в текстовом канале
  не показать.
* **У каждого сеанса своя текущая папка** — `cd` по сети не уводит ни
  терминал, ни других подключённых; приглашение показывает путь.
* **Наружу из системы сеанс не выходит** — пути диска Windows закрыты,
  видна только файловая система LisunOS.
* **`ssh who`** показывает, кто сейчас в сети, **`ssh help`** — чем сеанс
  отличается от терминала. В самом сеансе работают `clear`, `!!` и `?`.
* **Сайт**: страница [пакетов](https://winnigames2024-original.github.io/LisunOS/apps/)
  и [читалка markdown](https://winnigames2024-original.github.io/LisunOS/mdreader/) —
  любой `.md` открывается по адресу `/mdreader/?url=<ссылка>`.

---

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


# ⚡ LisunOS Core Engine v1.8

## 📥 Download

| | |
|---|---|
| **[LisunOS.exe — latest release](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS.exe)** | a single file, no installer |
| [LisunOS-1.8.4.zip](https://github.com/Winnigames2024-Original/LisunOS/releases/latest/download/LisunOS-1.8.4.zip) | exe + RU/EN documentation + ready-made packages |
| [All releases](https://winnigames2024-original.github.io/LisunOS/releases/) | what changed in every version, with direct file links |
| [Project site](https://winnigames2024-original.github.io/LisunOS/) | overview and a download button |

How to install the utilities: **[guide in English](docs/install-en.md)** ·
[на русском](docs/install-ru.md)

Requires .NET Framework 4.8 (Windows 10 1903 and newer).

---

## 🆕 What is new in 1.8.4

* **The system stopped stuttering.** Three causes, all three removed:
  * the Wi-Fi window ran `netsh` twice every 1.5 seconds — that is a
    `cmd.exe` plus another process, about a quarter of a second, right on
    the window thread. The answer is now kept in memory for 5–30 seconds
    and re-read after connecting, disconnecting or scanning;
  * the adapter list was polled on every tick of the "Network access"
    window — it is cached for three seconds now;
  * the kernel journal grew without a bound: a long session piled up tens
    of thousands of lines and the journal window walked all of them. The
    limit is 4000 lines now.
* **`ssh autostart`** — the remote login starts with the system:

  ```
  ssh autostart on          on, the port is remembered
  ssh autostart on 2222     on, with the port set
  ssh autostart off         off
  ssh autostart             what is set now
  ```

  The port is remembered by a plain `ssh start` too, so autostart brings
  the server up on the same one.

---

## 🆕 What is new in 1.8.3

* **SuperUser lives inside the system** — `superuser install` installs it
  from the built-in catalog with no network at all. It still installs from
  the site too: `apt install superuser` — names are matched the human way
  now, `superuser` and `SuperUserApp` are the same thing.
* **The SuperUser keys** — `enable_superuser` (may give another package
  full access) and `enable_su` (enables the `su` command in the terminal).
  Until such an application exists, `su` still refuses.
* **Wired connections** — a cable is now as much a connection as Wi-Fi: the
  `net` command lists every adapter with its address and gateway, and VPN
  or virtual switches (Radmin, Hamachi, Hyper-V, VMware, TAP) no longer
  pass themselves off as a cable. The wizard and the Wi-Fi application see
  the wired network and stop asking for an access point.
* **Rights from the official site are granted automatically** — an
  application picked in the catalog or in the first-run wizard is not asked
  about the same permissions twice. For other links and files from disk the
  request window stays.
* **Applications work right away** — nothing needs restarting after an
  install: the service runs, the command is registered, the window opens.

---

## 🆕 What is new in 1.8.2

* **The first-run wizard** — on the first start a window with steps opens
  instead of the terminal, the way a phone asks its questions: language,
  the network with the Wi-Fi around you, the applications from the site's
  catalog, and the install with a progress bar. Any step can be skipped;
  `setup` brings it back.
* **`store install apps.all`** installs every application from the catalog
  at once: installed ones are skipped, one failure does not stop the rest,
  and a tally closes it.
* **A locked package** — `pack <folder> <file.lnsh> <password> [hint]`.
  Such a `.lnsh` holds only `lock.json` and `payload.enc`: a PBKDF2-SHA256
  key (120 000 rounds), AES-256-CBC encryption and an HMAC-SHA256 tag. The
  system asks for the password in a window at install time.
* **Every version has a word of its own** — `ver list`. The words are
  alphabetical in release order: Aurora, Borealis, Cirrus… 1.8.2 is
  "Kelvin". The table lives in `codenames.json`, read both by the system
  and by the release.
* **Numbering** — the number grows in its last part: 1.8.1 is followed by
  1.8.2.

---

## 🔧 1.8.1 — the ssh login is fixed

In 1.8.0 the `ssh` client answered `incorrect signature` and dropped the
connection. The cause: the key-exchange signature was computed over the
wrong value — .NET's `SignHash` signs the digest it is given as is, while
RFC 8332 requires a signature over `SHA-256` of the exchange hash. Fixed;
the handshake was verified with a real OpenSSH 9.5 client, through session
key derivation and the first encrypted packet.

---

## 🆕 What is new in 1.8.0

* **The Wi-Fi application** — a window of its own with the networks around
  you: the name, the signal as bars, the security and a mark for
  "connected" or "saved". A double click connects, the password sits next
  to the list, and the list refreshes itself. It installs like any other
  package: `apt install wifiapp`, launched with `wifi-app` or the old
  `wifi form`.
* **Downloads** — one place for the whole system: progress, speed and time
  left, mirrors, a broken file resuming at the same byte (Range), sha256
  checks and a history in `/os/root/downloads`.
  The command: `download <url> [file]`, `download list | history | cancel`.
* **Components** — `lib list` shows what the system can fetch (the PHP
  build, the documentation, the package catalog, a new exe) and what is
  already inside it with nothing to download: SSH-2, Wi-Fi and the PHP
  engine are built into the kernel.
  `lib install php`, `lib check`, `lib auto on|off`.
* **Updating the system** — `update check` reads `releases.json` on the
  site, `update download` fetches the new `LisunOS.exe`, and
  `update install` replaces the current file and restarts the system. The
  old exe stays next to it as `.old`, and the swap asks for confirmation
  in a window.
* **When the internet appears**, the system says what it is missing — and
  downloads nothing silently.

---

## 🆕 What is new in 1.7.0

* **Confirming with a password** — an action closed by a limit is no longer
  a flat refusal: the system shows a window, like User Account Control in
  Windows, and asks for the administrator password. The permission lasts
  five minutes. The password is set on the first run and can be skipped.
* **Tokens instead of short names** — `user limit www add PERMISSION_CREATE_FILES`.
  File work is split into reading, creating, editing and deleting.
* **`ALLOW_PERMISSION_*_REQUEST`** closes an application's right to *ask*
  for a capability: the request window never appears.
* **The site is `www`** — the web server and `api.php` run as that account,
  and its limits are checked at the entrance to `api.php`.
* **The permission request window** was redone: cards, the current user,
  dangerous rights highlighted.
* **An account with no password** — `user create name` works locally but
  cannot sign in over the network.

---

---

## 🆕 What is new in 1.6.0

* **Real SSH-2** — a regular `ssh` client connects, from a computer and from
  a phone: `ssh name@192.168.0.5 -p 2222`. Key exchange
  diffie-hellman-group14-sha256, host key rsa-sha2-256, cipher aes128-ctr,
  MAC hmac-sha2-256. Built from what .NET already provides — nothing to
  download or install.
* **The plain mode stayed** on the same port: telnet, nc, PuTTY Raw. The
  protocol is chosen by the client's first bytes.
* **The name in the prompt** — `LisunOS root:\>`. Switch it with
  `user current set <name>`.
* **Limits** for everyone except root: `user limit <name> add <area>`.
  Seven areas — files, packages, network, users, applications, system,
  elevation. The check happens before the command runs.

---

---

## 🆕 What is new in 1.5.0

* **A network session is now a real one** — every command is available over
  ssh, including the ones applications added. Windows still open in LisunOS
  on the computer and ssh receives a line about it: a form cannot be shown
  over a text channel.
* **Each session has its own directory** — `cd` over the network moves
  neither the terminal nor the other clients; the prompt shows the path.
* **A session cannot step outside the system** — Windows drive paths are
  closed, only the LisunOS file system is visible.
* **`ssh who`** shows who is online, **`ssh help`** explains how a session
  differs from the terminal. Inside a session `clear`, `!!` and `?` work.
* **The site**: a [packages page](https://winnigames2024-original.github.io/LisunOS/apps/)
  and a [markdown reader](https://winnigames2024-original.github.io/LisunOS/mdreader/) —
  any `.md` opens at `/mdreader/?url=<link>`.

---

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
