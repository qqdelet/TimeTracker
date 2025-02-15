using System;
using System.Collections.Generic;
using System.ComponentModel; // ✅ Добавляем для BindingList
using System.Windows.Forms;
using System.Drawing;
using TimeTracker.Models;
using TimeTracker.Services;

namespace TimeTracker
{
    public partial class MainForm : Form
    {
        private readonly ProcessTracker _tracker;
        private readonly DatabaseService _dbService;
        private readonly System.Windows.Forms.Timer _refreshTimer;
        private readonly BindingSource _bindingSource; // ✅ Для сортировки
        private bool _autoUpdateEnabled = false; // ✅ Теперь храним в переменной
        private readonly ConfigService _configService;

        public MainForm()
        {
            InitializeComponent();
            _tracker = new ProcessTracker();
            _dbService = new DatabaseService();
            _bindingSource = new BindingSource();
            _configService = new ConfigService(); // ✅ Загружаем настройки

            _autoUpdateEnabled = _configService.AutoUpdate;
            _darkModeEnabled = _configService.DarkMode;

            // ✅ Создаём таймер перед вызовом UpdateAutoUpdateState()
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 5000;
            _refreshTimer.Tick += RefreshData;

            ApplyTheme();
            UpdateAutoUpdateState(); // ✅ Теперь _refreshTimer не null

            LoadProcessData(); // ✅ Загружаем данные при старте
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProcessData();
        }

        private void LoadProcessData()
        {
            List<ProcessUsage> data = _dbService.GetProcessUsages();

            if (data == null || data.Count == 0)
            {
                processGridView.DataSource = null; // ✅ Очищаем таблицу, если данных нет
                return;
            }

            _bindingSource.DataSource = new SortableBindingList<ProcessUsage>(data); // ✅ Убедимся, что сортировка работает
            processGridView.DataSource = _bindingSource; // ✅ Явно указываем источник данных

            foreach (DataGridViewColumn column in processGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic; // ✅ Включаем сортировку
            }

            processGridView.Refresh(); // ✅ Обновляем `DataGridView`
        }

        public void label1_Click(object sender, EventArgs e)
        {
        }

        private void RefreshData(object sender, EventArgs e)
        {
            if (lblStatus.Text == "Трекер: Работает" && _autoUpdateEnabled)
            {
                LoadProcessData();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _tracker.StartTracking();
            UpdateStatus(true);
            MessageBox.Show("Трекер запущен!");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _tracker.StopTracking();
            UpdateStatus(false);
            MessageBox.Show("Трекер остановлен!");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _refreshTimer.Stop();
        }

        private void UpdateStatus(bool isRunning)
        {
            lblStatus.Text = isRunning ? "Трекер: Работает" : "Трекер: Остановлен";
            lblStatus.ForeColor = isRunning ? Color.Green : Color.Red;
        }

        private Button btnSettings;

        private void UpdateAutoUpdateState()
        {
            if (_autoUpdateEnabled)
            {
                _refreshTimer.Start();
            }
            else
            {
                _refreshTimer.Stop();
            }
        }

        private bool _darkModeEnabled = false;

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm settings = new SettingsForm(_configService))
            {
                if (settings.ShowDialog() == DialogResult.OK)
                {
                    _autoUpdateEnabled = _configService.AutoUpdate;
                    _darkModeEnabled = _configService.DarkMode;

                    UpdateAutoUpdateState();
                    ApplyTheme();
                    LoadProcessData(); // ✅ Перезагружаем данные после изменения настроек
                }
            }
        }


        private void ApplyTheme()
        {
            if (_darkModeEnabled)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                this.ForeColor = Color.White;

                processGridView.BackgroundColor = Color.FromArgb(30, 30, 30);
                processGridView.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                processGridView.DefaultCellStyle.ForeColor = Color.White;

                // ✅ Делаем заголовки колонок тёмными
                processGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
                processGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                // ✅ Фиолетовые кнопки (147, 113, 200)
                Color purple = Color.FromArgb(147, 113, 200);
                btnStart.BackColor = purple;
                btnStop.BackColor = purple;
                btnSettings.BackColor = purple;

                btnStart.ForeColor = Color.White;
                btnStop.ForeColor = Color.White;
                btnSettings.ForeColor = Color.White;

                // ✅ Обводка кнопок белая
                btnStart.FlatStyle = FlatStyle.Flat;
                btnStop.FlatStyle = FlatStyle.Flat;
                btnSettings.FlatStyle = FlatStyle.Flat;

                btnStart.FlatAppearance.BorderColor = purple; // ✅ Граница того же цвета
                btnStop.FlatAppearance.BorderColor = purple;
                btnSettings.FlatAppearance.BorderColor = purple;

                btnStart.FlatAppearance.BorderSize = 1;
                btnStop.FlatAppearance.BorderSize = 1;
                btnSettings.FlatAppearance.BorderSize = 1;

                processGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40); // ✅ Тёмная тема

                processGridView.Cursor = Cursors.Hand; // ✅ Курсор "рука"

                processGridView.GridColor = Color.FromArgb(40, 40, 40); // Совпадает с фоном
                processGridView.BackgroundColor = Color.FromArgb(30, 30, 30);
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;

                processGridView.BackgroundColor = SystemColors.Window;
                processGridView.DefaultCellStyle.BackColor = SystemColors.Window;
                processGridView.DefaultCellStyle.ForeColor = SystemColors.ControlText;

                // ✅ Возвращаем стандартные цвета заголовков
                processGridView.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                processGridView.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;

                // ✅ Возвращаем кнопки в стандартное состояние
                btnStart.BackColor = SystemColors.Control;
                btnStop.BackColor = SystemColors.Control;
                btnSettings.BackColor = SystemColors.Control;

                btnStart.ForeColor = SystemColors.ControlText;
                btnStop.ForeColor = SystemColors.ControlText;
                btnSettings.ForeColor = SystemColors.ControlText;

                // ✅ Убираем кастомные бордеры
                btnStart.FlatStyle = FlatStyle.Standard;
                btnStop.FlatStyle = FlatStyle.Standard;
                btnSettings.FlatStyle = FlatStyle.Standard;
            
                processGridView.RowHeadersDefaultCellStyle.ForeColor = Color.White; // ✅ Белый текст

            }

            // ✅ Обновляем `DataGridView`, чтобы применились стили
            processGridView.EnableHeadersVisualStyles = false;
            processGridView.Refresh();
        }

        private void processGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
