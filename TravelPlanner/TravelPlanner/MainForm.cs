using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace TravelPlanner
{
    public partial class MainForm : Form
    {
        private List<Trip> trips;
        private Trip currentTrip;
        private NotifyIcon notifyIcon1;
        private readonly string saveFilePath = "trips.json";

        public MainForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            LoadData();
            UpdateTripsList();
            UpdateButtonsState();
            this.FormClosing += MainForm_FormClosing;
        }

        private void InitializeNotifyIcon()
        {
            this.notifyIcon1 = new NotifyIcon();
            this.notifyIcon1.Icon = SystemIcons.Information;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipTitle = "Планировщик путешествий";
        }

        private void SaveData()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = false
                };

                string jsonString = JsonSerializer.Serialize(trips, options);
                File.WriteAllText(saveFilePath, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            if (File.Exists(saveFilePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(saveFilePath);
                    var loadedTrips = JsonSerializer.Deserialize<List<Trip>>(jsonString);
                    if (loadedTrips != null)
                    {
                        trips = loadedTrips;
                    }
                    else
                    {
                        trips = new List<Trip>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trips = new List<Trip>();
                }
            }
            else
            {
                trips = new List<Trip>();
            }
        }

        private void UpdateTripsList()
        {
            tripsListBox.Items.Clear();
            if (trips.Any())
            {
                foreach (var trip in trips)
                {
                    tripsListBox.Items.Add($"{trip.Destination} ({trip.StartDate:dd.MM.yyyy} - {trip.EndDate:dd.MM.yyyy}) | Остаток: {trip.RemainingBudget():C}");
                }
            }
            else
            {
                tripsListBox.Items.Add("Нет созданных поездок");
            }
        }

        private void UpdateExpensesList()
        {
            expensesListBox.Items.Clear();
            if (currentTrip != null && currentTrip.Expenses.Any())
            {
                foreach (var expense in currentTrip.Expenses)
                {
                    expensesListBox.Items.Add(expense.ToString());
                }
            }
            else
            {
                expensesListBox.Items.Add("Нет добавленных расходов");
            }
        }

        private void UpdateTripInfo()
        {
            if (currentTrip != null)
            {
                tripInfoLabel.Text = $"Текущая поездка: {currentTrip.Destination}\n" +
                    $"Период: {currentTrip.StartDate:dd.MM.yyyy} - {currentTrip.EndDate:dd.MM.yyyy}\n" +
                    $"Бюджет: {currentTrip.Budget:C} | Расходы: {currentTrip.CalculateTotalExpenses():C} | Остаток: {currentTrip.RemainingBudget():C}";

                tripInfoLabel.ForeColor = currentTrip.RemainingBudget() >= 0 ?
                    System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
            else
            {
                tripInfoLabel.Text = "Выберите поездку или создайте новую";
                tripInfoLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void UpdateButtonsState()
        {
            bool hasTrips = trips.Any();
            bool hasSelectedTrip = currentTrip != null;

            selectTripButton.Enabled = hasTrips;
            editTripButton.Enabled = hasSelectedTrip;
            deleteTripButton.Enabled = hasSelectedTrip;
            addExpenseButton.Enabled = hasSelectedTrip;
            editExpenseButton.Enabled = hasSelectedTrip && expensesListBox.SelectedItem != null && currentTrip != null && currentTrip.Expenses.Any();
            deleteExpenseButton.Enabled = hasSelectedTrip && expensesListBox.SelectedItem != null && currentTrip != null && currentTrip.Expenses.Any();
            displayDetailsButton.Enabled = hasSelectedTrip;

            if (manageTasksButton != null)
                manageTasksButton.Enabled = hasSelectedTrip;
        }

        private void CreateTripButton_Click(object sender, EventArgs e)
        {
            var createForm = new CreateTripForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                var newTrip = new Trip(
                    createForm.Destination,
                    createForm.StartDate,
                    createForm.EndDate,
                    createForm.Budget
                );
                trips.Add(newTrip);
                SaveData();
                UpdateTripsList();

                currentTrip = newTrip;
                UpdateExpensesList();
                UpdateTripInfo();
                UpdateButtonsState();

                int index = trips.IndexOf(newTrip);
                if (index >= 0) tripsListBox.SelectedIndex = index;
            }
        }

        private void SelectTripButton_Click(object sender, EventArgs e)
        {
            if (tripsListBox.SelectedIndex >= 0 && tripsListBox.SelectedIndex < trips.Count)
            {
                currentTrip = trips[tripsListBox.SelectedIndex];
                UpdateExpensesList();
                UpdateTripInfo();
                UpdateButtonsState();
                UpdateTasksNotification();
            }
            else
            {
                MessageBox.Show("Выберите поездку из списка.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditTripButton_Click(object sender, EventArgs e)
        {
            if (currentTrip == null) return;

            var editForm = new CreateTripForm(
                currentTrip.Destination,
                currentTrip.StartDate,
                currentTrip.EndDate,
                currentTrip.Budget
            );

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                currentTrip.Destination = editForm.Destination;
                currentTrip.StartDate = editForm.StartDate;
                currentTrip.EndDate = editForm.EndDate;
                currentTrip.Budget = editForm.Budget;

                SaveData();
                UpdateTripsList();
                UpdateTripInfo();
                UpdateButtonsState();

                int index = trips.IndexOf(currentTrip);
                if (index >= 0) tripsListBox.SelectedIndex = index;

                MessageBox.Show("Поездка успешно обновлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteTripButton_Click(object sender, EventArgs e)
        {
            if (currentTrip == null) return;

            var result = MessageBox.Show($"Вы действительно хотите удалить поездку в {currentTrip.Destination}?\nВсе расходы и задачи также будут удалены.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                trips.Remove(currentTrip);
                SaveData();
                currentTrip = trips.FirstOrDefault();

                UpdateTripsList();
                UpdateExpensesList();
                UpdateTripInfo();
                UpdateButtonsState();

                if (currentTrip != null)
                {
                    int index = trips.IndexOf(currentTrip);
                    if (index >= 0) tripsListBox.SelectedIndex = index;
                }
            }
        }

        private void AddExpenseButton_Click(object sender, EventArgs e)
        {
            if (currentTrip == null) return;

            var addExpenseForm = new AddExpenseForm();
            if (addExpenseForm.ShowDialog() == DialogResult.OK)
            {
                var expense = new Expense(addExpenseForm.Description, addExpenseForm.Amount);
                currentTrip.AddExpense(expense);
                SaveData();
                UpdateExpensesList();
                UpdateTripInfo();
                UpdateButtonsState();
            }
        }

        private void EditExpenseButton_Click(object sender, EventArgs e)
        {
            if (currentTrip == null || expensesListBox.SelectedIndex < 0) return;

            int selectedIndex = expensesListBox.SelectedIndex;
            var selectedExpense = currentTrip.Expenses[selectedIndex];

            var editForm = new AddExpenseForm(selectedExpense.Description, selectedExpense.Amount);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedExpense.Description = editForm.Description;
                selectedExpense.Amount = editForm.Amount;
                SaveData();
                UpdateExpensesList();
                UpdateTripInfo();
                UpdateButtonsState();
            }
        }

        private void DeleteExpenseButton_Click(object sender, EventArgs e)
        {
            if (currentTrip == null || expensesListBox.SelectedIndex < 0) return;

            var result = MessageBox.Show("Вы действительно хотите удалить этот расход?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int selectedIndex = expensesListBox.SelectedIndex;
                currentTrip.Expenses.RemoveAt(selectedIndex);
                SaveData();
                UpdateExpensesList();
                UpdateTripInfo();
                UpdateButtonsState();
                MessageBox.Show("Расход успешно удален!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayDetailsButton_Click(object sender, EventArgs e)
        {
            if (currentTrip == null) return;

            var reportForm = new TripReportForm(currentTrip);
            reportForm.ShowDialog();
            SaveData();
            UpdateExpensesList();
            UpdateTripInfo();
            UpdateButtonsState();
        }

        private void ManageTasksButton_Click(object sender, EventArgs e)
        {
            if (currentTrip == null)
            {
                MessageBox.Show("Сначала выберите поездку!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tasksForm = new TripTasksForm(currentTrip);
            tasksForm.ShowDialog();
            SaveData();
            UpdateTasksNotification();
        }

        private void UpdateTasksNotification()
        {
            if (currentTrip != null && notifyIcon1 != null)
            {
                var upcomingTasks = currentTrip.GetUpcomingTasks(7);
                var overdueTasks = currentTrip.GetOverdueTasks();

                if (overdueTasks.Any())
                {
                    notifyIcon1.BalloonTipText = $"У вас {overdueTasks.Count} просроченных задач!";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon1.ShowBalloonTip(5000);
                }
                else if (upcomingTasks.Any())
                {
                    notifyIcon1.BalloonTipText = $"У вас {upcomingTasks.Count} задач на ближайшие 7 дней!";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(3000);
                }
            }
        }

        private void TripsListBox_DoubleClick(object sender, EventArgs e)
        {
            SelectTripButton_Click(sender, e);
        }

        private void ExpensesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }
    }
}