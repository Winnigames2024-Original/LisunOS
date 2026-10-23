# 📦 Исходники LisunOS

`source.zip` — полный архив рабочей папки проекта: исходный код, решение
Visual Studio, пакеты приложений и каталог `bin` со сборками.

| | |
|---|---|
| Размер | 73,6 МБ |
| Файлов | 392 |
| Внутри | `LisunOS/` — та же структура, что в Visual Studio |

## Что внутри

```text
LisunOS/
├── LisunOS/            исходный код ядра: 37 файлов .cs, csproj, App.config
│   ├── bin/Debug/      сборка и развёрнутая рабочая среда files/os
│   ├── bin/Release/    то же для Release
│   └── obj/
├── apps/               пакеты: explorerv2app, webserverv2, template
├── packages/           NuGet: Fody, Costura.Fody
└── build.bat           сборка через MSBuild
```

## Что вырезано перед публикацией

Репозиторий открытый, поэтому из архива убраны учётные данные рабочей
установки. **Исходный код не изменён** — все 95 файлов `.cs`, `.csproj`,
`.php`, `.service` и `.lsi` совпадают с оригиналом байт в байт.

Удалённые файлы:

| Файл | Почему |
|------|--------|
| `files/os/root/regedit/.hall_token` | из него выводится ключ шифрования пакетов |
| `files/os/root/www/.api.key` | ключ доступа к `api.php` |
| `files/os/root/www/.panel.pass` | пароль веб-панели |
| `PythonToExeConverter_TemporaryKey.pfx` | сертификат подписи с закрытым ключом |

В файлах реестра `CONFIG` и `DATA` значения этих ключей заменены на
`<УДАЛЕНО ПРИ ПУБЛИКАЦИИ>`. Структура файлов сохранена, остальные
параметры на месте.

Все три значения генерируются заново при первом запуске, так что
собранная из этих исходников система поднимется со своими ключами.

## Сборка

```bat
build.bat
```

Скрипт находит MSBuild через `vswhere`, собирает `LisunOS\LisunOS.csproj`
в конфигурации Release и пишет отчёт в `build.log`. На выходе —
один `LisunOS\bin\Release\LisunOS.exe`.

Нужны **Visual Studio 2019 или новее** (либо Build Tools) и
**.NET Framework 4.8 Developer Pack**.

---
