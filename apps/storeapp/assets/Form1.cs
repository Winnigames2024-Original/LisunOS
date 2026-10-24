// ============================================================
//  Логика Каталога приложений LisunOS.
//
//  Разметку описывает Form1.designer.cs, обработчики живут
//  в ядре — в классе StoreLogicBridge.
//
//  Обработчики формы:
//     lstPackages_SelectedIndexChanged — карточка выбранного пакета
//     lstPackages_DoubleClick          — установить или запустить
//     btnRefresh_Click                 — перечитать каталог из сети
//     btnInstall_Click / btnRemove_Click / btnRun_Click
//
//  Текст между ~~~CANTEDIT~ и ~CANTEDIT~~~ изменять нельзя.
// ============================================================

// ~~~CANTEDIT~
namespace LisunOS
{
    partial class StoreLogicBridge
    {
        // Связка с ядром: имя класса должно остаться прежним,
        // иначе служба не найдёт логику формы.
    }
}
// ~CANTEDIT~~~
