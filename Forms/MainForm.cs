//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using PCCI.Core;
using PCCI.Forms;
using System.Windows.Forms;

namespace PCCI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Конструктор формы MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PCCIManager.Initialize();
            FormToolbarHelper.AddMenuStripHandlers(menuStrip1);
            FormToolbarHelper.AddToolbarHandlers(panel1, button2, button1);
        }

        private void buttonMotherboard_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(1, this);
        }

        private void buttonCPU_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(2, this);
        }

        private void buttonRAM_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(3, this);
        }

        private void buttonHDD_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(4, this);
        }

        private void buttonPSU_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(5, this);
        }

        private void buttonCase_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(6, this);
        }

        private void buttonVideocard_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(7, this);
        }

        private void buttonSoundcard_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(8, this);
        }

        private void buttonNetcard_Click(object sender, EventArgs e)
        {
            PCCIManager.ShowComponentInfoForm(8, this);
        }
    }
}
