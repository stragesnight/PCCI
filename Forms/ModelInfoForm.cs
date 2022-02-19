//      -= PCCI =-
// Проект команды №3
// Группа: ПВ-011
// Компьютерная Академия "ШАГ", 2022

using System;
using System.Windows.Forms;
using PCCI.DatabaseInteraction;
using System.Collections.Generic;

namespace PCCI
{
    public partial class ModelInfoForm : Form
    {
        /// <summary>
        /// Конструктор класса ModelInfoForm.
        /// Инициализирует элементы формы в соответствии с данными модели.
        /// </summary>
        /// <param name="models">Список моделей, информацию о которых нужно отобразить</param>
        public ModelInfoForm(List<Model> models)
        {
            InitializeComponent();
        }
    }
}
