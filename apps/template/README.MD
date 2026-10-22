# 📦 Спецификация Создания Пакетов (.lnsh) и Шаблон приложения

Пакет установщика **`.lnsh`** является стандартным **ZIP-архивом**, содержащим строго определенный набор конфигурационных файлов. 

## Минимальная структура архива:
```text
[Корень архива]
├── meta.json         <- Манифест с метаданными приложения
├── main.lsi          <- Сценарий пошагового развёртывания пакета
├── template.service  <- Конфигурация интеграции службы в ядро
└── assets/           <- Папка графических компонентов
    ├── Form1.cs      <- Логическая часть окна приложения
    └── Form1.designer.cs <- Разметка интерфейса (размеры, цвета)
```

---

## 📄 Исходный Код Файлов Шаблона (`Template`)

Скопируйте код из блоков ниже в соответствующие файлы для сборки собственного пакета `template.lnsh`.

### 1. Манифест пакета: `meta.json`
```json
{
  "name": "TemplateApp",
  "type": "service",
  "version": "1.0.0"
}
```

### 2. Сценарий установки: `main.lsi`
```ini
# Пошаговая сборка пакета
# Дополнительная функция скачивания файлов (удалите символ # для активации):
# download_file https://site.com>background.png

register_service template.service
request_restart
```

### 3. Конфигурация службы: `template.service`
```ini
# Регистрация графического пространства имен в FormEngine
import winforms
winforms.Application templateApp = new winforms.Application()
winforms.Form Form1 = new winforms.Form("%appfiles%\Form1.cs", "%appfiles%\Form1.designer.cs")
templateApp.program.addForm(Form1)
templateApp.namespace = "template"
templateApp.show()
```

### 4. Логика формы: `assets\Form1.cs`
```csharp
using System;
using System.Windows.Forms;

namespace LisunOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello from LisunOS Template App!", "LisunOS API");
        }
    }
}
```

### 5. Конструктор интерфейса: `assets\Form1.designer.cs`
```csharp
namespace LisunOS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnClickMe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClickMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnClickMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClickMe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClickMe.ForeColor = System.Drawing.Color.White;
            this.btnClickMe.Location = new System.Drawing.Point(120, 100);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(160, 45);
            this.btnClickMe.TabIndex = 0;
            this.btnClickMe.Text = "CLICK ME";
            this.btnClickMe.UseVisualStyleBackColor = false;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // Form1
            // 
            this.this.Text = "LisunOS App Template";
            this.this.ClientSize = new System.Drawing.Size(400, 260);
            this.this.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.Controls.Add(this.btnClickMe);
            this.ResumeLayout(false);
        }
    }
}
```

---

## 🛠️ Как Собрать Пакет `template.lnsh`

1. Создайте обычную пустую папку на рабочем столе.
2. Положите в корень файлы `meta.json`, `main.lsi` и `template.service`.
3. Создайте подпапку `assets` и перенесите в неё файлы `Form1.cs` и `Form1.designer.cs`.
4. Выделите все объекты внутри папки (3 файла и папку `assets`), нажмите правой кнопкой мыши -> **Отправить -> Сжатая ZIP-папка**.
5. Замените расширение получившегося архива с `.zip` на **`.lnsh`**.


# 📦 (.lnsh) Package Specification & Application Template

An installer bundle with the **`.lnsh`** extension is standard **ZIP compressed data** containing a strictly predefined scheme of engine configuration elements.

## Minimal Archive Blueprint:
```text
[Archive Root]
├── meta.json         <- Manifest file specifying package metadata
├── main.lsi          <- Linear deployment procedure script
├── template.service  <- Pipeline linking the environment configuration to the engine
└── assets/           <- Graphical layout components folder
    ├── Form1.cs      <- Code-behind window logic file
    └── Form1.designer.cs <- Form UI configuration properties (dimensions, colors)
```

---

## 📄 Template Source Code (`Template`)

Copy the codebase sections below into matching discrete files to bundle your custom `template.lnsh` file.

### 1. Application Manifest: `meta.json`
```json
{
  "name": "TemplateApp",
  "type": "service",
  "version": "1.0.0"
}
```

### 2. Deployment Script: `main.lsi`
```ini
# Linear configuration setup sequence
# Remote resource pre-loading utility (remove the # symbol to engage):
# download_file https://site.com>background.png

register_service template.service
request_restart
```

### 3. Service Entry Configuration: `template.service`
```ini
# Instantiating graphical form mapping context via FormEngine
import winforms
winforms.Application templateApp = new winforms.Application()
winforms.Form Form1 = new winforms.Form("%appfiles%\Form1.cs", "%appfiles%\Form1.designer.cs")
templateApp.program.addForm(Form1)
templateApp.namespace = "template"
templateApp.show()
```

### 4. Code-Behind Window Logic: `assets\Form1.cs`
```csharp
using System;
using System.Windows.Forms;

namespace LisunOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello from LisunOS Template App!", "LisunOS API");
        }
    }
}
```

### 5. Layout Sizing Properties: `assets\Form1.designer.cs`
```csharp
namespace LisunOS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnClickMe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClickMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnClickMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClickMe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClickMe.ForeColor = System.Drawing.Color.White;
            this.btnClickMe.Location = new System.Drawing.Point(120, 100);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(160, 45);
            this.btnClickMe.TabIndex = 0;
            this.btnClickMe.Text = "CLICK ME";
            this.btnClickMe.UseVisualStyleBackColor = false;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // Form1
            // 
            this.this.Text = "LisunOS App Template";
            this.this.ClientSize = new System.Drawing.Size(400, 260);
            this.this.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.Controls.Add(this.btnClickMe);
            this.ResumeLayout(false);
        }
    }
}
```

---

## 🛠️ Compiling your `template.lnsh` file

1. Initialize a new empty working directory block on your desktop.
2. Store the `meta.json`, `main.lsi`, and `template.service` elements in its root branch.
3. Build a subfolder named `assets` and transfer `Form1.cs` along with `Form1.designer.cs` into it.
4. Select all internal items collectively (3 base files and the `assets` folder asset).
5. Compress the selection into a **standard ZIP archive structural node**.
6. Alter the container format flag on your file system, changing `.zip` directly to **`.lnsh`**.
