namespace Theatre
{
    partial class PerformanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceForm));
            labelNameOfPerformance = new Label();
            tbNameOfPerformance = new TextBox();
            labelDirectorName = new Label();
            tbDirectorName = new TextBox();
            labelGenre = new Label();
            cbGenre = new ComboBox();
            labelPremiereDate = new Label();
            dtpPremiereDate = new DateTimePicker();
            labelDuration = new Label();
            dtpDuration = new DateTimePicker();
            labelTicketCost = new Label();
            nudTicketCost = new NumericUpDown();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)nudTicketCost).BeginInit();
            SuspendLayout();
            // 
            // labelNameOfPerformance
            // 
            labelNameOfPerformance.AutoSize = true;
            labelNameOfPerformance.Location = new Point(12, 23);
            labelNameOfPerformance.Name = "labelNameOfPerformance";
            labelNameOfPerformance.Size = new Size(174, 25);
            labelNameOfPerformance.TabIndex = 0;
            labelNameOfPerformance.Text = "Название спектакля";
            // 
            // tbNameOfPerformance
            // 
            tbNameOfPerformance.Location = new Point(209, 20);
            tbNameOfPerformance.Name = "tbNameOfPerformance";
            tbNameOfPerformance.Size = new Size(303, 31);
            tbNameOfPerformance.TabIndex = 1;
            // 
            // labelDirectorName
            // 
            labelDirectorName.AutoSize = true;
            labelDirectorName.Location = new Point(12, 75);
            labelDirectorName.Name = "labelDirectorName";
            labelDirectorName.Size = new Size(140, 25);
            labelDirectorName.TabIndex = 2;
            labelDirectorName.Text = "Имя режиссера";
            // 
            // tbDirectorName
            // 
            tbDirectorName.Location = new Point(209, 72);
            tbDirectorName.Name = "tbDirectorName";
            tbDirectorName.Size = new Size(303, 31);
            tbDirectorName.TabIndex = 3;
            // 
            // labelGenre
            // 
            labelGenre.AutoSize = true;
            labelGenre.Location = new Point(12, 124);
            labelGenre.Name = "labelGenre";
            labelGenre.Size = new Size(58, 25);
            labelGenre.TabIndex = 4;
            labelGenre.Text = "Жанр";
            // 
            // cbGenre
            // 
            cbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenre.FormattingEnabled = true;
            cbGenre.Items.AddRange(new object[] { "Драма", "Трагедия", "Комедия", "Трагикомедия", "Фарс", "Мелодрама", "Мюзикл", "Опера", "Оперетта", "Балет" });
            cbGenre.Location = new Point(209, 124);
            cbGenre.MaxDropDownItems = 4;
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(303, 33);
            cbGenre.TabIndex = 5;
            // 
            // labelPremiereDate
            // 
            labelPremiereDate.AutoSize = true;
            labelPremiereDate.Location = new Point(12, 180);
            labelPremiereDate.Name = "labelPremiereDate";
            labelPremiereDate.Size = new Size(139, 25);
            labelPremiereDate.TabIndex = 6;
            labelPremiereDate.Text = "Дата премьеры";
            // 
            // dtpPremiereDate
            // 
            dtpPremiereDate.Location = new Point(209, 175);
            dtpPremiereDate.Name = "dtpPremiereDate";
            dtpPremiereDate.Size = new Size(300, 31);
            dtpPremiereDate.TabIndex = 7;
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(12, 233);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(179, 25);
            labelDuration.TabIndex = 8;
            labelDuration.Text = "Продолжительность";
            // 
            // dtpDuration
            // 
            dtpDuration.Format = DateTimePickerFormat.Time;
            dtpDuration.Location = new Point(209, 233);
            dtpDuration.Name = "dtpDuration";
            dtpDuration.ShowUpDown = true;
            dtpDuration.Size = new Size(300, 31);
            dtpDuration.TabIndex = 9;
            // 
            // labelTicketCost
            // 
            labelTicketCost.AutoSize = true;
            labelTicketCost.Location = new Point(12, 285);
            labelTicketCost.Name = "labelTicketCost";
            labelTicketCost.Size = new Size(158, 25);
            labelTicketCost.TabIndex = 10;
            labelTicketCost.Text = "Стоимость билета";
            // 
            // nudTicketCost
            // 
            nudTicketCost.DecimalPlaces = 2;
            nudTicketCost.Location = new Point(209, 285);
            nudTicketCost.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudTicketCost.Name = "nudTicketCost";
            nudTicketCost.Size = new Size(300, 31);
            nudTicketCost.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(181, 339);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(153, 34);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // PerformanceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 396);
            Controls.Add(btnAdd);
            Controls.Add(nudTicketCost);
            Controls.Add(labelTicketCost);
            Controls.Add(dtpDuration);
            Controls.Add(labelDuration);
            Controls.Add(dtpPremiereDate);
            Controls.Add(labelPremiereDate);
            Controls.Add(cbGenre);
            Controls.Add(labelGenre);
            Controls.Add(tbDirectorName);
            Controls.Add(labelDirectorName);
            Controls.Add(tbNameOfPerformance);
            Controls.Add(labelNameOfPerformance);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerformanceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление записи";
            ((System.ComponentModel.ISupportInitialize)nudTicketCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNameOfPerformance;
        private TextBox tbNameOfPerformance;
        private Label labelDirectorName;
        private TextBox tbDirectorName;
        private Label labelGenre;
        private ComboBox cbGenre;
        private Label labelPremiereDate;
        private DateTimePicker dtpPremiereDate;
        private Label labelDuration;
        private DateTimePicker dtpDuration;
        private Label labelTicketCost;
        private NumericUpDown nudTicketCost;
        private Button btnAdd;
    }
}