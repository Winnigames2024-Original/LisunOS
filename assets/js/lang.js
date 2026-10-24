/* ============================================================
   Переключатель языка.

   Разметка держит оба языка сразу: элементы с data-ru и data-en.
   Скрипт лишь ставит классу body признак "en" — всё остальное
   делает CSS. Поэтому страница читается и до загрузки скрипта.
   ============================================================ */
"use strict";

window.LisunLang = (function () {
  var KEY = "lisunos-lang";
  var current = "ru";
  var listeners = [];

  function apply(lang) {
    current = lang === "en" ? "en" : "ru";

    document.body.classList.toggle("en", current === "en");
    document.documentElement.lang = current;

    var ru = document.getElementById("ru");
    var en = document.getElementById("en");
    if (ru) ru.classList.toggle("on", current === "ru");
    if (en) en.classList.toggle("on", current === "en");

    try { localStorage.setItem(KEY, current); } catch (e) {}

    for (var i = 0; i < listeners.length; i++) {
      try { listeners[i](current); } catch (e) {}
    }
  }

  function init() {
    var ru = document.getElementById("ru");
    var en = document.getElementById("en");

    if (ru) ru.addEventListener("click", function () { apply("ru"); });
    if (en) en.addEventListener("click", function () { apply("en"); });

    var saved = null;
    try { saved = localStorage.getItem(KEY); } catch (e) {}

    // Проект русскоязычный, поэтому по умолчанию RU; выбор посетителя запоминается.
    apply(saved || "ru");
  }

  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", init);
  } else {
    init();
  }

  return {
    get: function () { return current; },
    set: apply,
    onChange: function (fn) { listeners.push(fn); }
  };
})();
