// ============================================================
//  Логика приложения «Журнал».
//
//  Показывает записи ядра с поиском и фильтром по источнику
//  (источник — это метка в квадратных скобках: [store], [ssh]…).
//
//  Обработчики формы:
//     txtLogFind_TextChanged, cmbLogSource_SelectedIndexChanged
//     chkOnlyErrors_CheckedChanged, chkFollow_CheckedChanged
//     btnLogRefresh_Click, btnLogSave_Click, btnLogCopy_Click
//
//  Текст между ~~~CANTEDIT~ и ~CANTEDIT~~~ изменять нельзя.
// ============================================================

// ~~~CANTEDIT~
namespace LisunOS
{
    partial class LogsLogicBridge
    {
        // Связка с ядром: имя класса должно остаться прежним,
        // иначе служба не найдёт логику формы.
    }
}
// ~CANTEDIT~~~
