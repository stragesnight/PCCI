//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using PCCI.Core;
using PCCI.Forms;
using System.Diagnostics;
using System.Windows.Forms;
using PCCI.DatabaseInteraction;
using System.Collections.Generic;

namespace PCCI
{
    public partial class ModelInfoForm : Form
    {
        // Список моделей
        private List<IDBEntry> models;

        /// <summary>
        /// Конструктор класса ModelInfoForm.
        /// Инициализирует элементы формы в соответствии с данными модели.
        /// </summary>
        /// <param name="models">Список моделей, информацию о которых нужно отобразить</param>
        public ModelInfoForm(List<IDBEntry> models)
        {
            InitializeComponent();
            this.models = models;
        }

        private void ModelInfoForm_Load(object sender, EventArgs e)
        {
            FormToolbarHelper.AddMenuStripHandlers(menuStrip1);
            FormToolbarHelper.AddToolbarHandlers(panel1, button2, button1);

            listBoxModelList.Items.Clear();
            listBoxModelList.FormattingEnabled = false;
            listBoxModelList.Items.AddRange(models.ToArray());

            listBoxModelList.SelectedIndex = 0;
        }

        private void listBoxModelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model model = listBoxModelList.SelectedItem as Model;
            IDBEntry entry;
            
            if (!Database.TryGetRow("Components", model.ComponentId, out entry, Component.FromValueArray))
            {
                MessageBox.Show("Error", "Error");
                return;
            }

            labelComponentType.Text = (entry as Component).Name;
            labelName.Text = model.Name;
            labelManufacturer.Text = model.Manufacturer;
            if (model.ReleaseYear.Year != 2000)
                labelReleaseYear.Text = model.ReleaseYear.Year.ToString();
            else
                labelReleaseYear.Text = "-";
            labelAvgPrice.Text = string.Format("${0:N2}", model.AvgPrice);
            textBoxCharacteristics.Text = model.Characteristics;
            textBoxCharacteristics.Select(0, 0);

            buttonInfoLink.Click += (s, e1) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo(model.InfoLink));
                }
                catch (Exception)
                {
                    MessageBox.Show("Увы, сайт недоступен.", "Ошибка");
                }

            };

            buttonComponentInformation.Click += (s, e1) 
                => PCCIManager.ShowComponentInfoForm(model.ComponentId, this);
        }
    }
}
