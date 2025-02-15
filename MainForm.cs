using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeTracker.Models;
using TimeTracker.Services;


namespace TimeTracker
{
    public partial class MainForm : Form
    {
        private readonly ProcessTracker _tracker;
        private readonly DatabaseService _dbService;

        public MainForm()
        {
            InitializeComponent();
            _tracker = new ProcessTracker();
            _dbService = new DatabaseService();
            LoadProcessData();
        }

        private void LoadProcessData()
        {
            List<ProcessUsage> data = _dbService.GetProcessUsages();
            processGridView.DataSource = data;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _tracker.StartTracking();
            UpdateStatus(true); // ✅ Показываем, что трекер запущен
            MessageBox.Show("Трекер запущен!");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _tracker.StopTracking();
            UpdateStatus(false); // ✅ Показываем, что трекер остановлен
            MessageBox.Show("Трекер остановлен!");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProcessData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateStatus(bool isRunning)
        {
            if (isRunning)
            {
                lblStatus.Text = "Трекер: Работает";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Трекер: Остановлен";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
