// ============================================================
//  Логика приложения «Доступ по сети».
//
//  Здесь видно, какой адрес вводить на телефоне или другом ПК,
//  работает ли сервер, какие есть пользователи и кто подключался.
//
//  Обработчики формы:
//     btnStartSsh_Click / btnStopSsh_Click   — сервер
//     btnCopyAddress_Click                   — адрес в буфер обмена
//     btnUserCreate_Click / btnUserPassword_Click / btnUserRemove_Click
//     lstSshUsers_SelectedIndexChanged
//
//  Текст между ~~~CANTEDIT~ и ~CANTEDIT~~~ изменять нельзя.
// ============================================================

// ~~~CANTEDIT~
namespace LisunOS
{
    partial class SshLogicBridge
    {
        // Связка с ядром: имя класса должно остаться прежним,
        // иначе служба не найдёт логику формы.
    }
}
// ~CANTEDIT~~~
