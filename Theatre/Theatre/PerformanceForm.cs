using System.ComponentModel;
using System.Text.RegularExpressions;
using Theatre.Models;

namespace Theatre
{
    /// <summary>
    /// Класс формы для добавления/изменения записей.
    /// </summary>
    public partial class PerformanceForm : Form
    {
        /// <summary>
        /// Объект, который будет добавлен/изменен.
        /// </summary>
        public Performance Performance { get; set; }

        /// <summary>
        /// Коллекция уже добавленных объектов (для проверки на дублирование).
        /// </summary>
        public BindingList<Performance> List { get; set; }

        /// <summary>
        /// Конструктор формы, который вызывается при изменении записей.
        /// </summary>
        /// <param name="_performance">Объект, который будет изменен.</param>
        /// <param name="_list">Коллекция уже существующих объектов.</param>
        public PerformanceForm(Performance _performance, BindingList<Performance> _list)
        {
            InitializeComponent();
            Performance = _performance;
            List = _list;
            Text = "Изменение записи";
            btnAdd.Text = "Изменить";
            tbNameOfPerformance.Text = Performance.PerformanceName;
            tbDirectorName.Text = Performance.DirectorName;
            cbGenre.Text = Performance.Genre;
            dtpPremiereDate.Value = Performance.PremiereDate;
            dtpDuration.Value = DateTime.Today.Add(Performance.Duration);
            nudTicketCost.Value = Performance.TicketCost;
        }

        /// <summary>
        /// Конструктор формы, который вызывается при добавлении записей.
        /// </summary>
        /// <param name="_list">Коллекция уже существующих объектов.</param>
        public PerformanceForm(BindingList<Performance> _list)
        {
            InitializeComponent();
            Performance = new Performance();
            List = _list;
            cbGenre.SelectedIndex = 0;
            dtpPremiereDate.Value = DateTime.Now;
            dtpDuration.Value = DateTime.Today;
            Text = "Добавление записи";
            btnAdd.Text = "Добавить";
        }


        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки добавить/изменить запись.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tbDirectorName.Text == "" || tbNameOfPerformance.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!Regex.IsMatch(tbDirectorName.Text, @"^[А-ЯЁа-яёa-zA-Z\s]+$"))
            {
                MessageBox.Show("Имя введено некорректно. Пример правильного ввода: Константин Станиславский, Билл Ирвин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpDuration.Value.TimeOfDay == TimeSpan.Zero)
            {
                MessageBox.Show("Продолжительность не может быть нулевой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (List.Any(item =>
                    item != Performance &&
                    item.PerformanceName == tbNameOfPerformance.Text &&
                    item.Genre == cbGenre.Text &&
                    item.PremiereDate.Date == dtpPremiereDate.Value.Date &&
                    item.TicketCost == nudTicketCost.Value &&
                    item.Duration == dtpDuration.Value.TimeOfDay))
            {
                MessageBox.Show("Такая запись уже добавлена в базу данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Performance.PerformanceName = tbNameOfPerformance.Text;
            Performance.DirectorName = tbDirectorName.Text;
            Performance.Genre = cbGenre.Text;
            Performance.PremiereDate = dtpPremiereDate.Value;
            Performance.Duration = dtpDuration.Value.TimeOfDay;
            Performance.TicketCost = nudTicketCost.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
