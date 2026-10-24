# Языковые пакеты LisunOS

Каждый файл `<код>.json` — один язык интерфейса. Положите файл в эту папку
и выполните в терминале:

    lang reload
    lang <код>

## Формат

    {
        "code": "de",            код языка, он же имя файла
        "name": "Deutsch",       как язык называется в списке
        "layout": "de",          раскладка клавиатуры, включается вместе с языком
        "manifest": "deDE",      тег для поля lang в meta.json пакетов
        "base": "en",            язык для непереведённых строк: ru или en
        "strings": {
            "menu.exit": "Beenden",
            ...
        }
    }

Переводить все строки не обязательно: то, чего нет в пакете, берётся из
языка-основы. Команда `lang list` показывает, сколько процентов переведено.

## Свой язык

    lang export it

Создаст `it.json` со всеми строками системы и английскими значениями.
Переведите значения, затем `lang reload` и `lang it`.

---

# LisunOS language packs

Each `<code>.json` file is one interface language. Drop the file into this
folder and run:

    lang reload
    lang <code>

Untranslated strings fall back to the `base` language, so a partial pack is
still usable; `lang list` shows how complete each pack is.

To start a new language, run `lang export <code>` — it writes a file with
every string of the system and English values to translate.
