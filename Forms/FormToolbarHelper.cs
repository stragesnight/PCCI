//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using PCCI.Core;
using System.Drawing;
using System.Windows.Forms;

namespace PCCI.Forms
{
    /// <summary>
    /// Статический класс, отвечающий за вызовы событий элементов меню.
    /// Набор элементов меню должен чётко соответствовать порядку, так что
    /// этот класс годится только для этого конкретного проекта.
    /// </summary>
    public static class FormToolbarHelper
    {
        /// <summary>
        /// Привязать методы к соответствующим событиям элементов меню.
        /// Элементы меню должны иметь определённый порядок.
        /// </summary>
        /// <param name="menuStrip">Строка меню, к которой нужно привязать методы.</param>
        public static void AddMenuStripHandlers(MenuStrip menuStrip)
        {
            Form form = menuStrip.FindForm();

            for (int i = 0; i < 9; ++i)
            {
                // Создание новой переменной здесь обязательно,
                // иначе все вызовы методов имели бы id = 10
                int tmp = i + 1;
                (menuStrip.Items[0] as ToolStripMenuItem).DropDownItems[i].Click
                    += (s, e) => PCCIManager.ShowComponentInfoForm(tmp, form);
                (menuStrip.Items[1] as ToolStripMenuItem).DropDownItems[i].Click
                    += (s, e) => PCCIManager.ShowModelInfoForm(tmp, form);
            }

            menuStrip.Items[2].Click += ShowAboutMessageBox;
            menuStrip.Items[3].Click += (s, e) => Application.Exit();
        }

        public static void AddToolbarHandlers(Control draggable, Control minimize, Control close)
        {
            Form form = draggable.FindForm();

            draggable.MouseDown += (s, e) => draggable.Tag = e.Location;
            draggable.MouseUp += (s, e) => draggable.Tag = null;
            draggable.MouseMove += (s, e) => {
                if (draggable.Tag == null)
                    return;
                Point start = (Point)draggable.Tag;
                form.Left += e.X - start.X;
                form.Top += e.Y - start.Y;
            };

            minimize.Click += (s, e) => form.WindowState = FormWindowState.Minimized;
            close.Click += (s, e) => HandleCloseButton(form);
        }

        private static void HandleCloseButton(Form prevForm)
        {
            if (prevForm is MainForm)
                Application.Exit();
            else
                PCCIManager.ShowMainForm(prevForm);
        }

        private static void ShowAboutMessageBox(object sender, EventArgs e)
        {
            MessageBox.Show("PCCI - PC Component Info\n" +
                "Программа для просмотра информации о компютерных комплектующих " +
                "и их моделях. Создана в рамках программы обучения компьютерной " +
                "академии \"ШАГ\" командой №3.\n\n" +
                "Состав команды:\n" +
                " - Шелест Александр\n" +
                " - Фурсенко Михаил\n" +
                " - Федота Констянтин\n\n" +
                "г. Белая Церковь, Мирная Украина, 2022", "О программе", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
