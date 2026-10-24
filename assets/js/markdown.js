/* ============================================================
   Разбор markdown — свой, без внешних библиотек.

   Почему свой: читалка открывает файлы по чужим адресам, а чужой
   markdown нельзя отдавать в innerHTML как есть. Здесь текст сначала
   экранируется целиком, и только потом из него собирается разметка
   из заданного набора тегов. Поэтому ни <script>, ни обработчик
   onclick из файла в страницу не попадут: их просто некуда вставить.

   Поддержано то, что встречается в документах проекта: заголовки,
   абзацы, списки с вложенностью, таблицы, цитаты, код строкой и
   блоком, ссылки, картинки, горизонтальная черта.
   ============================================================ */
"use strict";

window.LisunMarkdown = (function () {

  function escapeHtml(value) {
    return String(value == null ? "" : value)
      .replace(/&/g, "&amp;")
      .replace(/</g, "&lt;")
      .replace(/>/g, "&gt;")
      .replace(/"/g, "&quot;");
  }

  /**
   * Приводит ссылку к абсолютной и отбрасывает всё, что не является
   * обычным переходом: javascript:, data: и прочее сюда не пройдёт.
   */
  function safeUrl(href, base) {
    var raw = String(href || "").trim();
    if (raw.length === 0) return null;

    if (raw.charAt(0) === "#") return raw;

    var resolved;
    try { resolved = base ? new URL(raw, base) : new URL(raw); }
    catch (e) { return null; }

    var scheme = resolved.protocol.toLowerCase();
    if (scheme !== "http:" && scheme !== "https:" && scheme !== "mailto:") return null;

    return resolved.href;
  }

  /** Ссылка на соседний markdown открывается тут же, в читалке. */
  function linkTarget(url, options) {
    if (!options || !options.readerPrefix) return url;
    if (!/\.(md|markdown)(\?|#|$)/i.test(url)) return url;

    return options.readerPrefix + encodeURIComponent(url);
  }

  // ----------------------------------------------------------
  //  Строчная разметка
  // ----------------------------------------------------------

  function inline(line, options) {
    var codes = [];

    // Код строкой прячем до экранирования, чтобы звёздочки и скобки
    // внутри него остались текстом, а не разметкой.
    var text = String(line).replace(/`([^`]+)`/g, function (all, body) {
      codes.push(body);
      return "\u0000CODE" + (codes.length - 1) + "\u0000";
    });

    text = escapeHtml(text);

    // Картинка
    var URL_PART = /!\[([^\]]*)\]\(((?:[^()\s]|\([^()\s]*\))+)(?:\s+"[^"]*")?\)/g;

    text = text.replace(URL_PART, function (all, alt, src) {
      var url = safeUrl(src, options && options.base);
      if (!url) return escapeHtml(alt);

      return '<img src="' + escapeHtml(url) + '" alt="' + escapeHtml(alt) + '" loading="lazy">';
    });

    // Ссылка
    text = text.replace(/\[([^\]]+)\]\(((?:[^()\s]|\([^()\s]*\))+)(?:\s+"[^"]*")?\)/g, function (all, label, href) {
      var url = safeUrl(href, options && options.base);
      if (!url) return label;

      // Внешние ссылки открываем с rel="noopener": чужая страница
      // не должна получить доступ к открывшему её окну.
      var outside = /^https?:/i.test(url) && url.indexOf(location.origin) !== 0;

      return '<a href="' + escapeHtml(linkTarget(url, options)) + '"' +
             (outside ? ' rel="noopener"' : "") + ">" + label + "</a>";
    });

    // Голый адрес в угловых скобках
    text = text.replace(/&lt;(https?:\/\/[^\s&]+)&gt;/g, function (all, href) {
      var url = safeUrl(href, options && options.base);
      return url ? '<a href="' + escapeHtml(url) + '" rel="noopener">' + escapeHtml(url) + "</a>" : all;
    });

    text = text.replace(/\*\*\*([^*]+)\*\*\*/g, "<strong><em>$1</em></strong>");
    text = text.replace(/\*\*([^*]+)\*\*/g, "<strong>$1</strong>");
    text = text.replace(/(^|[\s(])\*([^*\n]+)\*(?=[\s).,;:!?]|$)/g, "$1<em>$2</em>");
    text = text.replace(/~~([^~]+)~~/g, "<del>$1</del>");

    // Возвращаем код на место уже экранированным.
    text = text.replace(/\u0000CODE(\d+)\u0000/g, function (all, index) {
      return "<code>" + escapeHtml(codes[Number(index)]) + "</code>";
    });

    return text;
  }

  // ----------------------------------------------------------
  //  Блоки
  // ----------------------------------------------------------

  function isTableSeparator(line) {
    return /^\s*\|?\s*:?-{2,}:?\s*(\|\s*:?-{2,}:?\s*)*\|?\s*$/.test(line);
  }

  function splitRow(line) {
    var row = line.trim();
    if (row.charAt(0) === "|") row = row.slice(1);
    if (row.charAt(row.length - 1) === "|") row = row.slice(0, -1);

    return row.split("|").map(function (cell) { return cell.trim(); });
  }

  function render(source, options) {
    options = options || {};

    var lines = String(source == null ? "" : source)
      .replace(/^﻿/, "")
      .replace(/\r\n?/g, "\n")
      .split("\n");

    var out = [];
    var paragraph = [];
    var listStack = [];      // {tag: "ul"|"ol", indent: number}

    function flushParagraph() {
      if (!paragraph.length) return;

      out.push("<p>" + inline(paragraph.join(" "), options) + "</p>");
      paragraph = [];
    }

    function closeLists(toIndent) {
      while (listStack.length && listStack[listStack.length - 1].indent >= toIndent) {
        out.push("</" + listStack.pop().tag + ">");
      }
    }

    for (var i = 0; i < lines.length; i++) {
      var line = lines[i];

      // ---------- код блоком ----------
      var fence = line.match(/^\s*(```|~~~)(.*)$/);
      if (fence) {
        flushParagraph();
        closeLists(0);

        var language = fence[2].trim().split(/\s+/)[0];
        var body = [];

        for (i++; i < lines.length; i++) {
          if (new RegExp("^\\s*" + fence[1]).test(lines[i])) break;
          body.push(lines[i]);
        }

        out.push('<pre class="code"' + (language ? ' data-lang="' + escapeHtml(language) + '"' : "") +
                 "><code>" + escapeHtml(body.join("\n")) + "</code></pre>");
        continue;
      }

      // ---------- пустая строка ----------
      if (!line.trim()) {
        flushParagraph();
        closeLists(0);
        continue;
      }

      // ---------- заголовок ----------
      var heading = line.match(/^(#{1,6})\s+(.*?)\s*#*\s*$/);
      if (heading) {
        flushParagraph();
        closeLists(0);

        var level = heading[1].length;
        out.push("<h" + level + ">" + inline(heading[2], options) + "</h" + level + ">");
        continue;
      }

      // ---------- таблица ----------
      if (line.indexOf("|") >= 0 && i + 1 < lines.length && isTableSeparator(lines[i + 1])) {
        flushParagraph();
        closeLists(0);

        var head = splitRow(line);
        var table = "<table><thead><tr>";
        for (var h = 0; h < head.length; h++) table += "<th>" + inline(head[h], options) + "</th>";
        table += "</tr></thead><tbody>";

        i += 2;
        for (; i < lines.length && lines[i].indexOf("|") >= 0 && lines[i].trim(); i++) {
          var cells = splitRow(lines[i]);

          table += "<tr>";
          for (var c = 0; c < cells.length; c++) table += "<td>" + inline(cells[c], options) + "</td>";
          table += "</tr>";
        }
        i--;

        out.push(table + "</tbody></table>");
        continue;
      }

      // ---------- горизонтальная черта ----------
      if (/^\s*([-*_])(\s*\1){2,}\s*$/.test(line)) {
        flushParagraph();
        closeLists(0);
        out.push("<hr>");
        continue;
      }

      // ---------- цитата ----------
      if (/^\s*>\s?/.test(line)) {
        flushParagraph();
        closeLists(0);

        var quote = [];
        for (; i < lines.length && /^\s*>\s?/.test(lines[i]); i++) {
          quote.push(lines[i].replace(/^\s*>\s?/, ""));
        }
        i--;

        out.push("<blockquote>" + render(quote.join("\n"), options) + "</blockquote>");
        continue;
      }

      // ---------- список ----------
      var item = line.match(/^(\s*)([-*+]|\d+[.)])\s+(.*)$/);
      if (item) {
        flushParagraph();

        var indent = item[1].replace(/\t/g, "    ").length;
        var tag = /^\d/.test(item[2]) ? "ol" : "ul";

        closeLists(indent + 1);

        var top = listStack[listStack.length - 1];
        if (!top || top.indent < indent) {
          listStack.push({ tag: tag, indent: indent });
          out.push("<" + tag + ">");
        }

        out.push("<li>" + inline(item[3], options) + "</li>");
        continue;
      }

      // ---------- обычный текст ----------
      // Продолжение пункта списка остаётся внутри него.
      if (listStack.length && /^\s{2,}\S/.test(line)) {
        out.push("<li class=\"cont\">" + inline(line.trim(), options) + "</li>");
        continue;
      }

      closeLists(0);
      paragraph.push(line.trim());
    }

    flushParagraph();
    closeLists(0);

    return out.join("\n");
  }

  return { render: render, escape: escapeHtml, safeUrl: safeUrl };
})();
