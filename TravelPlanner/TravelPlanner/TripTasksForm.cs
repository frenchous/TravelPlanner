using System;
using System.Linq;
using System.Windows.Forms;

namespace TravelPlanner
{
    public partial class TripTasksForm : Form
    {
        private Trip trip;

        public TripTasksForm(Trip trip)
        {
            this.trip = trip;
            InitializeComponent();
            this.Text = $"Задачи для поездки: {trip.Destination}";
            LoadTasks();
            CheckNotifications();
        }

        private void LoadTasks()
        {
            tasksListBox.Items.Clear();
            if (trip.Tasks.Any())
            {
                foreach (var task in trip.Tasks)
                {
                    tasksListBox.Items.Add(task);
                }
            }
            else
            {
                tasksListBox.Items.Add("Нет созданных задач");
            }
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            bool hasSelection = tasksListBox.SelectedIndex >= 0 &&
                               tasksListBox.SelectedIndex < trip.Tasks.Count;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;

            if (hasSelection && tasksListBox.SelectedIndex < trip.Tasks.Count)
            {
                completeButton.Enabled = !trip.Tasks[tasksListBox.SelectedIndex].IsCompleted;
            }
            else
            {
                completeButton.Enabled = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var taskForm = new TaskForm();
            if (taskForm.ShowDialog() == DialogResult.OK)
            {
                var newTask = new TripTask(taskForm.TaskTitle, taskForm.TaskDescription,
                    taskForm.TaskDueDate, taskForm.ReminderDays);
                trip.AddTask(newTask);
                LoadTasks();
                CheckDeadlineWarnings();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedIndex < 0 || tasksListBox.SelectedIndex >= trip.Tasks.Count)
                return;

            var selectedTask = trip.Tasks[tasksListBox.SelectedIndex];
            var taskForm = new TaskForm(selectedTask);

            if (taskForm.ShowDialog() == DialogResult.OK)
            {
                selectedTask.Title = taskForm.TaskTitle;
                selectedTask.Description = taskForm.TaskDescription;
                selectedTask.DueDate = taskForm.TaskDueDate;
                selectedTask.ReminderDaysBefore = taskForm.ReminderDays;
                LoadTasks();
                MessageBox.Show("Задача успешно обновлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedIndex < 0 || tasksListBox.SelectedIndex >= trip.Tasks.Count)
                return;

            var selectedTask = trip.Tasks[tasksListBox.SelectedIndex];
            selectedTask.IsCompleted = true;
            LoadTasks();

            MessageBox.Show($"Задача \"{selectedTask.Title}\" отмечена как выполненная!",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedIndex < 0 || tasksListBox.SelectedIndex >= trip.Tasks.Count)
                return;

            var result = MessageBox.Show("Вы действительно хотите удалить эту задачу?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                trip.Tasks.RemoveAt(tasksListBox.SelectedIndex);
                LoadTasks();
                MessageBox.Show("Задача успешно удалена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckNotifications()
        {
            var overdue = trip.GetOverdueTasks();
            var upcoming = trip.GetUpcomingTasks(3);

            if (overdue.Any())
            {
                MessageBox.Show($"Внимание! У вас {overdue.Count} просроченных задач!\n\n" +
                    string.Join("\n", overdue.Select(t => $"• {t.Title} - {t.Description}")),
                    "Просроченные задачи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (upcoming.Any())
            {
                MessageBox.Show($"У вас {upcoming.Count} задач на ближайшие 3 дня!\n\n" +
                    string.Join("\n", upcoming.Select(t => $"• {t.Title} - до {t.DueDate:dd.MM.yyyy}")),
                    "Напоминание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckDeadlineWarnings()
        {
            var tasksNearDeadline = trip.Tasks.Where(t => !t.IsCompleted &&
                t.DueDate <= DateTime.Now.AddDays(1) && t.DueDate >= DateTime.Now.Date).ToList();

            foreach (var task in tasksNearDeadline)
            {
                MessageBox.Show($"Задача \"{task.Title}\" должна быть выполнена сегодня!\n\n" +
                    $"Описание: {task.Description}",
                    "Срочное уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TasksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}