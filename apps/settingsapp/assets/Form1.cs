// ============================================================
//  Логика окна «Параметры системы» LisunOS.
//
//  Разметку описывает Form1.designer.cs, обработчики живут
//  в ядре — в классе SettingsLogicBridge.
//
//  Обработчики формы:
//     cmbLanguage_SelectedIndexChanged    — язык интерфейса
//     cmbLayout_SelectedIndexChanged      — раскладка клавиатуры
//     btnReloadPacks_Click                — перечитать языковые пакеты
//     cmbApplication_SelectedIndexChanged — выбор приложения
//     lstPermissions_DoubleClick          — переключить право
//     btnGrant_Click / btnRevoke_Click / btnResetRights_Click
//     btnOpenServer_Click / btnOpenSetup_Click / btnPhpStatus_Click
//
//  Текст между ~~~CANTEDIT~ и ~CANTEDIT~~~ изменять нельзя.
// ============================================================

// ~~~CANTEDIT~
namespace LisunOS
{
    partial class SettingsLogicBridge
    {
        // Связка с ядром: имя класса должно остаться прежним,
        // иначе служба не найдёт логику формы.
    }
}
// ~CANTEDIT~~~
