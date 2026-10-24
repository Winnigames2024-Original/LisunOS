// ============================================================
//  Логика приложения SuperUser.
//
//  Право superuser выдаётся только отсюда: в терминале команды
//  su и sudo его больше не включают. Выдача требует подтверждения
//  флажком — чтобы случайный щелчок не открыл пакету всю систему.
//
//  Обработчики формы:
//     lstTargets_SelectedIndexChanged — карточка выбранного пакета
//     chkUnderstand_CheckedChanged    — подтверждение
//     btnGrantSuper_Click / btnRevokeSuper_Click
//     btnElevate_Click / btnDrop_Click — режим системы
//
//  Текст между ~~~CANTEDIT~ и ~CANTEDIT~~~ изменять нельзя.
// ============================================================

// ~~~CANTEDIT~
namespace LisunOS
{
    partial class SuperUserLogicBridge
    {
        // Связка с ядром: имя класса должно остаться прежним,
        // иначе служба не найдёт логику формы.
    }
}
// ~CANTEDIT~~~
