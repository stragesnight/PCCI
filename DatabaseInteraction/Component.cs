//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;

namespace PCCI.DatabaseInteraction
{
    /// <summary>
    /// Класс-представление таблицы Components.
    /// Отображает собой одну строчку из указанной таблицы.
    /// </summary>
    public sealed class Component : IDBEntry
    {
        // Идентификатор строки в таблице.
        public int Id { get; private set; }
        // Название комплектующей.
        public string Name { get; private set; }
        // Путь к связанному изображению.
        public string ImagePath { get; private set; }
        // Описание комплектующей.
        public string Description { get; private set; }
        // Ссылка на сайт с дополнительной информацией.
        public string InfoLink { get; private set; }
        // Явзялется ли комплектующая обязательной.
        public bool IsNecessary { get; private set; }

        /// <summary>
        /// Инициализировать объект Component из массива значений.
        /// </summary>
        /// <param name="values">Массив значений для их присваивания полям.</param>
        /// <returns>Возвращает новый объект Component с инициализированными полями.</returns>
        public static Component FromValueArray(object[] values)
        {
            Component component = new Component();
            component.Id = (int)values[0];
            component.Name = (string)values[1];
            component.ImagePath = (string)values[2];
            component.Description = (string)values[3];
            component.InfoLink = (string)values[4];
            component.IsNecessary = (bool)values[5];
            return component;
        }
    }
}
