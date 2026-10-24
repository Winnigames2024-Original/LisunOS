/* ============================================================
   Карточки пакетов на странице /apps/.

   Источник тот же catalog.json, что читает сама система, поэтому
   список на сайте и список в LisunOS не могут разойтись.
   ============================================================ */
"use strict";

(function () {
  var box = document.getElementById("cards");
  if (!box) return;

  var state = document.getElementById("state");
  var RAW = "https://github.com/Winnigames2024-Original/LisunOS/raw/main/apps/";

  function text(value) {
    var node = document.createElement("span");
    node.textContent = value == null ? "" : String(value);
    return node.innerHTML;
  }

  function pair(ru, en) {
    return '<span data-ru>' + text(ru) + "</span>" +
           '<span data-en>' + text(en == null ? ru : en) + "</span>";
  }

  function rights(item) {
    var list = item.permissions || [];
    if (!list.length) return "";

    var out = "";
    for (var i = 0; i < list.length; i++) {
      out += (i ? ", " : "") + text(list[i]);
    }

    return '<p class="note" style="margin-top:10px">' +
           pair("права: ", "rights: ") + out + "</p>";
  }

  function card(item) {
    var file = String(item.url || "").split("/").pop();
    var name = item.name || file;

    return '<div class="card">' +
             "<h3>" + pair(item.title_ru || name, item.title_en || name) +
             ' <span class="tag">' + text(item.version || "") + "</span></h3>" +
             "<p>" + pair(item.description_ru, item.description_en) + "</p>" +
             '<p class="note" style="margin-top:10px">' +
               pair("команда: ", "command: ") + "<code>" + text(item.command || "—") + "</code>" +
             "</p>" +
             rights(item) +
             '<div class="assets" style="margin-top:14px">' +
               '<a class="asset" href="' + text(RAW + file) + '" download>↓ ' + text(file) + "</a>" +
               '<a class="asset" href="#" data-copy="apt install ' + text(name) + '">' +
                 pair("apt install " + name, "apt install " + name) + "</a>" +
             "</div>" +
           "</div>";
  }

  // Щелчок по команде кладёт её в буфер: на странице её всё равно
  // копируют, чтобы вставить в терминал LisunOS.
  function wireCopy() {
    var nodes = box.querySelectorAll("[data-copy]");

    for (var i = 0; i < nodes.length; i++) {
      nodes[i].addEventListener("click", function (event) {
        event.preventDefault();

        var command = this.getAttribute("data-copy");
        var self = this;

        function done() {
          var was = self.innerHTML;
          self.innerHTML = '<span data-ru>скопировано</span><span data-en>copied</span>';
          setTimeout(function () { self.innerHTML = was; }, 1200);
        }

        if (navigator.clipboard && navigator.clipboard.writeText) {
          navigator.clipboard.writeText(command).then(done, function () {});
          return;
        }

        // Буфера может не быть — тогда хотя бы выделим текст.
        var area = document.createElement("textarea");
        area.value = command;
        document.body.appendChild(area);
        area.select();
        try { document.execCommand("copy"); done(); } catch (e) {}
        document.body.removeChild(area);
      });
    }
  }

  fetch("catalog.json", { cache: "no-cache" })
    .then(function (response) {
      if (!response.ok) throw new Error("HTTP " + response.status);
      return response.json();
    })
    .then(function (data) {
      var rows = (data && data.packages) || [];
      if (!rows.length) throw new Error("каталог пуст");

      var html = "";
      for (var i = 0; i < rows.length; i++) html += card(rows[i]);

      box.innerHTML = html;
      state.textContent = "";
      wireCopy();
    })
    .catch(function (error) {
      state.className = "state bad";
      state.innerHTML =
        '<span data-ru>Не удалось прочитать catalog.json: ' + text(error.message || error) +
        '. Пакеты лежат в <a href="https://github.com/Winnigames2024-Original/LisunOS/tree/main/apps">папке apps</a>.</span>' +
        '<span data-en>Could not read catalog.json: ' + text(error.message || error) +
        '. The packages live in the <a href="https://github.com/Winnigames2024-Original/LisunOS/tree/main/apps">apps folder</a>.</span>';
    });
})();
