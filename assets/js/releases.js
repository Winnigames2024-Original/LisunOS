/* ============================================================
   Список релизов.

   Данные лежат в releases.json рядом со страницей — тот же файл
   читает и человек, и любой внешний инструмент. Страница ничего
   не запрашивает у GitHub, поэтому открывается и без доступа
   к его API, и из локальной копии репозитория.
   ============================================================ */
"use strict";

(function () {
  var box = document.getElementById("releases");
  if (!box) return;

  var state = document.getElementById("state");

  // Страница живёт по двум адресам — /releases/ и /releases.html, — а файл
  // с данными лежит в корне сайта. Поэтому путь к нему задаёт сама разметка,
  // и один и тот же скрипт работает с обеих глубин.
  var source = box.getAttribute("data-source") || "releases.json";


  function size(bytes) {
    if (!bytes && bytes !== 0) return "";
    if (bytes < 1024) return bytes + " B";
    if (bytes < 1048576) return (bytes / 1024).toFixed(0) + " KB";
    return (bytes / 1048576).toFixed(1) + " MB";
  }

  function date(value) {
    // Дата приходит как 2026-10-24; показываем её привычно: 24.10.2026.
    var parts = String(value || "").split("-");
    if (parts.length !== 3) return value || "";
    return parts[2] + "." + parts[1] + "." + parts[0];
  }

  function text(value) {
    var node = document.createElement("span");
    node.textContent = value == null ? "" : String(value);
    return node.innerHTML;
  }

  function pair(item, field) {
    // Каждое поле хранится двумя языками: field_ru и field_en.
    var ru = item[field + "_ru"];
    var en = item[field + "_en"];
    if (ru == null && en == null) return "";

    return '<span data-ru>' + text(ru) + '</span>' +
           '<span data-en>' + text(en == null ? ru : en) + '</span>';
  }

  function list(item, field) {
    var ru = item[field + "_ru"] || [];
    var en = item[field + "_en"] || ru;
    if (!ru.length && !en.length) return "";

    function one(rows) {
      var out = "";
      for (var i = 0; i < rows.length; i++) out += "<li>" + text(rows[i]) + "</li>";
      return out;
    }

    return '<ul data-ru>' + one(ru) + '</ul><ul data-en>' + one(en) + '</ul>';
  }

  function assets(item) {
    var rows = item.assets || [];
    if (!rows.length) return "";

    var out = '<div class="assets">';
    for (var i = 0; i < rows.length; i++) {
      var a = rows[i];
      var exe = /\.exe$/i.test(a.name || "") ? " exe" : "";

      out += '<a class="asset' + exe + '" href="' + text(a.url) + '" download>' +
             "↓ " + text(a.name) +
             '<span class="size">' + size(a.size) + "</span></a>";
    }
    return out + "</div>";
  }

  function render(data) {
    var rows = (data && data.releases) || [];
    if (!rows.length) {
      state.innerHTML = '<span data-ru>Релизов пока нет.</span>' +
                        '<span data-en>No releases yet.</span>';
      return;
    }

    var html = "";
    for (var i = 0; i < rows.length; i++) {
      var r = rows[i];
      var now = r.tag === data.latest;

      html += '<article class="release' + (now ? " latest" : "") + '">' +
                '<div class="release-head">' +
                  "<h3>" + text(r.name || r.tag) + "</h3>" +
                  '<span class="tag' + (now ? " now" : "") + '">' + text(r.tag) + "</span>" +
                  '<span class="release-date">' + date(r.date) + "</span>" +
                "</div>" +
                '<p class="release-summary">' + pair(r, "summary") + "</p>" +
                list(r, "highlights") +
                assets(r) +
                '<p class="release-links">' +
                  '<a href="' + text(r.page) + '">' +
                    '<span data-ru>Заметки о выпуске на GitHub →</span>' +
                    '<span data-en>Release notes on GitHub →</span>' +
                  "</a></p>" +
              "</article>";
    }

    box.innerHTML = html;
    state.textContent = "";
  }

  function fail(reason) {
    state.className = "state bad";
    state.innerHTML =
      '<span data-ru>Не удалось прочитать ' + text(source) + ": " + text(reason) +
      '. Список релизов есть и на <a href="https://github.com/Winnigames2024-Original/LisunOS/releases">GitHub</a>.</span>' +
      '<span data-en>Could not read ' + text(source) + ": " + text(reason) +
      '. The releases are also on <a href="https://github.com/Winnigames2024-Original/LisunOS/releases">GitHub</a>.</span>';
  }

  // Страницу открывают и как файл с диска — тогда fetch по file:// запрещён,
  // и честнее сказать об этом, чем показать пустой экран.
  fetch(source, { cache: "no-cache" })
    .then(function (response) {
      if (!response.ok) throw new Error("HTTP " + response.status);
      return response.json();
    })
    .then(render)
    .catch(function (error) { fail(error.message || error); });
})();
