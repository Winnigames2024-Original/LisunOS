/* ============================================================
   Читалка markdown: /mdreader/?url=<адрес .md>

   Адрес может быть относительным — тогда он отсчитывается от корня
   сайта, — или полным. Разбор делает LisunMarkdown: он экранирует
   текст и собирает разметку сам, поэтому чужой файл не может
   принести на страницу свой скрипт.
   ============================================================ */
"use strict";

(function () {
  var doc = document.getElementById("doc");
  var state = document.getElementById("state");
  var picker = document.getElementById("picker");
  var source = document.getElementById("source");
  if (!doc) return;

  // Корень сайта: /LisunOS/mdreader/ -> /LisunOS/
  var root = new URL("../", location.href).href;

  function say(html, bad) {
    state.className = bad ? "state bad" : "state";
    state.innerHTML = html;
  }

  function escape(value) {
    return window.LisunMarkdown.escape(value);
  }

  function parameter(name) {
    var query = location.search.replace(/^\?/, "");
    var parts = query.split("&");

    for (var i = 0; i < parts.length; i++) {
      var pair = parts[i].split("=");
      if (decodeURIComponent(pair[0]) !== name) continue;

      // Адрес мог прийти и закодированным, и как есть.
      try { return decodeURIComponent(pair.slice(1).join("=")); }
      catch (e) { return pair.slice(1).join("="); }
    }

    return null;
  }

  var asked = parameter("url");

  if (!asked) {
    picker.hidden = false;
    say("");
    return;
  }

  var target;
  try { target = new URL(asked, root).href; }
  catch (e) { target = null; }

  if (!target || !/^https?:/i.test(target)) {
    picker.hidden = false;
    say('<span data-ru>Непонятный адрес: ' + escape(asked) + "</span>" +
        '<span data-en>Unclear address: ' + escape(asked) + "</span>", true);
    return;
  }

  document.title = asked.split("/").pop() + " — LisunOS";

  say('<span data-ru>Загружаю ' + escape(asked) + "…</span>" +
      '<span data-en>Loading ' + escape(asked) + "…</span>");

  fetch(target, { cache: "no-cache" })
    .then(function (response) {
      if (!response.ok) throw new Error("HTTP " + response.status);
      return response.text();
    })
    .then(function (text) {
      doc.innerHTML = window.LisunMarkdown.render(text, {
        base: target,
        readerPrefix: "?url="
      });

      say("");

      source.className = "md-source on";
      source.innerHTML =
        '<span data-ru>Источник: </span><span data-en>Source: </span>' +
        '<a href="' + escape(target) + '" rel="noopener">' + escape(target) + "</a>";

      // Содержание в начале документа ссылается на заголовки якорями.
      // Браузер о них ничего не знает — заголовки появились из markdown
      // уже после загрузки страницы, — поэтому ищем их сами.
      function headingFor(anchor) {
        var wanted = String(anchor || "").toLowerCase();
        var heads = doc.querySelectorAll("h1, h2, h3, h4, h5, h6");

        for (var i = 0; i < heads.length; i++) {
          var slug = heads[i].textContent.trim().toLowerCase()
            .replace(/[^\wа-яё\s-]/gi, "")
            .replace(/\s+/g, "-");

          if (slug === wanted) return heads[i];
        }

        return null;
      }

      doc.addEventListener("click", function (event) {
        var link = event.target.closest ? event.target.closest('a[href^="#"]') : null;
        if (!link) return;

        var head = headingFor(decodeURIComponent(link.getAttribute("href").slice(1)));
        if (!head) return;

        event.preventDefault();
        head.scrollIntoView({ behavior: "smooth", block: "start" });
      });

      if (location.hash.length > 1) {
        var landing = headingFor(decodeURIComponent(location.hash.slice(1)));
        if (landing) landing.scrollIntoView();
      }
    })
    .catch(function (error) {
      picker.hidden = false;

      var reason = escape(error.message || error);
      say('<span data-ru>Не удалось прочитать ' + escape(asked) + ": " + reason +
          '. Если файл лежит на чужом сайте, тот должен разрешать запросы из браузера (CORS). ' +
          'Можно открыть его <a href="' + escape(target) + '" rel="noopener">как есть</a>.</span>' +
          '<span data-en>Could not read ' + escape(asked) + ": " + reason +
          ". If the file is on another site, that site has to allow browser requests (CORS). " +
          'You can open it <a href="' + escape(target) + '" rel="noopener">as is</a>.</span>', true);
    });
})();
