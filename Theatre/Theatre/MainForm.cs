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
    /// �������, ��� ��������� ������� ��������� � ��������� �������.
    /// </summary>
    /// <param name="p">������, ������� ��� ��������/������.</param>
    public delegate void CollectionChanged(Performance p);
    
    /// <summary>
    /// ����� �������� ����� ����������.
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// ���������, �������� ������ � ��������������.
        /// </summary>
        private BindingList<Performance> performances;

        /// <summary>
        /// ������ ��� ����������� � ��.
        /// </summary>
        private string connection;

        /// <summary>
        /// ������� �������� ������ �� ���������.
        /// </summary>
        public event CollectionChanged ItemRemoved;

        /// <summary>
        /// ������� ���������� ������ � ���������.
        /// </summary>
        public event CollectionChanged ItemAdded;

        /// <summary>
        /// ���� ����������� ���������� (� ������/�������� ���������� �������).
        /// </summary>
        private bool reverseSort = false;

        /// <summary>
        /// ����������� �����.
        /// ����������� ������� ��� ����������� �������, ��������������� ���������, �������
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            performances = new BindingList<Performance>();
            cbFilter.SelectedIndex = 0;
            connection = "";
            bindingSource.DataSource = performances;
            dgvMainTable.DataSource = bindingSource;
            dgvMainTable.Columns["PerformanceName"].HeaderText = "�������� ���������";
            dgvMainTable.Columns["DirectorName"].HeaderText = "��� ���������";
            dgvMainTable.Columns["Genre"].HeaderText = "����";
            dgvMainTable.Columns["PremiereDate"].HeaderText = "���� ��������";
            dgvMainTable.Columns["Duration"].HeaderText = "������������";
            dgvMainTable.Columns["TicketCost"].HeaderText = "��������� ������";
            dgvMainTable.Columns["Id"].Visible = false;
            dgvMainTable.Columns["PremiereDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvMainTable.Columns["Duration"].DefaultCellStyle.Format = @"hh\:mm\:ss";
            dgvMainTable.Columns["TicketCost"].DefaultCellStyle.Format = "F2";
            dgvMainTable.RowHeadersWidth = 25;
            ItemAdded += (p => { });
            ItemRemoved += (p => { });
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� �������� ����� ��.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "�� ������";
            connection = "";
            bindingSource.DataSource = performances;
            performances.Clear();
            labelCount.Text = "���������� 0 �� 0 �������";
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� �������� ��������� ����� ��.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SQLite Database Files (*.db)|*.db",
                Title = "�������� ���� ���� ������",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindingSource.DataSource = performances;
                connection = $"Data Source={openFileDialog.FileName}";
                Text = $"�� ������ - {connection.Replace("Data Source=", "")}";
                using (DatabaseContext context = new DatabaseContext(connection))
                {
                    performances.Clear();
                    foreach (Performance p in context.Performances.ToList())
                    {
                        performances.Add(p);
                    }
                }
                labelCount.Text = $"���������� {performances.Count} �� {performances.Count} �������";
            }
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� ���������� ������� � ���� ��.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
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
        /// �����, �������������� ������� ������ ��� ���������� ������� � ����� ���� ��.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabaseAs();
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� ���������� ����� ������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
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
                    labelCount.Text = $"���������� {(bindingSource.DataSource as BindingList<Performance>).Count} �� {performances.Count} �������";
                }
            }
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� ��������� ������������ ������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
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
                MessageBox.Show("�������� ���� ������ ��� ���������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� �������� ������������ ������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void RemoveRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current == null)
            {
                MessageBox.Show("������� �������� ������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Performance performance = bindingSource.Current as Performance;
            ItemRemoved.Invoke(performance);
            performances.Remove(performance);
            labelCount.Text = $"���������� {(bindingSource.DataSource as BindingList<Performance>).Count} �� {performances.Count} �������";
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� �������� ���� �������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (performances.Count == 0)
            {
                MessageBox.Show("���� ������ �����", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bindingSource.DataSource = performances;
            performances.Clear();
            labelCount.Text = "���������� 0 �� 0 �������";
        }

        /// <summary>
        /// �����, ����������� ������ � ����� ���� ��.
        /// </summary>
        private void SaveDatabaseAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "SQLite Database Files (*.db)|*.db",
                Title = "��������� ���",
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                connection = $"Data Source={saveFileDialog.FileName}";
                Text = $"�� ������ - {connection.Replace("Data Source=", "")}";
                using (DatabaseContext context = new DatabaseContext(connection))
                {
                    context.Database.EnsureCreated();
                    context.Performances.AddRange(performances);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// �����, �������������� ��������� ������ ��� ���������� �������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (tbFilterValue.Text == "")
            {
                labelCount.Text = $"���������� {performances.Count} �� {performances.Count} �������";
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
        /// �����, ����������� ������ �� ��������� ��������.
        /// </summary>
        /// <param name="selector">�������, ������������ ��������� �������� �� ������� Performance</param>
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
            labelCount.Text = $"���������� {tmp.Count} �� {performances.Count} �������";
        }

        /// <summary>
        /// �����, �������������� ������� ������ ��� ���������� �������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
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
        /// �����, �������������� ������� ������ ��� ���������� ������� � �������� � PDF-����.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void CreatePdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF ����� (*.pdf)|*.pdf",
                Title = "��������� ����� �� ������� ������",
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
        /// �����, �������������� ��������� ������ ��� ������ �������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
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
        /// �����, ����������� ������ �� ��������/����������� (��������) (� ����������� �� ��������).
        /// </summary>
        /// <typeparam name="T">��� ��������, �� �������� ������������ ����������.</typeparam>
        /// <param name="selector">�������, ������������ ���� �������, �� �������� ������������ ����������.</param>
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
        /// �����, ����������� ����� ������� �� ��������.
        /// </summary>
        /// <param name="selector">�������, ������������ ��������, �� �������� ������������ �����.</param>
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
        /// �����, �������������� ����� ������ ������ � ������� �� ����� �� ����� ����� �����, ����� ����� �������.
        /// </summary>
        /// <param name="sender">�������� �������</param>
        /// <param name="e">��������� ������� �������</param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dgvMainTable.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                dgvMainTable.ClearSelection();
            }
        }
    }
}
    
