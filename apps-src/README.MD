# apps-src — исходники пакетов

Папка `apps/` — витрина: там лежат только готовые архивы `.lnsh`, каталог
`catalog.json` и `template/` как образец для своих приложений.

Исходники самих пакетов живут здесь. Каждая папка — один пакет:

| Папка | Пакет | Команда |
|---|---|---|
| `calcapp` | CalcApp | `calc-app` |
| `explorerv2app` | ExplorerApp | `explorer` |
| `logsapp` | LogsApp | `logs` |
| `settingsapp` | SettingsApp | `settings` |
| `sshapp` | SshApp | `ssh-app` |
| `storeapp` | StoreApp | `store-app` |
| `superuserapp` | SuperUserApp | `su-app` |
| `webserverv2` | WebServerV2 | `httpd` |

## Как собрать пакет заново

Пакет `.lnsh` — это обычный ZIP без шифрования: установщик расшифровывает
файлы уже внутри системы, при `protect`. Собрать можно любым архиватором,
главное — складывать файлы в корень архива, а не в подпапку с именем пакета:

```
meta.json
main.lsi
<имя>.service
assets/Form1.cs
assets/Form1.designer.cs
```

PowerShell:

```powershell
cd "C:\Visual Studio Projects\LisunOS\apps-src\sshapp"
Compress-Archive -Path * -DestinationPath ..\..\apps\sshapp.lnsh -Force
```

После сборки поправьте версию пакета в `meta.json` **и** в
`apps/catalog.json` — по ним система понимает, что вышло обновление,
и `apt update <имя>` его подхватывает.

## Что где лежит

* `meta.json` — имя, тип (`app`, `service`, `daemon`, `library`, `theme`,
  `locale`, `module`, `hall`), версия, запрашиваемые права. Массив записей
  с полем `lang` даёт описание на нескольких языках.
* `main.lsi` — сценарий установки: `request_permission`, `register_service`,
  `register_command`, `protect`, `deploy`.
* `*.service` — описание приложения и формы, плюс блоки `daemon ... end`
  для фоновых служб.
* `assets/Form1.designer.cs` — разметка окна; её разбирает FormEngine.
* `assets/Form1.cs` — связка с логикой в ядре (имя класса менять нельзя).
