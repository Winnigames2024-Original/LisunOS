# 📦 Спецификация пакета `.lnsh` и шаблон приложения LisunOS

Пакет **`.lnsh`** — обычный **ZIP-архив** со строго определённым набором
файлов. Эта папка — готовый скелет: скопируйте, переименуйте, и у вас
своё приложение.

```text
[Корень архива]
├── meta.json             <- манифест, массив локализаций
├── main.lsi              <- сценарий развёртывания
├── template.service      <- регистрация службы и формы в ядре
└── assets/
    ├── Form1.cs          <- связка с логикой приложения
    └── Form1.designer.cs <- разметка интерфейса
```

## 📦 Сборка пакета

```text
pack template                       соберёт template.lnsh рядом
pack template myapp.lnsh            имя файла своё
```

В папке должен лежать `meta.json` — по нему система и понимает, что это
пакет.

---

## 🔒 Пакет под паролем

Свой пакет можно закрыть паролем — тогда его не прочитает и не поставит
тот, кому вы пароль не дали:

```text
pack template myapp.lnsh секрет              пароль
pack template myapp.lnsh секрет имя кота     ещё и подсказка
```

Такой `.lnsh` устроен иначе обычного:

```text
myapp.lnsh
├── lock.json      соль, вектор, число проходов, подсказка
└── payload.enc    весь пакет целиком, зашифрованный
```

Ключ выводится из пароля (**PBKDF2-SHA256, 120 000 проходов**), данные
шифруются **AES-256-CBC**, поверх считается **HMAC-SHA256**. Пароль не
хранится нигде: ни в пакете, ни в системе. Подменить содержимое, не зная
пароля, нельзя — отпечаток не сойдётся.

При установке система показывает окно с подсказкой и просит пароль, три
попытки. По `ssh` закрытый пакет не ставится: окно ввода показать некому.

---

## 🚀 Установка

```text
apt update TemplateApp            # сведения из meta.json, проверка версии
apt install <ссылка.lnsh>         # или: sudo apt install <ссылка.lnsh>
template                          # запуск формы
```

`apt update <name>` ищет пакет по полю `name` манифеста. После установки
`main.lsi`, `*.service` и содержимое `assets/` **шифруются**
(AES-256-CBC, заголовок `LSNC1`, ключ выводится из токена зала через
PBKDF2, 20 000 итераций) — исходники пакета не остаются на диске
открытыми.

---

## 📄 1. Манифест: `meta.json`

Манифест — **массив**: по одной записи на язык, поле `lang` обязательно.
Ядро берёт запись под текущий язык системы, при отсутствии — первую.

```json
[
  {
    "name": "TemplateApp",
    "lang": "ruRU",
    "type": "service",
    "title": "Шаблон приложения",
    "description": "Основа для своего приложения LisunOS",
    "version": "1.0.0",
    "author": "LisunOS",
    "permissions": [ "read_files", "write_files", "show_dialogs" ],
    "url": "https://github.com/Winnigames2024-Original/LisunOS/raw/main/apps/template/TemplateApp.lnsh"
  },
  {
    "name": "TemplateApp",
    "lang": "enUS",
    "type": "service",
    "title": "Application template",
    "description": "A starting point for your own LisunOS app",
    "version": "1.0.0",
    "author": "LisunOS",
    "permissions": [ "read_files", "write_files", "show_dialogs" ],
    "url": "https://github.com/Winnigames2024-Original/LisunOS/raw/main/apps/template/TemplateApp.lnsh"
  }
]
```

Поддерживается и старая форма — один объект без `lang`. Разбор ведёт
собственный JSON-парсер с восстановлением после опечаток, так что лишняя
запятая установку не сорвёт.

### 🔐 Разрешения

| Право           | Что открывает                        |
|-----------------|--------------------------------------|
| `superuser`     | всё сразу, выдаётся только вручную   |
| `read_files`    | чтение файлов системы                |
| `write_files`   | создание файлов                      |
| `edit_files`    | правка существующих файлов           |
| `manage_files`  | перемещение и удаление               |
| `edit_settings` | запись в реестр и настройки          |
| `network`       | сеть, сокеты, сервер                 |
| `run_services`  | запуск других служб                  |
| `show_dialogs`  | окна сообщений                       |
| `autostart`     | запуск вместе с системой             |

Приложение запрашивает права **само**: в `main.lsi` через
`request_permission`, в коде через `LisunPermissions.Demand(...)`.
Отклонённое право спрашивается повторно при следующей попытке, выданные
хранятся в `/os/root/regedit/PERMISSIONS`.

---

## ⚙️ 2. Сценарий установки: `main.lsi`

```ini
require_core 1.1.0
log Развёртывание TemplateApp

mkdir root/template
set_data template_counter=0

request_permission read_files
request_permission write_files
request_permission show_dialogs

register_service template.service
register_command tpl -> templateApp

protect
request_restart
```

Полный список директив:

