/* ============================================================
   Таблица готовых пакетов.

   Источник — apps/catalog.json, тот же файл, который читает сама
   система по команде «store refresh». Поэтому список на сайте и
   список в LisunOS не могут разойтись: он один.
   ============================================================ */
"use strict";

(function () {
  var body = document.getElementById("packages");
  if (!body) return;

  var RAW = "https://github.com/Winnigames2024-Original/LisunOS/raw/main/apps/";

  function text(value) {
    var node = document.createElement("span");
    node.textContent = value == null ? "" : String(value);
    return node.innerHTML;
  }

  function row(item) {
    var file = String(item.url || "").split("/").pop();

    return "<tr>" +
             '<td><a href="' + text(RAW + file) + '" download>' + text(file) + "</a></td>" +
             "<td><code>" + text(item.command || "—") + "</code></td>" +
             '<td><span data-ru>' + text(item.description_ru || item.title_ru) + "</span>" +
                 '<span data-en>' + text(item.description_en || item.title_en) + "</span></td>" +
             '<td><span class="size">' + text(item.version || "") + "</span></td>" +
           "</tr>";
  }

  fetch("apps/catalog.json", { cache: "no-cache" })
    .then(function (response) {
      if (!response.ok) throw new Error("HTTP " + response.status);
      return response.json();
    })
    .then(function (data) {
      var rows = (data && data.packages) || [];
      if (!rows.length) throw new Error("каталог пуст");

      var html = "";
      for (var i = 0; i < rows.length; i++) html += row(rows[i]);
      body.innerHTML = html;
    })
    .catch(function (error) {
      body.innerHTML = '<tr><td colspan="4" class="state bad">' +
        '<span data-ru>Каталог недоступен: ' + text(error.message || error) +
        '. Пакеты лежат в папке <a href="https://github.com/Winnigames2024-Original/LisunOS/tree/main/apps">apps</a>.</span>' +
        '<span data-en>The catalog is unavailable: ' + text(error.message || error) +
        '. The packages live in the <a href="https://github.com/Winnigames2024-Original/LisunOS/tree/main/apps">apps</a> folder.</span>' +
        "</td></tr>";
    });
})();
