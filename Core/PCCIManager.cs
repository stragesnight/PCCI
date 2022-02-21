//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using System.Windows.Forms;
using PCCI.DatabaseInteraction;
using System.Collections.Generic;

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
        /// Установить подключение с базой данных.
        /// </summary>
        public static void Initialize()
        {
            Database.ConnectToDatabase();
        }

        /// <summary>
        /// Выйти из программы.
        /// </summary>
        public static void Exit()
        {
            Application.Exit();
        }

        /// <summary>
        /// Показать главную форму.
        /// Спрятать предыдущую форму, если такая есть.
        /// </summary>
        /// <param name="prevForm">Предыдущая форма, которая будет спрятана.</param>
        public static void ShowMainForm(Form prevForm)
        {
            prevForm?.Hide();
            MainForm form = new MainForm();
            form.ShowDialog();
            prevForm?.Show();
        }

        /// <summary>
        /// Показать форму с информацией о комплектующих.
        /// Спрятать предыдущую форму, если такая есть.
        /// </summary>
        /// <param name="id">Идентификатор комплектующей в таблице Components.</param>
        /// <param name="prevForm">Предыдущая форма, которая будет спрятана.</param>
        public static void ShowComponentInfoForm(int id, Form prevForm)
        {
            IDBEntry entry;
            if (!Database.TryGetRow("Components", id, out entry, Component.FromValueArray))
            {
                MessageBox.Show("Error", "Error"); return;
            }
            else
            {
                prevForm?.Hide();
                ComponentInfoForm form = new ComponentInfoForm(entry as Component);
                form.ShowDialog();
                prevForm?.Show();
            }
        }

        /// <summary>
        /// Показать форму с информацией о моделях комплектующих.
        /// Спрятать предыдущую форму, если такая есть.
        /// </summary>
        /// <param name="id">Идентификатор комплектующей в таблице Models.</param>
        /// <param name="prevForm">Предыдущая форма, которая будет спрятана.</param>
        public static void ShowModelInfoForm(int id, Form prevForm)
        {
            List<IDBEntry> entries;
            if (!Database.TryGetRowsWhere("Models", $"WHERE component_id = {id}", out entries, Model.FromValueArray))
            {
                MessageBox.Show("Error", "Error"); return;
            }
            else
            {
                prevForm?.Hide();
                ModelInfoForm form = new ModelInfoForm(entries);
                form.ShowDialog();
                prevForm?.Show();
            }
        }
    }
}

