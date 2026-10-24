# Installing LisunOS utilities

This document explains how to install and set up the built-in utilities of
LisunOS 1.8.6 "Onyx". Every command is typed into the system terminal —
the `LisunOS:\>` prompt on the Terminal tab.

---

## Contents

1. [First run](#first-run)
2. [The apt package manager](#the-apt-package-manager)
3. [The first-run wizard](#the-first-run-wizard)
4. [Every application at once](#every-application-at-once)
5. [Your own package, and a password on it](#your-own-package-and-a-password-on-it)
6. [Versions and their words](#versions-and-their-words)
7. [Applications: Explorer and Server](#applications-explorer-and-server)
8. [PHP — the php-frm module](#php--the-php-frm-module)
9. [Wi-Fi](#wi-fi)
10. [Downloads](#downloads)
11. [System components](#system-components)
12. [Updating the system](#updating-the-system)
13. [System port 8989](#system-port-8989)
14. [Web server and panel](#web-server-and-panel)
15. [The ufw firewall](#the-ufw-firewall)
16. [Services with systemctl](#services-with-systemctl)
17. [Permissions](#permissions)
18. [SuperUser — granting full access](#superuser--granting-full-access)
19. [Signing in from a phone or another PC](#signing-in-from-a-phone-or-another-pc)
20. [The kernel journal](#the-kernel-journal)
21. [Troubleshooting](#troubleshooting)

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

## The first-run wizard

On the first start a wizard opens instead of the terminal, the way a phone
asks its questions. Four steps, and the one you are on is marked on the left:

```text
1. Language      Russian or English
2. Network       the networks around, the password, connecting
3. Applications  the list from the site, with tick boxes
4. Install       a progress bar and a log
5. Done          on to the terminal
```

Any step can be skipped: the network is set up later with `wifi`, the
applications with `store` and `apt`. The application list comes from the
same `catalog.json` the `store` command reads, so the wizard shows exactly
what the system shows.

```text
setup                         open the wizard again
setup reset                   show it on the next start
setup status                  whether it has been run
```

The wizard is a window, so it does not open over `ssh`.

---

## Every application at once

```text
store install apps.all        install everything from the catalog
```

The system re-reads the catalog from the site and installs the packages one
by one. The ones already installed are skipped, a failure does not stop the
rest, and at the end you see the tally: installed, skipped, failed.

`apt install <name>` still installs one package — `apps.all` only saves you
from listing them all.

---

## Your own package, and a password on it

A `.lnsh` package is built from a folder with one command:

```text
pack myapp                    builds myapp.lnsh next to it
pack myapp myapp.lnsh         with a file name of your own
pack myapp myapp.lnsh secret  the package is locked with a password
pack myapp myapp.lnsh secret the first word of the song
                              the last argument is the hint
```

The folder must contain `meta.json`, otherwise it is not a package.

**What "locked" means.** An ordinary `.lnsh` is a ZIP: whoever downloads the
file reads the application. A locked package is built differently:

```text
myapp.lnsh
├── lock.json      what it is locked with: salt, IV, rounds, hint
└── payload.enc    the same package, encrypted
```

The key comes from the password (PBKDF2-SHA256, 120 000 rounds), the data is
encrypted with AES-256-CBC and an HMAC-SHA256 is computed over it. The
password is stored nowhere — not in the package, not in the system; it
cannot be recovered from the file, and the contents cannot be swapped
without it, because the checksum would not match.

Installing such a package opens a window with the hint and asks for the
password — three attempts. Over `ssh` a locked package is not installed:
there is nobody to show the window to.

---

## Versions and their words

Every version has a word of its own, alphabetical in release order:

```text
ver                           the version, its word and the kernel
ver list                      every version and its word
```

```text
1.1.0 "Aurora"   1.5.1 "Fjord"    1.8.0 "Icefall"
1.2.0 "Borealis" 1.6.0 "Glacier"  1.8.1 "Jasper"
1.3.0 "Cirrus"   1.7.0 "Horizon"  1.8.2 "Kelvin"
1.4.0 "Drift"    1.5.0 "Ember"
```

The number grows in its last part: 1.8.1 is followed by **1.8.2**, not
1.9.0. The table of words lives both in the system and on the site in
`codenames.json`, and a release takes its name from there by itself.

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

### The Wi-Fi application

```text
apt install wifiapp           install the application
wifi-app                      open the window
wifi form                     the same thing
```

The window shows **every network around in one list**: the name, the signal as
bars (`████`, `██░░`), the security and a mark — "connected" or "saved". Cyan
marks the networks whose password is already saved: those connect without
typing anything.

* a double click on a row connects;
* the password box is on the right, with "Show the password" next to it;
* the list refreshes itself every 15 seconds, and the tick can be cleared;
* "Sign-in page" opens the network portal when one is needed;
* at the bottom are the system downloads and a "Download what is missing"
  button: once the internet is there, you can see what the system is pulling
  and fetch the rest right away.

Scanning runs in a thread of its own — the window does not freeze while Windows
polls the adapter.


---

## Downloads

Everything the system fetches from the network goes through one place:
progress, speed, time left, mirrors and a checksum — the same for the PHP
build, for a package and for a file behind a link.

```text
download <url>                download into the current folder
download <url> name.zip       download under a name of your own
download list                 what is downloading right now
download history              recent downloads: when, how much, from where
download cancel               cancel everything in flight
download clear                clear the history
```

What the downloader does by itself:

* **mirrors** — with several links it tries them until one works;
* **resume** — a broken file continues at the same byte instead of starting
  over (the `Range` header); if the file changed on the server, it starts from
  the beginning;
* **sha256** — when the catalog knows the checksum it is verified, and a
  damaged file is not installed;
* **history** — `/os/root/downloads`, the last 60 downloads, kept across
  restarts.

The `network` and `write_files` rights are required.

---

## System components

`lib` shows what LisunOS can fetch and what is already inside it.

```text
lib                           the component list
lib check                     what is missing
lib info php                  details about one
lib install php               fetch and attach it
lib remove docs               take it off the disk
lib update                    re-read the catalog from the site
lib auto on|off               fetch silently when needed
lib path php                  where it lives
```

| Component | What it is | Downloaded |
|---|---|---|
| `php` | the PHP build for Windows, needed by the web server | from php.net |
| `docs` | this documentation in both languages | from the release archive |
| `apps` | the package catalog behind `apt install` | from the project site |
| `system` | `LisunOS.exe` itself | see "Updating the system" |
| `ssh` | the SSH-2 remote login | **built into the kernel** |
| `wifi` | scanning and connecting | **built in** |
| `php-engine` | the own PHP lexer and interpreter | **built in** |

The last three rows are the honest answer to "what else do I download to make
it work?": nothing. The SSH-2 protocol is written inside LisunOS, Wi-Fi goes
through Windows, and PHP runs on the own engine. The build from php.net is
only for those who need a real `php-cgi`.

When the internet appears the system writes into the terminal what it is
missing, but pulls nothing silently. To let it, use `lib auto on`.

---

## Updating the system

```text
update                        what is installed and what is on the site
update check                  look at releases.json on the site
update download               download the new LisunOS.exe
update install                replace the current exe and restart
```

`update install` asks for confirmation in a window, like installing a program
in Windows. Windows does not let a running file be replaced, so the system
writes a short script next to it: it waits for LisunOS to close, moves the old
exe to `LisunOS.exe.old`, puts the new one in place and starts it. **The old
file stays next to it** — if you do not like the new version, you can put the
old one back by hand.

Over the network (`ssh`) the exe is never swapped: there is nobody to show the
confirmation window to, and changing a file on someone's computer unasked is
not done.

---

## Wired connections

A cable is as much a connection as Wi-Fi, and the system now treats it that way:

```text
net                           every adapter: kind, address, gateway, speed
wifi status                   the same picture through Wi-Fi eyes, with a "Cable" line
```

The list shows each adapter and what it is: **wired**, **Wi-Fi** or
**virtual**. That last one matters: Windows calls Radmin VPN, Hamachi and
the Hyper-V, VMware and TAP switches "ethernet" too. Left unfiltered, the
system would decide it reached the network through a VPN address that does
not exist in your network. So only a real adapter counts as wired, and when
there are several, the one with a gateway and the higher speed wins.

The first-run wizard and the Wi-Fi application know this: with a cable
plugged in they say the network is already there instead of asking you to
find an access point.

---

## SuperUser and the su keys

The **SuperUser** application is the only way to give a package full
access. It lives both on the site and inside the system itself:

```text
superuser install             install from the built-in catalog, no network needed
apt install superuser         take the fresh build from the site
superuser                     open the granting window
```

Package names are matched the human way: `superuser`, `SuperUserApp` and
`super-user` are the same application.

SuperUser holds two keys nobody else has:

| Key | What it opens |
|---|---|
| `enable_superuser` | the application may grant another package the `superuser` right |
| `enable_su` | the `su` command in the terminal starts working |

While no application in the system holds `enable_su`, `su` refuses, as
before. Once one does, `su` asks for confirmation in a window and turns on
superuser mode; over the network `su` is not enabled, because there is
nobody to show the confirmation to.

---

## Rights and restarts at install time

**A package from the official site or from the wizard.** The permissions
are granted at once, with no second question: the application has already
been picked in the catalog, and asking again in the same words is pointless.
This covers packages downloaded from the project site, the built-in catalog
and the first-run wizard.

**Someone else's link or a file from disk.** The request window stays: the
system does not know where the package came from, and asks for every right.

**No restart any more.** After an install the service runs immediately, the
command is registered and the window opens. A restart is only left for a
hall shell, which replaces the system window itself.

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

A **regular `ssh` client** connects — from a computer, from a phone, from
anywhere. The key exchange and the encryption are real, and the password
does not travel in the clear. No libraries to install: the protocol is
built inside LisunOS out of what .NET already provides.

```text
ssh www@192.168.0.5 -p 2222
```

The plain text mode stayed on the same port for when no `ssh` client is at
hand: **PuTTY** with connection type **Raw** or **Telnet**, or
`nc <address> 2222`. The server tells them apart by the first bytes: an
`ssh` client greets with `SSH-2.0-…`, telnet stays quiet and waits for a
prompt.

On the first connection `ssh` shows the machine's key fingerprint and asks
for confirmation — that is normal. The `ssh status` command prints the same
fingerprint so you can compare. The key is created once and lives in
`files/os/root/regedit/.ssh_host_key`.

Create a user first — the server will not start without one:

```text
user create www 1234        create (the password is kept as a PBKDF2 hash)
user edit www 4321          change the password
user disable www            close the account for now
user remove www             delete
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

### Autostart

```text
ssh autostart on              start the remote login with the system
ssh autostart on 2222         the same, with the port set
ssh autostart off             off
ssh autostart                 what is set now
```

The port is remembered by a plain `ssh start` too, so autostart brings the
server up on the same one. Turning autostart on while the server is off
starts it right away — there is nothing to wait for.

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

### Who you are in the system

The prompt shows the name: `LisunOS root:\>`. By default that is **root** —
the system itself; it can be neither limited nor removed.

```text
user current                  who is active
user current set www          switch (root only)
whoami                        the same thing
```

The system creates two accounts by itself:

| Name | What for |
|------|----------|
| `root` | the system itself: never limited, never removed |
| `www` | **the site**: the web server and `api.php` run as this user |

A password is optional: `user create name` with no password makes an
account that works locally but cannot sign in over the network.

Over the network the name comes from the sign-in: commands run as whoever
logged in.

### Limits

Any account except root can have areas closed off. The check happens before
the command runs, so a forbidden command never changes anything.

```text
user areas                                          the list of tokens
user limit www                                      what is closed for www
user limit www add PERMISSION_CREATE_FILES          close it
user limit www remove PERMISSION_CREATE_FILES       open it again
user limit www clear                                remove every limit
```

| Token | What it closes |
|-------|----------------|
| `PERMISSION_READ_FILES` | reading files |
| `PERMISSION_CREATE_FILES` | creating files and folders |
| `PERMISSION_EDIT_FILES` | editing and renaming |
| `PERMISSION_DELETE_FILES` | deleting |
| `PERMISSION_PACKAGES` | `apt` and `store` |
| `PERMISSION_NETWORK` | `curl`, `wifi`, the server, `ssh`, `ufw`, `php-frm` |
| `PERMISSION_USERS` | managing accounts |
| `PERMISSION_APPS` | launching applications |
| `PERMISSION_SYSTEM` | registry, services, restart, language, rights |
| `PERMISSION_SUPERUSER` | elevating privileges |

The second set of tokens is about applications. `ALLOW_PERMISSION_*_REQUEST`
closes not the action itself but an application's right to **ask** for a
capability: the request window never appears, and consent changes nothing.

```text
user limit www add ALLOW_PERMISSION_CREATE_FILES_REQUEST
```

Only root can set and remove limits.

### Confirming with a password

A limit is not a dead end. When a closed action is genuinely needed, the
system shows a window, like User Account Control in Windows: what is being
asked, on whose behalf, and a field for the administrator password. The
right password allows the action for five minutes, then the window asks
again.

The password is set once on the first run — the system offers it itself.
You can skip it: then the window simply asks for confirmation, with no
password. To set or change it later:

```text
user password                 the input window
user password mypassword      straight from the line
```

Windows cannot be shown over the network, so in an `ssh` session a closed
action stays refused.

### The site is www

The web server and `api.php` run as `www`. That account's limits are
checked at the entrance to `api.php`: if deleting is closed for `www`, a
call to `action=delete_file` returns 403 with its own explanation in JSON
and never reaches PHP.

```text
user limit www add PERMISSION_DELETE_FILES     the site deletes nothing
user limit www add PERMISSION_EDIT_FILES       and changes nothing
```

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
| `ssh` complains the key changed | the key was recreated; drop the old entry from `known_hosts` |
| A command answers "closed" | that is a limit: `user limit <name>` shows which one |
| The confirmation window rejects the password | it wants the **administrator** (root) password, not the user's: `user password` sets it |
| The site answers 403 on api.php | an area is closed for `www`: `user limit www` shows which |
| A package from disk will not install over the network | that is blocked: install by name (`apt install sshapp`) or by link |
| A command over ssh "did nothing" | it opened a window — look at the computer screen |

The system log lives on the Terminal tab; `clear` wipes the screen.
