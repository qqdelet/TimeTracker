using System;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class SettingsForm : Form
    {
        public bool AutoUpdateEnabled { get; private set; }

        public SettingsForm(bool autoUpdateState)
        {
            InitializeComponent();
            checkBoxAutoUpdate.Checked = autoUpdateState;
        }

        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            AutoUpdateEnabled = checkBoxAutoUpdate.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK; // Закрываем форму и сохраняем состояние
            Close();
        }
        public bool DarkModeEnabled { get; private set; }

        public SettingsForm(bool autoUpdateState, bool darkModeState)
        {
            InitializeComponent();
            checkBoxAutoUpdate.Checked = autoUpdateState;
            checkBoxDarkMode.Checked = darkModeState; // ✅ Загружаем состояние темы
        }
        private void checkBoxDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            DarkModeEnabled = checkBoxDarkMode.Checked;
        }

    }
}