| Директива                    | Действие                                        |
|------------------------------|-------------------------------------------------|
| `require_core <версия>`      | прервать установку на старом ядре               |
| `register_service <файл>`    | подключить службу (псевдоним — `run`)           |
| `register_command a -> app`  | добавить ещё одну команду запуска               |
| `download_file <url>>файл`   | скачать ресурс (нужно право `network`)          |
| `unpack <архив>`             | распаковать архив внутри пакета                 |
| `copy <из> <куда>`           | скопировать файл                                |
| `mkdir <путь>`               | создать папку в виртуальной ФС                  |
| `delete <путь>`              | удалить файл или папку                          |
| `set_data KEY=VALUE`         | записать в реестр `DATA`                        |
| `set_config KEY=VALUE`       | записать в реестр `CONFIG`                      |
| `request_permission <право>` | запросить право у пользователя                  |
| `log <текст>`                | строка в журнал терминала                       |
| `message <текст>`            | окно сообщения                                  |
| `protect` / `no_protect`     | включить/выключить шифрование пакета            |
| `request_restart`            | предложить перезапуск подсистем                 |

---

## 🖼️ 3. Служба и форма: `template.service`

```ini
import winforms

winforms.Application templateApp = new winforms.Application()
winforms.Form MainForm = new winforms.Form("%appfiles%\Form1.cs", "%appfiles%\Form1.designer.cs")

MainForm.size       = 760, 520
MainForm.minsize    = 560, 400
MainForm.background = #0D1117
MainForm.foreground = #CED6E0
MainForm.center     = true
MainForm.resizable  = true

templateApp.program.addForm(MainForm)

templateApp.title       = "Шаблон приложения"
templateApp.description = "Основа для своего приложения LisunOS"
templateApp.namespace   = "template"
templateApp.command     = "tpl"
templateApp.command     = "demo"
templateApp.autostart   = false

log Шаблон готов. Запуск: template, tpl, demo
```

**Свойства формы** (`<переменная формы>.<свойство>`): `title`, `size`,
`width`, `height`, `minsize`, `background`, `foreground`, `opacity`,
`topmost`, `resizable`, `center`, `maximized`, `padding`.

**Свойства приложения** (`<переменная приложения>.<свойство>`): `title`,
`description`, `namespace`, `command`, `icon`, `autostart`.

**Методы**: `program.addForm(Form)`, `program.setDefaultForm(Form)`,
`show()`, `hide()`.

`autostart = true` сработает только если выдано право `autostart`.

---

## 🧩 4. Разметка: `assets/Form1.designer.cs`

Файл разбирается ядром как текст: создаются контролы, применяются
свойства, привязываются обработчики. Доступны `Panel`, `Label`,
`TextBox`, `Button`, `CheckBox`, `ListBox`, `ProgressBar`, `ComboBox`,
`TrackBar`, `PictureBox` и другие контролы WinForms.

```csharp
this.btnHello = new System.Windows.Forms.Button();
this.btnHello.Text     = "Поздороваться";
this.btnHello.Location = new System.Drawing.Point(24, 300);
this.btnHello.Size     = new System.Drawing.Size(180, 36);
this.btnHello.Click   += new System.EventHandler(this.btnHello_Click);
this.pnlBody.Controls.Add(this.btnHello);
```

Имена контролов — это ключи, по которым мост логики их находит, поэтому
переименование контрола требует правки моста.

---

## 🔒 5. Защищённые блоки текста

```text
~~~NOREMOVE~    строки нельзя менять, файл нельзя удалить    ~NOREMOVE~~~
~~~CANTEDIT~    текст нельзя менять, файл удалить можно      ~CANTEDIT~~~
```

Проводник и файловый менеджер веб-сервера открывают такие файлы на
правку, но при сохранении сверяют защищённые блоки и предлагают
восстановить изменённые строки. В `assets/Form1.cs` под `CANTEDIT` лежит
объявление `TemplateLogicBridge` — ядро ищет логику формы именно по этому
имени.

---

## 🔗 6. Мост логики на стороне ядра

`LisunOS/TemplateLogicBridge.cs`:

```csharp
public TemplateLogicBridge(DynamicFormContext context)
{
    form  = context.Form;
    hello = context.Get<Button>("btnHello");
    log   = context.Get<ListBox>("lstLog");
}

private void btnCount_Click(object sender, EventArgs e)
{
    if (!LisunPermissions.Demand(packageName, LisunPermissions.EditSettings)) return;

    LisunEngine.RegistryData["template_counter"] = next.ToString();
    LisunEngine.SaveRegistry();
}
```

`FormEngine.CreateLogicBridge` выбирает мост по наличию контрола
(`btnHello`) или по имени пакета, `InitializeBridge` вызывает
`Initialize()` после построения формы.

---

## 🛠️ Как сделать своё приложение

1. Скопируйте `apps/template` в `apps/<ваше-имя>`.
2. Поменяйте `name`, `title`, `version`, `permissions` и `url` **во всех**
   языковых записях `meta.json`.
3. Переименуйте `template.service`, поправьте `namespace` и `command`.
4. Нарисуйте форму в `assets/Form1.designer.cs`.
5. Напишите мост по образцу `TemplateLogicBridge.cs`, зарегистрируйте его
   в `FormEngine` и в `LisunOS.csproj`.
6. Добавьте строки интерфейса в `LisunLocale.cs` — для обоих языков.
7. Упакуйте папку в ZIP, переименуйте в `<Имя>.lnsh`, выложите по `url`.
