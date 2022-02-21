//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using PCCI.Forms;
using System.Windows.Forms;
using PCCI.DatabaseInteraction;

namespace PCCI
{
    public partial class ComponentInfoForm : Form
    {
        /// <summary>
        /// Конструктор для ComponentInfoForm.
        /// Инициализирует элементы формы в соответствии с данными комплектующей.
        /// </summary>
        /// <param name="component">Комплектующее, информацию о котором нужно отобразить.</param>
        public ComponentInfoForm(Component component)
        {
            InitializeComponent();
        }

        private void ComponentInfoForm_Load(object sender, EventArgs e)
        {
            FormToolbarHelper.AddMenuStripHandlers(menuStrip1);
            FormToolbarHelper.AddToolbarHandlers(panel1, button2, button1);
        }
    }
}
