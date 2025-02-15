namespace TimeTracker
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private CheckBox checkBoxAutoUpdate;
        private Button btnSave;
        private CheckBox autoUpdate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            checkBoxAutoUpdate = new CheckBox();
            btnSave = new Button();
            checkBoxDarkMode = new CheckBox();
            SuspendLayout();
            // 
            // checkBoxAutoUpdate
            // 
            checkBoxAutoUpdate.AutoSize = true;
            checkBoxAutoUpdate.Location = new Point(15, 20);
            checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            checkBoxAutoUpdate.Size = new Size(119, 19);
            checkBoxAutoUpdate.TabIndex = 0;
            checkBoxAutoUpdate.Text = "Автообновление";
            checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            checkBoxAutoUpdate.CheckedChanged += checkBoxAutoUpdate_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(10, 81);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // checkBoxDarkMode
            // 
            checkBoxDarkMode.AutoSize = true;
            checkBoxDarkMode.Location = new Point(15, 50);
            checkBoxDarkMode.Name = "checkBoxDarkMode";
            checkBoxDarkMode.Size = new Size(95, 19);
            checkBoxDarkMode.TabIndex = 2;
            checkBoxDarkMode.Text = "Тёмная тема";
            checkBoxDarkMode.UseVisualStyleBackColor = true;
            checkBoxDarkMode.CheckedChanged += checkBoxDarkMode_CheckedChanged;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(199, 116);
            Controls.Add(checkBoxAutoUpdate);
            Controls.Add(btnSave);
            Controls.Add(checkBoxDarkMode);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройки";
            ResumeLayout(false);
            PerformLayout();

        }
        private CheckBox checkBoxDarkMode;
    }
}
