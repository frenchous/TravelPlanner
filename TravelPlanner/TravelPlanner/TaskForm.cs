using System;
using System.Windows.Forms;

namespace TravelPlanner
{
    public partial class TaskForm : Form
    {
        public string TaskTitle { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime TaskDueDate { get; private set; }
        public int ReminderDays { get; private set; }
        private bool isEditMode;

        public TaskForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Создание задачи";
        }

        public TaskForm(TripTask task)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "Редактирование задачи";
            titleTextBox.Text = task.Title;
            descriptionTextBox.Text = task.Description;
            dueDatePicker.Value = task.DueDate;
            reminderNumericUpDown.Value = task.ReminderDaysBefore;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (dueDatePicker.Value < DateTime.Now.Date)
            {
                MessageBox.Show("Дедлайн не может быть в прошлом!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            TaskTitle = titleTextBox.Text;
            TaskDescription = descriptionTextBox.Text;
            TaskDueDate = dueDatePicker.Value;
            ReminderDays = (int)reminderNumericUpDown.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}