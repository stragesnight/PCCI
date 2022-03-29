//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PCCI.DatabaseInteraction
{
    /// <summary>
    /// Статический класс, ответственный за непосредственное взаимодействие
    /// других частей программы с внешней БД.
    /// Реализует возможность подключения к базе и извлечения данных из неё.
    /// </summary>
    public static class Database
    {
        public delegate IDBEntry RowInitializer(object[] values);

        // Объект подключения к SQL серверу.
        private static SqlConnection sqlConnection = null;

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
            if (sqlConnection.State == ConnectionState.Open)
                CloseConnection();

            sqlConnection.Open();

            return sqlConnection.State == ConnectionState.Open;
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
            if (sqlConnection.State == ConnectionState.Closed)
                return true;

            sqlConnection.Close();

            return sqlConnection.State == ConnectionState.Closed;
        }

        /// <summary>
        /// Проверяет ввод на безопасность использования.
        /// </summary>
        /// <param name="str">Строка запроса для проверки.</param>
        /// <returns></returns>
        private static bool IsSafeSelectInput(string str)
        {
            string[] bannedKeywords = new string[] { 
                "DROP", "UPDATE", "ALTER", "INSERT", "TABLE", "DATABASE"
            };

            bool isSafe = true;

            foreach (string banned in bannedKeywords)
                isSafe &= !str.Contains(banned);

            return isSafe;
        }

        /// <summary>
        /// Установить соединение с базой данных.
        /// В процессе изменить значение переменной sqlConnection.
        /// </summary>
        public static void ConnectToDatabase()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string connectionString = ConfigurationManager
                .ConnectionStrings["PCCIDB_ConnStr"].ConnectionString;
            connectionString = connectionString.Replace("{BASE_DIR}", baseDir);
            
            sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Попытаться получить строчку с заданным индексом из заданной таблицы в базе данных.
        /// По умолчанию установить значение result = null.
        /// </summary>
        /// <param name="tableName">Имя таблицы, из которой нужно получить строку.</param>
        /// <param name="id">Параметр поля "id" в строке для извлечения.</param>
        /// <param name="result">Выходной параметр, в который будет записан результат запроса.</param>
        /// <param name="init">Делегат, который будет использоваться для инициализации объекта.</param>
        /// <returns>
        /// Возвращает true, если получение строки из таблицы произошло успешно,
        /// или false, если возникла ошибка при получении строки.
        /// </returns>
        public static bool TryGetRow(string tableName, int id, out IDBEntry result, RowInitializer init)
        {
            result = null;

            if (!OpenConnection())
                return false;

            try
            {
                // Проверить на возможную инъекцию
                if (tableName.LastIndexOf(' ') > 0 || id < 0)
                    return false;

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(
                    $"SELECT * FROM [{tableName}] WHERE [id] = @i", 
                    sqlConnection
                );
                adapter.SelectCommand.Parameters.AddWithValue("@i", id);
                adapter.Fill(ds);

                result = init(ds.Tables[0].Rows[0].ItemArray);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }

            return true;
        }

        /// <summary>
        /// Попытаться получить строки из заданной таблицы в базе данных.
        /// По умолчанию установить значение result = null.
        /// </summary>
        /// <param name="tableName">Имя таблицы, из которой нужно получить строки.</param>
        /// <param name="result">Выходной параметр, в который будет записан результат запроса.</param>
        /// <param name="init">Делегат, который будет использоваться для инициализации объекта.</param>
        /// <returns>
        /// Возвращает true, если получение строк из таблицы произошло успешно,
        /// или false, если возникла ошибка при получении строк.
        /// </returns>
        public static bool TryGetRows(string tableName, out List<IDBEntry> result, RowInitializer init)
        {
            result = null;

            if (!OpenConnection())
                return false;

            try
            {
                // Проверить на возможную инъекцию
                if (tableName.LastIndexOf(' ') > 0)
                    return false;

                result = new List<IDBEntry>();

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(
                    $"SELECT * FROM [{tableName}]",
                    sqlConnection
                );
                adapter.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                    result.Add(init(row.ItemArray));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }

            return true;
        }

        /// <summary>
        /// Попытаться получить строки из заданной таблицы в базе данных.
        /// По умолчанию установить значение result = null.
        /// </summary>
        /// <param name="tableName">Имя таблицы, из которой нужно получить строки.</param>
        /// <param name="filter">Фильтр для строк. По синтаксису соответствует WHERE в SQL.</param>
        /// <param name="result">Выходной параметр, в который будет записан результат запроса.</param>
        /// <param name="init">Делегат, который будет использоваться для инициализации объекта.</param>
        /// <returns>
        /// Возвращает true, если получение строк из таблицы произошло успешно,
        /// или false, если возникла ошибка при получении строк.
        /// </returns>
        public static bool TryGetRowsWhere(string tableName, string filter, out List<IDBEntry> result, RowInitializer init)
        {
            result = null;

            if (!OpenConnection())
                return false;

            try
            {
                // Проверить на возможную инъекцию
                if (tableName.LastIndexOf(' ') > 0 || !IsSafeSelectInput(filter))
                    return false;

                result = new List<IDBEntry>();

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(
                    $"SELECT * FROM [{tableName}] {filter}",
                    sqlConnection
                );
                adapter.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                    result.Add(init(row.ItemArray));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }

            return true;
        }
    }
}

