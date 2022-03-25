//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using PCCI.Core;
using PCCI.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using PCCI.DatabaseInteraction;

namespace PCCI
{
    public partial class ComponentInfoForm : Form
    {
        // Комплектующее, информация о котором отображается на форме
        private Component component;

        /// <summary>
        /// Конструктор для ComponentInfoForm.
        /// Инициализирует элементы формы в соответствии с данными комплектующей.
        /// </summary>
        /// <param name="component">Комплектующее, информацию о котором нужно отобразить.</param>
        public ComponentInfoForm(Component component)
        {
            InitializeComponent();
            this.component = component;
        }

        private void ComponentInfoForm_Load(object sender, EventArgs e)
        {
            FormToolbarHelper.AddMenuStripHandlers(menuStrip1);
            FormToolbarHelper.AddToolbarHandlers(panel1, button2, button1);

            labelName.Text = component.Name;
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(component.ImagePath);
            textBoxSummary.Text = component.Summary;
            textBoxSummary.Select(0, 0);
            textBoxDescription.Text = component.Description;
            textBoxDescription.Select(0, 0);
            labelIsNecessary.Text = component.IsNecessary ? "Да" : "Нет";

            buttonInfoLink.Click += (s, e1) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo(component.InfoLink));
                }
                catch (Exception)
                {
                    MessageBox.Show("Увы, сайт недоступен.", "Ошибка");
                }

            };

            buttonModelInformation.Click += (s, e1) => PCCIManager.ShowModelInfoForm(component.Id, this);
        }
    }
}
