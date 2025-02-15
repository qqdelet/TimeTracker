using System;
using System.Windows.Forms;
using TimeTracker.Services;

namespace TimeTracker
{
    public partial class SettingsForm : Form
    {
        public bool AutoUpdateEnabled { get; private set; }
        private readonly ConfigService _configService;

        public SettingsForm(ConfigService configService)
        {
            InitializeComponent();
            _configService = configService;

            checkBoxAutoUpdate.Checked = _configService.AutoUpdate;
            checkBoxDarkMode.Checked = _configService.DarkMode;
        }

        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            AutoUpdateEnabled = checkBoxAutoUpdate.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _configService.SaveSettings(checkBoxAutoUpdate.Checked, checkBoxDarkMode.Checked);
            DialogResult = DialogResult.OK;
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
