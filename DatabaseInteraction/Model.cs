//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;

namespace PCCI.DatabaseInteraction
{
    /// <summary>
    /// Класс-представление таблицы Models.
    /// Отображает собой одну строчку из указанной таблицы.
    /// </summary>
    public sealed class Model : IDBEntry
    {
        // Идентификатор строчки в таблице.
        public int Id { get; set; }
        // Идентификатор типа комплектующего в таблице Components.
        public int ComponentId { get; private set; }
        // Название модели.
        public string Name { get; private set; }
        // Производитель модели.
        public string Manufacturer { get; private set; }
        // Год выпуска модели.
        public DateTime ReleaseYear { get; private set; }
        // Средняя цена на модель (в долларах США).
        public float AvgPrice { get; private set; }
        // Путь к связанному изображению.
        public string ImagePath { get; private set; }
        // Характеристики модели
        public string Characteristics { get; private set; }
        // Ссылка на сайт с дополнительной информацией.
        public string InfoLink { get; private set; }

        /// <summary>
        /// Инициализировать объект Model из массива значений.
        /// </summary>
        /// <param name="values">Массив значений для их присваивания полям.</param>
        /// <returns>Возвращает новый объект Model с инициализированными полями.</returns>
        public static Model FromValueArray(object[] values)
        {
            Model model = new Model();
            model.Id = (int)values[0];
            model.ComponentId = (int)values[1];
            model.Name = (string)values[2];
            model.Manufacturer = (string)values[3];
            model.ReleaseYear = (DateTime)values[4];
            model.AvgPrice = (float)(double)values[5];
            model.ImagePath = (string)values[6];
            model.Characteristics = (string)values[7];
            model.InfoLink = (string)values[8];
            return model;
        }

        /// <summary>
        /// Превращение объекта типа Model в строку.
        /// </summary>
        public override string ToString() => Name;
    }
}
