# Installing LisunOS utilities

This document explains how to install and set up the built-in utilities of
LisunOS 1.1.0 "Aurora". Every command is typed into the system terminal —
the `LisunOS:\>` prompt on the Terminal tab.

---

## Contents

1. [First run](#first-run)
2. [The apt package manager](#the-apt-package-manager)
3. [Applications: Explorer and Server](#applications-explorer-and-server)
4. [PHP — the php-frm module](#php--the-php-frm-module)
5. [Wi-Fi](#wi-fi)
6. [System port 8989](#system-port-8989)
7. [Web server and panel](#web-server-and-panel)
8. [The ufw firewall](#the-ufw-firewall)
9. [Services with systemctl](#services-with-systemctl)
10. [Permissions](#permissions)
11. [Troubleshooting](#troubleshooting)

---

## First run

Unpack the archive and run `LisunOS.exe`. It needs **.NET Framework 4.8**
(shipped with Windows 10 version 1903 and newer). There is no installer —
the working environment is deployed next to the `.exe` on first start:

```text
[folder with the .exe]
└── files/os/
    ├── root/regedit/   CONFIG and DATA — the system registry
    ├── root/www/       site root
    ├── sys/services/   installed applications
    ├── sys/php/        own PHP, once downloaded
    └── temp/           temporary files
```

Useful right away:

```text
help              list every command
sysinfo           system information
lang ru           switch the interface to Russian
layout            keyboard layout
```

---

## The apt package manager

```text
apt list                     what is installed
apt update <name>            package details from meta.json
apt install <url.lnsh>       install a package from a link
apt install <name>           install from the built-in catalog
apt remove <name>            remove a package
apt info <name>              details and granted rights
sudo apt install <...>       the same as superuser
```

A `.lnsh` package is a plain ZIP holding `meta.json`, `main.lsi`, a service
file and an `assets` folder. After installation the package files are
encrypted (AES-256-CBC), so no sources are left in the open on disk.

---

## Applications: Explorer and Server

Both archives are in the release, in the `packages` folder, and on GitHub
under `apps`.

```text
apt install https://github.com/Winnigames2024-Original/LisunOS/raw/main/apps/explorerApp.lnsh
apt install https://github.com/Winnigames2024-Original/LisunOS/raw/main/apps/webserverv2.lnsh
```

During installation the system asks for rights — the application requests
them itself.

| Package | Version | Launch | What it does |
|---------|---------|--------|--------------|
| ExplorerApp | 1.1.0 | `explorer`, `files` | file manager for the virtual file system |
| WebServerV2 | 2.0.0 | `webserverv2`, `httpd`, `server`, `www` | HTTP server control panel |
| TemplateApp | 1.0.0 | `template`, `tpl`, `demo` | skeleton for your own application |

---

## PHP — the php-frm module

```text
apt install php-frm
```

PHP works immediately: LisunOS carries **its own engine** (341 functions),
so no external `php-cgi.exe` is required. A PHP build for Windows is still
**downloaded automatically** as soon as the internet is up, and attaches
itself without a restart.

```text
php-frm status                summary: source, auto download, progress
php-frm download              download the build right now
php-frm update                download it again
php-frm remove                delete the downloaded PHP, fall back to the engine
php-frm mirrors               list of download mirrors
php-frm auto off              turn automatic download off
php-frm use builtin           run on the built-in engine only
php-frm use own               use the downloaded PHP
php-frm use system            use the PHP installed in Windows
```

Your own path to PHP:

```text
apt install php-frm C:\php\php-cgi.exe
apt install php-frm C:\Downloads\php-8.3.zip
```

Your own mirrors go into the registry:

```text
regedit -set:php_download_url -val:https://example.com/php.zip
```

---

## Wi-Fi

```text
wifi                          networks around
wifi form                     window with a network list and a password box
wifi connect "Network name"   open network — no password
wifi connect "Name" password  protected network
wifi status                   adapter, current network, internet state
wifi disconnect               disconnect
wifi forget "Name"            remove the saved profile
wifi portal                   open the sign-in page
```

What happens on connect:

* **open network** — connects straight away, no password needed;
* **protected network** — a WPA3/WPA2/WPA profile is built, and the password
  is left nowhere on disk;
* **network with sign-in** — after connecting the system notices that the
  internet is replaced by a captive page and opens it in the LisunOS browser.

The `network` right is required; the application asks for it itself.

---

## System port 8989

A live feed of the PHP setup: you watch the system find a network,
download the build and attach it.

```text
system start                  open the port
system open                   open the page in a browser
system status                 port state
system stop                   close the port
```

Address: `http://localhost:8989/php-frm.html?action=setup`

The port is a system one and listens on localhost only. It opens only when
the hall application has been granted the **`hall`** right:

```text
perm grant LisunOS.lshall hall
```

Revoke that right and the port closes itself on the next request.

---

## Web server and panel

```text
webserverv2                   open the server panel
httpd                         the same thing
```

The panel holds the port, the site root, autostart, a "Manage files" button
for the `www` folder, the secret API key and the web-panel password.

Files in `www`:

| File | Purpose |
|------|---------|
| `.htaccess` | nginx-style configuration: `location`, `index`, `error_page`, PHP, a proxy to Node.js |
| `api.php` | handles `?key=<key>&action=<action>` requests and provides `ServerAPI()` |
| `panel.php` | the web control panel, password protected |

API actions: `list_files`, `read_file`, `create_file`, `edit_file`,
`delete_file`, `move_file`, `create_folder`, `delete_folder`, `status`.

From PHP:

```php
<?php
require_once __DIR__ . '/api.php';

echo ServerAPI('your-key', 'create_file', 'notes.txt', 'Hello!');
```

Lines between `~~~NOREMOVE~` and `~NOREMOVE~~~` cannot be changed, and the
file itself cannot be deleted. Text between `~~~CANTEDIT~` and `~CANTEDIT~~~`
cannot be changed, but the file can be deleted.

---

## The ufw firewall

```text
ufw enable                    turn it on
ufw disable                   turn it off
ufw port 8080 enable          open a port
ufw port 8080 disable         close a port
ufw status                    list the rules
```

---

## Services with systemctl

```text
systemctl list                every service
systemctl start <name>        start
systemctl stop <name>         stop
systemctl status <name>       state
systemctl enable <name>       start with the system
systemctl disable <name>      remove from autostart
```

---

## Permissions

```text
perm all                      every right with its description
perm list                     who was granted what
perm app <name>               rights of one application
perm grant <name> <right>     grant
perm revoke <name> <right>    revoke
perm reset <name>             reset every right of an application
```

| Right | What it opens |
|-------|---------------|
| `superuser` | everything at once |
| `read_files` | reading files |
| `write_files` | creating files |
| `edit_files` | editing files |
| `manage_files` | moving and deleting |
| `edit_settings` | the registry and settings |
| `network` | network, sockets, server |
| `run_services` | starting other services |
| `show_dialogs` | message windows |
| `autostart` | starting with the system |
| `hall` | system ports and shell services |

A denied right is asked for again on the next attempt. Granted ones live in
`files/os/root/regedit/PERMISSIONS`.

---

## Troubleshooting

| Symptom | What to do |
|---------|------------|
| `503 — PHP not found` | `php-frm status`; if needed, `php-frm use builtin` |
| PHP will not download | `php-frm mirrors`, check `wifi status`, then `php-frm download` |
| Port 8989 will not open | `perm grant LisunOS.lshall hall`, then `system start` |
| A network will not connect | `wifi status` — if it says sign-in is required, run `wifi portal` |
| A package will not install | `apt info <name>`; check that the link points at a `.lnsh` |
| Rights get in the way | `perm app <name>` and `perm grant <name> <right>` |

The system log lives on the Terminal tab; `clear` wipes the screen.
