namespace Theatre
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            labelTheme = new Label();
            labelName = new Label();
            labelGroup = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelTheme
            // 
            labelTheme.AutoSize = true;
            labelTheme.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold);
            labelTheme.Location = new Point(212, 21);
            labelTheme.Name = "labelTheme";
            labelTheme.Size = new Size(309, 65);
            labelTheme.TabIndex = 0;
            labelTheme.Text = "ИС «Театр»";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold);
            labelName.Location = new Point(12, 111);
            labelName.Name = "labelName";
            labelName.Size = new Size(717, 65);
            labelName.TabIndex = 1;
            labelName.Text = "Выполнил: Костиневич А.В.";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold);
            labelGroup.Location = new Point(12, 195);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(386, 65);
            labelGroup.TabIndex = 2;
            labelGroup.Text = "Группа: 23ВП2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(124, 277);
            label1.Name = "label1";
            label1.Size = new Size(526, 19);
            label1.TabIndex = 3;
            label1.Text = "(Нажмите любую кнопку или подождите десять секунд, чтобы продолжить)";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(733, 316);
            Controls.Add(label1);
            Controls.Add(labelGroup);
            Controls.Add(labelName);
            Controls.Add(labelTheme);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ИС «Театр»";
            KeyDown += WelcomeForm_KeyDown;
            MouseDown += WelcomeForm_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTheme;
        private Label labelName;
        private Label labelGroup;
        private Label label1;
    }
}