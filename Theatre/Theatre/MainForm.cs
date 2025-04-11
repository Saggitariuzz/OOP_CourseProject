using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.ComponentModel;
using Theatre.DataBase;
using Theatre.Models;

namespace Theatre
{

    /// <summary>
    /// Делегат для обработки событий изменения в коллекции записей.
    /// </summary>
    /// <param name="p">Объект, который был добавлен/удален.</param>
    public delegate void CollectionChanged(Performance p);
    
    /// <summary>
    /// Класс основной формы приложения.
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// Коллекция, хранящая записи о представлениях.
        /// </summary>
        private BindingList<Performance> performances;

        /// <summary>
        /// Строка для подключения к БД.
        /// </summary>
        private string connection;

        /// <summary>
        /// Событие удаления записи из коллекции.
        /// </summary>
        public event CollectionChanged ItemRemoved;

        /// <summary>
        /// Событие добавления записи в коллекцию.
        /// </summary>
        public event CollectionChanged ItemAdded;

        /// <summary>
        /// Флаг направления сортировки (в прямом/обратном алфавитном порядке).
        /// </summary>
        private bool reverseSort = false;

        /// <summary>
        /// Конструктор формы.
        /// Настраивает таблицу для отображения записей, инициализириует коллекцию, события
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            performances = new BindingList<Performance>();
            cbFilter.SelectedIndex = 0;
            connection = "";
            bindingSource.DataSource = performances;
            dgvMainTable.DataSource = bindingSource;
            dgvMainTable.Columns["PerformanceName"].HeaderText = "Название спектакля";
            dgvMainTable.Columns["DirectorName"].HeaderText = "Имя режиссера";
            dgvMainTable.Columns["Genre"].HeaderText = "Жанр";
            dgvMainTable.Columns["PremiereDate"].HeaderText = "Дата премьеры";
            dgvMainTable.Columns["Duration"].HeaderText = "Длительность";
            dgvMainTable.Columns["TicketCost"].HeaderText = "Стоимость билета";
            dgvMainTable.Columns["Id"].Visible = false;
            dgvMainTable.Columns["PremiereDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvMainTable.Columns["Duration"].DefaultCellStyle.Format = @"hh\:mm\:ss";
            dgvMainTable.Columns["TicketCost"].DefaultCellStyle.Format = "F2";
            dgvMainTable.RowHeadersWidth = 25;
            ItemAdded += (p => { });
            ItemRemoved += (p => { });
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для создания новой БД.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "ИС «Театр»";
            connection = "";
            bindingSource.DataSource = performances;
            performances.Clear();
            labelCount.Text = "Отображено 0 из 0 записей";
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для загрузки созданной ранее БД.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SQLite Database Files (*.db)|*.db",
                Title = "Выберите файл базы данных",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindingSource.DataSource = performances;
                connection = $"Data Source={openFileDialog.FileName}";
                Text = $"ИС «Театр» - {connection.Replace("Data Source=", "")}";
                using (DatabaseContext context = new DatabaseContext(connection))
                {
                    performances.Clear();
                    foreach (Performance p in context.Performances.ToList())
                    {
                        performances.Add(p);
                    }
                }
                labelCount.Text = $"Отображено {performances.Count} из {performances.Count} записей";
            }
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для сохранения записей в файл БД.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection == "")
            {
                SaveDatabaseAs();
            }
            else
            {
                using (DatabaseContext context = new DatabaseContext(connection))
                {
                    context.RemoveRange(context.Performances);
                    context.SaveChanges();
                    context.AddRange(performances);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для сохранения записей в новый файл БД.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabaseAs();
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для добавления новой записи.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void AddRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PerformanceForm performanceForm = new PerformanceForm(performances))
            {
                if (performanceForm.ShowDialog() == DialogResult.OK)
                {
                    Performance newPerformance = new Performance
                    {
                        PerformanceName = performanceForm.Performance.PerformanceName,
                        DirectorName = performanceForm.Performance.DirectorName,
                        Genre = performanceForm.Performance.Genre,
                        PremiereDate = performanceForm.Performance.PremiereDate,
                        Duration = performanceForm.Performance.Duration,
                        TicketCost = performanceForm.Performance.TicketCost
                    };
                    performances.Add(newPerformance);
                    ItemAdded.Invoke(newPerformance);
                    dgvMainTable.Refresh();
                    labelCount.Text = $"Отображено {(bindingSource.DataSource as BindingList<Performance>).Count} из {performances.Count} записей";
                }
            }
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для изменения существующей записи.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void ChangeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMainTable.SelectedRows.Count == 1)
            {
                Performance performance = bindingSource.Current as Performance;
                using (PerformanceForm performanceForm = new PerformanceForm(performance, performances))
                {
                    if (performanceForm.ShowDialog() == DialogResult.OK)
                    {
                        performance.PerformanceName = performanceForm.Performance.PerformanceName;
                        performance.DirectorName = performanceForm.Performance.DirectorName;
                        performance.Genre = performanceForm.Performance.Genre;
                        performance.PremiereDate = performanceForm.Performance.PremiereDate;
                        performance.Duration = performanceForm.Performance.Duration;
                        performance.TicketCost = performanceForm.Performance.TicketCost;
                        dgvMainTable.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выделите одну запись для изменения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для удаления существующей записи.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void RemoveRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current == null)
            {
                MessageBox.Show("Сначала выберите запись", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Performance performance = bindingSource.Current as Performance;
            ItemRemoved.Invoke(performance);
            performances.Remove(performance);
            labelCount.Text = $"Отображено {(bindingSource.DataSource as BindingList<Performance>).Count} из {performances.Count} записей";
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для удаления всех записей.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (performances.Count == 0)
            {
                MessageBox.Show("База данных пуста", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bindingSource.DataSource = performances;
            performances.Clear();
            labelCount.Text = "Отображено 0 из 0 записей";
        }

        /// <summary>
        /// Метод, сохраняющий записи в новый файл БД.
        /// </summary>
        private void SaveDatabaseAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "SQLite Database Files (*.db)|*.db",
                Title = "Сохранить как",
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                connection = $"Data Source={saveFileDialog.FileName}";
                Text = $"ИС «Театр» - {connection.Replace("Data Source=", "")}";
                using (DatabaseContext context = new DatabaseContext(connection))
                {
                    context.Database.EnsureCreated();
                    context.Performances.AddRange(performances);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Метод, обрабатывающий изменение текста для фильтрации записей.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (tbFilterValue.Text == "")
            {
                labelCount.Text = $"Отображено {performances.Count} из {performances.Count} записей";
                bindingSource.DataSource = performances;
                return;
            }
            dgvMainTable.Refresh();
            BindingList<Performance> tmp = performances;
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    Filter(p => p.PerformanceName);
                    break;
                case 1:
                    Filter(p => p.DirectorName);
                    break;
                case 2:
                    Filter(p => p.Genre);
                    break;
                case 3:
                    Filter(p => p.PremiereDate.ToString());
                    break;
                case 4:
                    Filter(p => p.Duration.ToString());
                    break;
                case 5:
                    Filter(p => p.TicketCost.ToString());
                    break;
                default:
                    bindingSource.DataSource = performances;
                    break;
            }
        }

        /// <summary>
        /// Метод, фильтрующий записи по заданному критерию.
        /// </summary>
        /// <param name="selector">Делегат, возвращающий строковое значение из объекта Performance</param>
        private void Filter(Func<Performance, string> selector)
        {
            ItemAdded -= (p => { });
            ItemRemoved -= (p => { });
            BindingList<Performance> tmp = new BindingList<Performance>(
                performances
                .Where(s => selector(s)
                    .ToLower()
                    .Trim()
                    .Contains(tbFilterValue.Text.ToLower().Trim())
                ).
                ToList());
            ItemRemoved += (p => tmp.Remove(p));
            ItemAdded += (p =>
            {
                if (selector(p).ToLower().Contains(tbFilterValue.Text.ToLower()))
                {
                    tmp.Add(p);
                }
            });
            bindingSource.DataSource = tmp;
            labelCount.Text = $"Отображено {tmp.Count} из {performances.Count} записей";
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для сортировки записей.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void btnSort_Click(object sender, EventArgs e)
        {
            if (performances.Count == 0)
            {
                return;
            }
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    SortList(p => p.PerformanceName);
                    break;
                case 1:
                    SortList(p => p.DirectorName);
                    break;
                case 2:
                    SortList(p => p.Genre);
                    break;
                case 3:
                    SortList(p => p.PremiereDate);
                    break;
                case 4:
                    SortList(p => p.Duration);
                    break;
                case 5:
                    SortList(p => p.TicketCost);
                    break;
                default:
                    bindingSource.DataSource = performances;
                    break;
            }
        }

        /// <summary>
        /// Метод, обрабатывающий нажатие кнопки для сохранения таблицы с записями в PDF-файл.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void CreatePdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF файлы (*.pdf)|*.pdf",
                Title = "Сохранить отчет по текущим данным",
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Table table = new Table(dgvMainTable.Columns.Count - 1);

                PdfFont font = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\arial.ttf", PdfEncodings.IDENTITY_H);
                foreach (DataGridViewColumn i in dgvMainTable.Columns)
                {
                    if (i.Visible && i.Index != 0)
                    {
                        table.AddCell(new Paragraph(i.HeaderText).SetFont(font));
                    }
                }
                foreach (DataGridViewRow i in dgvMainTable.Rows)
                {
                    foreach (DataGridViewCell j in i.Cells)
                    {
                        if (dgvMainTable.Columns[j.ColumnIndex].Visible && j.ColumnIndex != 0)
                        {
                            if (j.Value is DateTime date)
                            {
                                table.AddCell(new Paragraph(date.ToString("dd.MM.yyyy")).SetFont(font));
                            }
                            else
                            {
                                table.AddCell(new Paragraph(j.Value.ToString()).SetFont(font));
                            }

                        }

                    }
                }
                using (PdfWriter pdfWriter = new PdfWriter(saveFileDialog.FileName))
                using (PdfDocument pdf = new PdfDocument(pdfWriter))
                {
                    Document document = new Document(pdf);
                    document.Add(table);
                    document.Close();
                }
            }
        }

        /// <summary>
        /// Метод, обрабатывающий изменение текста для поиска записей.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dgvMainTable.Rows)
            {
                i.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                i.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            }
            if (tbSearch.Text == "")
            {
                return;
            }
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    Search(p => p.PerformanceName);
                    break;
                case 1:
                    Search(p => p.DirectorName);
                    break;
                case 2:
                    Search(p => p.Genre);
                    break;
                case 3:
                    Search(p => p.PremiereDate.ToString());
                    break;
                case 4:
                    Search(p => p.Duration.ToString());
                    break;
                case 5:
                    Search(p => p.TicketCost.ToString());
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Метод, сортирующий записи по алфавиту/возрастанию (убыванию) (в зависимости от критерия).
        /// </summary>
        /// <typeparam name="T">Тип значения, по которому производится сортировка.</typeparam>
        /// <param name="selector">Делегат, определяющий поле объекта, по которому производится сортировка.</param>
        private void SortList<T>(Func<Performance, T> selector)
        {
            ItemAdded -= (p => { });
            ItemRemoved -= (p => { });
            BindingList<Performance> tmp = bindingSource.DataSource as BindingList<Performance>;
            tmp = reverseSort
                ? new BindingList<Performance>(tmp.OrderByDescending(selector).ToList())
                : new BindingList<Performance>(tmp.OrderBy(selector).ToList());
            ItemRemoved += (p => tmp.Remove(p));
            ItemAdded += (p => tmp.Add(p));
            bindingSource.DataSource = tmp;
            reverseSort = !reverseSort;
        }

        /// <summary>
        /// Метод, выполняющий поиск записей по критерию.
        /// </summary>
        /// <param name="selector">Делегат, возвращающий значение, по которому производится поиск.</param>
        private void Search(Func<Performance, string> selector)
        {
            foreach(DataGridViewRow i in dgvMainTable.Rows)
            {
                Performance item = i.DataBoundItem as Performance;
                if (selector(item).ToLower().Trim().Contains(tbSearch.Text.Trim().ToLower()))
                {
                    i.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }
            }
        }

        /// <summary>
        /// Метод, обрабатывающий сброс выбора строки в таблице по клику на любое место формы, кроме самой таблицы.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dgvMainTable.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                dgvMainTable.ClearSelection();
            }
        }
    }
}
    
