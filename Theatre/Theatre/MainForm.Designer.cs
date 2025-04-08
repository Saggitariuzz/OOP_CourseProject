namespace Theatre
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            msMenuMain = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            CreateToolStripMenuItem = new ToolStripMenuItem();
            LoadToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            SaveAsToolStripMenuItem = new ToolStripMenuItem();
            CreatePdfToolStripMenuItem = new ToolStripMenuItem();
            ChangeToolStripMenuItem = new ToolStripMenuItem();
            AddRecordToolStripMenuItem = new ToolStripMenuItem();
            ChangeRecordToolStripMenuItem = new ToolStripMenuItem();
            RemoveRecordToolStripMenuItem = new ToolStripMenuItem();
            ClearToolStripMenuItem = new ToolStripMenuItem();
            dgvMainTable = new DataGridView();
            bindingSource = new BindingSource(components);
            labelFIlter = new Label();
            labelValue = new Label();
            tbFilterValue = new TextBox();
            cbFilter = new ComboBox();
            btnSort = new Button();
            labelSearch = new Label();
            tbSearch = new TextBox();
            labelCount = new Label();
            msMenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            SuspendLayout();
            // 
            // msMenuMain
            // 
            msMenuMain.ImageScalingSize = new Size(24, 24);
            msMenuMain.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, ChangeToolStripMenuItem });
            msMenuMain.Location = new Point(0, 0);
            msMenuMain.Name = "msMenuMain";
            msMenuMain.Size = new Size(1320, 33);
            msMenuMain.TabIndex = 0;
            msMenuMain.Text = "Файл";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateToolStripMenuItem, LoadToolStripMenuItem, SaveToolStripMenuItem, SaveAsToolStripMenuItem, CreatePdfToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(69, 29);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // CreateToolStripMenuItem
            // 
            CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            CreateToolStripMenuItem.Size = new Size(401, 34);
            CreateToolStripMenuItem.Text = "Создать";
            CreateToolStripMenuItem.Click += CreateToolStripMenuItem_Click;
            // 
            // LoadToolStripMenuItem
            // 
            LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            LoadToolStripMenuItem.Size = new Size(401, 34);
            LoadToolStripMenuItem.Text = "Загрузить";
            LoadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.Size = new Size(401, 34);
            SaveToolStripMenuItem.Text = "Сохранить";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // SaveAsToolStripMenuItem
            // 
            SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            SaveAsToolStripMenuItem.Size = new Size(401, 34);
            SaveAsToolStripMenuItem.Text = "Сохранить как";
            SaveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // CreatePdfToolStripMenuItem
            // 
            CreatePdfToolStripMenuItem.Name = "CreatePdfToolStripMenuItem";
            CreatePdfToolStripMenuItem.Size = new Size(401, 34);
            CreatePdfToolStripMenuItem.Text = "Создать отчет по текущим данным";
            CreatePdfToolStripMenuItem.Click += CreatePdfToolStripMenuItem_Click;
            // 
            // ChangeToolStripMenuItem
            // 
            ChangeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddRecordToolStripMenuItem, ChangeRecordToolStripMenuItem, RemoveRecordToolStripMenuItem, ClearToolStripMenuItem });
            ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem";
            ChangeToolStripMenuItem.Size = new Size(107, 29);
            ChangeToolStripMenuItem.Text = "Изменить";
            // 
            // AddRecordToolStripMenuItem
            // 
            AddRecordToolStripMenuItem.Name = "AddRecordToolStripMenuItem";
            AddRecordToolStripMenuItem.Size = new Size(295, 34);
            AddRecordToolStripMenuItem.Text = "Добавить запись";
            AddRecordToolStripMenuItem.Click += AddRecordToolStripMenuItem_Click;
            // 
            // ChangeRecordToolStripMenuItem
            // 
            ChangeRecordToolStripMenuItem.Name = "ChangeRecordToolStripMenuItem";
            ChangeRecordToolStripMenuItem.Size = new Size(295, 34);
            ChangeRecordToolStripMenuItem.Text = "Изменить запись";
            ChangeRecordToolStripMenuItem.Click += ChangeRecordToolStripMenuItem_Click;
            // 
            // RemoveRecordToolStripMenuItem
            // 
            RemoveRecordToolStripMenuItem.Name = "RemoveRecordToolStripMenuItem";
            RemoveRecordToolStripMenuItem.Size = new Size(295, 34);
            RemoveRecordToolStripMenuItem.Text = "Удалить запись";
            RemoveRecordToolStripMenuItem.Click += RemoveRecordToolStripMenuItem_Click;
            // 
            // ClearToolStripMenuItem
            // 
            ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            ClearToolStripMenuItem.Size = new Size(295, 34);
            ClearToolStripMenuItem.Text = "Очистить базу данных";
            ClearToolStripMenuItem.Click += ClearToolStripMenuItem_Click;
            // 
            // dgvMainTable
            // 
            dgvMainTable.AllowUserToAddRows = false;
            dgvMainTable.AllowUserToDeleteRows = false;
            dgvMainTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMainTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMainTable.BackgroundColor = SystemColors.ButtonFace;
            dgvMainTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMainTable.DefaultCellStyle = dataGridViewCellStyle1;
            dgvMainTable.Location = new Point(12, 133);
            dgvMainTable.MultiSelect = false;
            dgvMainTable.Name = "dgvMainTable";
            dgvMainTable.ReadOnly = true;
            dgvMainTable.RowHeadersWidth = 62;
            dgvMainTable.Size = new Size(1298, 286);
            dgvMainTable.TabIndex = 1;
            // 
            // labelFIlter
            // 
            labelFIlter.AutoSize = true;
            labelFIlter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelFIlter.Location = new Point(12, 55);
            labelFIlter.Name = "labelFIlter";
            labelFIlter.Size = new Size(121, 32);
            labelFIlter.TabIndex = 2;
            labelFIlter.Text = "Критерий";
            // 
            // labelValue
            // 
            labelValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelValue.AutoSize = true;
            labelValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelValue.Location = new Point(391, 55);
            labelValue.Name = "labelValue";
            labelValue.Size = new Size(94, 32);
            labelValue.TabIndex = 4;
            labelValue.Text = "Фильтр";
            // 
            // tbFilterValue
            // 
            tbFilterValue.Location = new Point(489, 55);
            tbFilterValue.Name = "tbFilterValue";
            tbFilterValue.Size = new Size(252, 31);
            tbFilterValue.TabIndex = 5;
            tbFilterValue.TextChanged += tbFilterValue_TextChanged;
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.FormattingEnabled = true;
            cbFilter.Items.AddRange(new object[] { "Название спектакля", "Имя режиссера", "Жанр", "Дата премьеры", "Длительность", "Стоимость билета" });
            cbFilter.Location = new Point(139, 55);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(240, 33);
            cbFilter.TabIndex = 6;
            // 
            // btnSort
            // 
            btnSort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSort.Location = new Point(1136, 54);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(172, 34);
            btnSort.TabIndex = 7;
            btnSort.Text = "Сортировать";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // labelSearch
            // 
            labelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSearch.Location = new Point(757, 56);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(82, 32);
            labelSearch.TabIndex = 8;
            labelSearch.Text = "Поиск";
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(845, 57);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(252, 31);
            tbSearch.TabIndex = 9;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(12, 99);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(239, 25);
            labelCount.TabIndex = 10;
            labelCount.Text = "Отображено 0 из 0 записей";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 431);
            Controls.Add(labelCount);
            Controls.Add(tbSearch);
            Controls.Add(labelSearch);
            Controls.Add(btnSort);
            Controls.Add(cbFilter);
            Controls.Add(tbFilterValue);
            Controls.Add(labelValue);
            Controls.Add(labelFIlter);
            Controls.Add(dgvMainTable);
            Controls.Add(msMenuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMenuMain;
            MinimumSize = new Size(1342, 487);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ИС «Театр»";
            msMenuMain.ResumeLayout(false);
            msMenuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
            MouseDown += MainForm_MouseDown;
        }

        #endregion

        private MenuStrip msMenuMain;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem CreateToolStripMenuItem;
        private ToolStripMenuItem LoadToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem SaveAsToolStripMenuItem;
        private ToolStripMenuItem ChangeToolStripMenuItem;
        private ToolStripMenuItem AddRecordToolStripMenuItem;
        private ToolStripMenuItem ChangeRecordToolStripMenuItem;
        private ToolStripMenuItem RemoveRecordToolStripMenuItem;
        private ToolStripMenuItem ClearToolStripMenuItem;
        private DataGridView dgvMainTable;
        private BindingSource bindingSource;
        private Label labelFIlter;
        private Label labelValue;
        private TextBox tbFilterValue;
        private ComboBox cbFilter;
        private Button btnSort;
        private ToolStripMenuItem CreatePdfToolStripMenuItem;
        private Label labelSearch;
        private TextBox tbSearch;
        private Label labelCount;
    }
}
