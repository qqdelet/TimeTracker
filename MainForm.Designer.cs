namespace TimeTracker
{
    partial class MainForm
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
            processGridView = new DataGridView();
            btnStart = new Button();
            btnStop = new Button();
            lblStatus = new Label();
            btnSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)processGridView).BeginInit();
            SuspendLayout();
            // 
            // processGridView
            // 
            processGridView.AllowDrop = true;
            processGridView.AllowUserToOrderColumns = true;
            processGridView.Location = new Point(1, 0);
            processGridView.Name = "processGridView";
            processGridView.Size = new Size(746, 368);
            processGridView.StandardTab = true;
            processGridView.TabIndex = 0;
            processGridView.CellContentClick += processGridView_CellContentClick;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(753, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(117, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(753, 41);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(117, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Стоп";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(753, 353);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(117, 15);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Трекер: Остановлен";
            lblStatus.Click += label1_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(753, 70);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(117, 23);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Настройки";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 380);
            Controls.Add(lblStatus);
            Controls.Add(processGridView);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Controls.Add(btnSettings);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            ShowInTaskbar = false;
            Text = "Time Tracker";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)processGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DataGridView processGridView;
        private Button btnStart;
        private Button btnStop;
        private Label lblStatus;

    }
}