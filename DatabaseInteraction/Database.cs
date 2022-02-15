//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using System.Data.SqlClient;

namespace PCCI.DatabaseInteraction
{
    /// <summary>
    /// Статический класс, ответственный за непосредственное взаимодействие
    /// других частей программы с внешней БД.
    /// Реализует возможность подключения к базе и извлечения данных из неё.
    /// </summary>
    public static class Database
    {
        //
        // Приватные поля
        //

        // Объект подключения к SQL серверу.
        private static SqlConnection sqlConnection = null;
        // Определяет, установлено ли соединение с сервером.
        private static bool connectionEstablished = false;

        //
        // Приватные методы
        //

        /// <summary>
        /// Открыть соединение SQL сервера.
        /// Если соединение уже открыто, то сначала закрыть, а потом опять открыть его.
        /// </summary>
        /// <returns>
        /// Возвращает true, если соединение было успешно открыто,
        /// Или false, если соединение открыть не удалось.
        /// </returns>
        private static bool OpenConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Закрыть соединение SQL сервера.
        /// </summary>
        /// <returns>
        /// Возвращает true, если соединение было успешно закрыто,
        /// Или false, если соединение закрыть не удалось.
        /// </returns>
        private static bool CloseConnection()
        {
            throw new NotImplementedException();
        }

        //
        // Публичные методы
        //

        /// <summary>
        /// Установить соединение с базой данных.
        /// В процессе изменить значение переменной sqlConnection.
        /// При завершении установить значение connectionEstablished = true.
        /// Это действие происходит в отдельном потоке.
        /// </summary>
        /// <returns>
        /// Возвращает true, если соединение установилось успешно,
        /// или false, если возникла ошибка при установке соединения.
        /// </returns>
        public static bool ConnectToDatabase()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Попытаться получить строчку с заданным индексом из заданной таблицы в базе данных.
        /// По умолчанию установить значение result = null.
        /// </summary>
        /// <param name="tableName">Имя таблицы, из которой нужно получить строку.</param>
        /// <param name="id">параметр поля "id" в строке для извлечения.</param>
        /// <param name="result">выходной параметр, в который будет записан результат запроса.</param>
        /// <returns>
        /// Возвращает true, если получение строки из таблицы произошло успешно,
        /// или false, если возникла ошибка при получении строки.
        /// </returns>
        public static bool TryGetRow(string tableName, int id, out IDBEntry result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Попытаться получить строки из заданной таблицы в базе данных.
        /// По умолчанию установить значение result = null.
        /// </summary>
        /// <param name="tableName">Имя таблицы, из которой нужно получить строки.</param>
        /// <param name="result">выходной параметр, в который будет записан результат запроса.</param>
        /// <returns>
        /// Возвращает true, если получение строк из таблицы произошло успешно,
        /// или false, если возникла ошибка при получении строк.
        /// </returns>
        public static bool TryGetRows(string tableName, out IDBEntry[] result)
        {
            throw new NotImplementedException();
        }
    }
}

