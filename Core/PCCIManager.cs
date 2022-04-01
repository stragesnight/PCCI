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
        private static List<IDBEntry> components = null;
        private static List<IDBEntry> models = null;

        /// <summary>
        /// Инициализировать компоненты программы, подготовив её к работе.
        /// Установить подключение с базой данных.
        /// </summary>
        public static void Initialize()
        {
            Database.ConnectToDatabase();

            if (!Database.TryGetRows("Components", out components, Component.FromValueArray))
            {
                MessageBox.Show("Невозможно получить список комплектующих", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }

            if (!Database.TryGetRows("Models", out models, Model.FromValueArray))
            {
                MessageBox.Show("Невозможно получить список моделей", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
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
            MainForm form = new MainForm();
            prevForm.Hide();
            form.Show();
        }

        /// <summary>
        /// Показать форму с информацией о комплектующих.
        /// Спрятать предыдущую форму, если такая есть.
        /// </summary>
        /// <param name="id">Идентификатор комплектующей в таблице Components.</param>
        /// <param name="prevForm">Предыдущая форма, которая будет спрятана.</param>
        public static void ShowComponentInfoForm(int id, Form prevForm)
        {
            try
            {
                ComponentInfoForm form = new ComponentInfoForm(components[id - 1] as Component);
                prevForm.Hide();
                form.ShowDialog();
                if (prevForm is MainForm)
                    prevForm.Show();
                else
                    prevForm.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно получить информацию о данном комплектующем", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                List<IDBEntry> entries = new List<IDBEntry>();
                foreach (IDBEntry entry in models)
                {
                    if ((entry as Model).ComponentId == id)
                        entries.Add(entry);
                }

                ModelInfoForm form = new ModelInfoForm(entries);
                prevForm.Hide();
                form.ShowDialog();
                if (prevForm is MainForm)
                    prevForm.Show();
                else
                    prevForm.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно получить информацию о моделях данного комплектующего", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

