# Installing LisunOS utilities

This document explains how to install and set up the built-in utilities of
LisunOS 1.5.0 "Aurora". Every command is typed into the system terminal —
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
11. [SuperUser — granting full access](#superuser--granting-full-access)
12. [Signing in from a phone or another PC](#signing-in-from-a-phone-or-another-pc)
13. [The kernel journal](#the-kernel-journal)
14. [Troubleshooting](#troubleshooting)

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
apt install <name>           download by name from the site catalog
types                        package types: app, service, daemon, library,
                             theme, locale, module, hall
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
apt install explorerapp
apt install webserverv2
apt install sshapp
apt install superuserapp
apt install logsapp
```

The name is looked up in the site catalog and the package is downloaded
from there. With no network the built-in copy is installed instead, and the
system says so on a separate line. A direct link still works:

```text
apt install https://github.com/Winnigames2024-Original/LisunOS/raw/main/apps/explorerApp.lnsh
```

During installation the system asks for rights — the application requests
them itself.

| Package | Version | Launch | What it does |
|---------|---------|--------|--------------|
| ExplorerApp | 1.2.0 | `explorer`, `files` | file manager for the virtual file system |
| WebServerV2 | 2.1.0 | `webserverv2`, `httpd`, `server`, `www` | HTTP server control panel |
| SshApp | 1.0.0 | `ssh-app` | signing in to the shell from a phone or another PC |
| SuperUserApp | 1.0.0 | `superuser`, `su-app` | granting packages the superuser right |
| LogsApp | 1.0.0 | `logs` | the kernel journal with search and export |
| CalcApp | 1.0.0 | `calc`, `calculator` | calculator with history |
| SettingsApp | 1.0.0 | `settings`, `options` | system settings |
| StoreApp | 1.0.0 | `store`, `apps-store` | application catalog |
| TemplateApp | 1.1.0 | `template`, `tpl`, `demo` | skeleton for your own application |

### New in the file manager

Forward, home and refresh buttons; the address bar is editable — type a
path and press Enter; a filter field narrows the list by name; several
items can be selected at once. The context menu gained Copy, Cut, Paste,
"Pack into .zip", Unpack and Properties; clicking a column header sorts the
list, and the status bar shows the item count and total size. Shortcuts:
`Ctrl+C/X/V/A`, `Ctrl+L` (address), `Ctrl+F` (filter), `F2`, `F5`,
`Delete`, `Backspace`, `Alt+Left`, `Alt+Right`.

### New in the server

On the right there is now the list of hosts from the configuration: the
root one and every `server { ... }` block, including those pulled in with
`include`. The "Reload config" button applies an `.htaccess` edit without
stopping the server, so open connections are not dropped. The log gained a
filter field and a clear button, and the statistics line shows how many
bytes were sent to clients.

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
| `background` | timed work with no window |
| `listen` | accepting incoming connections |
| `manage_packages` | installing and removing packages |
| `manage_users` | accounts for signing in over the network |
| `appearance` | language, layout and appearance |
| `clipboard` | the Windows clipboard |
| `run_external` | starting external Windows programs |
| `read_log` | reading the kernel journal |

A denied right is asked for again on the next attempt. Granted ones live in
`files/os/root/regedit/PERMISSIONS`.

---

## SuperUser — granting full access

The `su` command no longer turns superuser mode on: it reports an error and
points you at the application. `sudo` works only once the mode is already
on. The reason is simple — the `superuser` right opens a package's way to
files, the registry, the network and other packages, and that is not
something to hand out with one line in a terminal.

```text
apt install superuserapp
superuser                     the rights window
```

On the left there is the list of packages: name, type, whether the right is
already there, and how many rights were granted in total. Pick a package
and the right side shows what the right opens and which rights the package
has now. Tick "I understand the package gets full access" — only then does
the **"Grant superuser"** button become available. The system asks once more
in a separate dialog.

Next to it: **"Revoke"** takes the right away, **"Enable mode"** raises the
current session's privileges on behalf of the selected package, and
**"Disable"** lowers them again. `su` with no arguments still turns the mode
off.

---

## Signing in from a phone or another PC

The sign-in server is `SshHost`. It is **not** SSH-2 — there is no key
exchange here, so a regular `ssh` client cannot connect. These work:

* **PuTTY** — connection type **Raw** or **Telnet**, with the address and
  port printed by the `ssh` command;
* `nc <address> 2222` — on Linux, macOS and in Termux on Android.

Create a user first — the server will not start without one:

```text
user create lilia 1234        create (the password is kept as a PBKDF2 hash)
user edit lilia 4321          change the password
user disable lilia            close the account for now
user remove lilia             delete
user list                     who exists and how many sign-ins there were
```

Then the server:

```text
ssh                           this machine's addresses and the port
ssh start 2222                start it
ssh status                    state and the number of connections
ssh who                       who is online right now
ssh help                      how a network session differs from the terminal
ssh log                       who connected and when
ssh stop                      stop it
```

`ssh` with no arguments prints the full address — that is what you type on
the phone. After connecting, the client asks for a name and a password, and
from there it is the ordinary LisunOS shell: the same commands, the same
output.

### What a network session can do

Commands run through the same core as the terminal, so **every** command is
available, including the ones installed applications added: `explorer`,
`logs`, `superuser`, `store`, `httpd` and your own. There are exactly three
differences.

**Windows open in LisunOS, not in ssh.** A form cannot be shown over a text
channel, so the window appears on the computer itself and ssh receives a
line saying it opened. That is how `explorer`, `wifi form`, `superuser` and
application commands behave.

**A directory of its own.** `cd` in one session moves neither the terminal
nor the other clients: each has its own. The prompt shows where you are —
`LisunOS:\root\www>`.

**Only the LisunOS file system is visible.** Windows drive paths (`C:\...`,
network shares) are closed: `apt install C:\app.lnsh` and pointing at your
own `php-cgi.exe` are refused over the network. You can install by name from
the catalog and by link.

The session also understands:

```text
clear            wipe the screen
!!               repeat the last command
?                a short note about the session
exit             log out
```

The server holds up to eight connections at a time.

The **Network access** application does the same with a window:

```text
apt install sshapp
ssh-app
```

The address with its port and a Copy button, the list of users with
creation and password changes, and a live connection log.

> Port 2222 has to be open: `ufw port 2222 enable`. Network access means
> signing in to the shell with a password — do not turn it on in a network
> you do not trust.

---

## The kernel journal

```text
apt install logsapp
logs
```

The window shows the kernel entries. Search narrows them by text, the
"Source" list is built from the entries themselves (`[store]`, `[ssh]`,
`[apt]`, `[FormEngine]`), the "Errors only" box keeps the lines carrying
`ERROR`, and "Follow" pulls in new entries by itself. "Save to a file" puts
whatever is on screen into `/os/home/logs`.

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
| `su` reports an error | that is by design: open `superuser` and grant the right to a package |
| `ssh start` will not start | run `user create <name> <password>` first, then `ufw port 2222 enable` |
| An `ssh` client will not connect | this is not SSH-2: use PuTTY in **Raw** or **Telnet** mode, or `nc` |
| A package from disk will not install over the network | that is blocked: install by name (`apt install sshapp`) or by link |
| A command over ssh "did nothing" | it opened a window — look at the computer screen |

The system log lives on the Terminal tab; `clear` wipes the screen.
