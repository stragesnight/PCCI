//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;

namespace PCCI.Core
{
    /// <summary>
    /// Главный упраляющий класс программы. Отвечает за все основные 
    /// действия программы и служит прослойкой между событиями пользовательского 
    /// интерфейса и внутренними компонентами.
    /// </summary>
    public static class PCCIManager
    {
        /// <summary>
        /// Инициализировать компоненты программы, подготовив её к работе.
        /// Установить подключение с базой данных,
        /// Показать главную форму.
        /// </summary>
        public static void Initialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выйти из программы.
        /// Освободить все используемые ресурсы,
        /// Закрыть соединение с базой данных,
        /// Закрыть все оставшиеся формы.
        /// </summary>
        public static void Exit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Показать главную форму.
        /// Спрятать предыдущую форму, если такая есть.
        /// </summary>
        public static void ShowMainForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Показать форму с информацией о комплектующих.
        /// Спрятать предыдущую форму, если такая есть.
        /// </summary>
        /// <param name="id">Идентификатор комплектующей в таблице Components.</param>
        public static void ShowComponentInfoForm(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Показать форму с информацией о моделях комплектующих.
        /// Спрятать предыдущую форму, если такая есть.
        /// </summary>
        /// <param name="id">Идентификатор комплектующей в таблице Models.</param>
        public static void ShowModelInfoForm(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Закрыть текущую форму и показать предыдущую,
        /// Обновить значение activeForm.
        /// </summary>
        public static void CloseActiveForm()
        {
            throw new NotImplementedException();
        }
    }
}

