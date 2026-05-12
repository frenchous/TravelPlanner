using System;
using System.Linq;
using System.Windows.Forms;

namespace TravelPlanner
{
    public partial class TripReportForm : Form
    {
        private Trip trip;
        private Button editButton;
        private Button deleteButton;

        public TripReportForm(Trip trip)
        {
            this.trip = trip;
            InitializeComponent();
            LoadReportData();
        }

        private void LoadReportData()
        {
            // Заголовок отчета
            titleLabel.Text = $"Отчет о поездке в {trip.Destination}";

            // Информация о поездке
            startDateLabel.Text = $"Дата начала: {trip.StartDate:dd.MM.yyyy}";
            endDateLabel.Text = $"Дата окончания: {trip.EndDate:dd.MM.yyyy}";
            budgetLabel.Text = $"Бюджет: {trip.Budget:C}";

            // Финансовая информация
            decimal totalExpenses = trip.CalculateTotalExpenses();
            decimal remainingBudget = trip.RemainingBudget();

            totalExpensesLabel.Text = $"Всего расходов: {totalExpenses:C}";
            remainingBudgetLabel.Text = $"Оставшийся бюджет: {remainingBudget:C}";
            remainingBudgetLabel.ForeColor = remainingBudget >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            // Список расходов
            UpdateExpensesList();
        }

        private void UpdateExpensesList()
        {
            expensesListBox.Items.Clear();
            if (trip.Expenses.Any())
            {
                for (int i = 0; i < trip.Expenses.Count; i++)
                {
                    expensesListBox.Items.Add($"{i + 1}. {trip.Expenses[i].ToString()}");
                }
            }
            else
            {
                expensesListBox.Items.Add("Нет добавленных расходов");
            }
        }

        private void EditExpenseButton_Click(object sender, EventArgs e)
        {
            if (expensesListBox.SelectedItem == null || expensesListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите расход для редактирования.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = expensesListBox.SelectedIndex;
            var selectedExpense = trip.Expenses[selectedIndex];

            var editForm = new AddExpenseForm(selectedExpense.Description, selectedExpense.Amount);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedExpense.Description = editForm.Description;
                selectedExpense.Amount = editForm.Amount;
                LoadReportData(); 
            }
        }

        private void DeleteExpenseButton_Click(object sender, EventArgs e)
        {
            if (expensesListBox.SelectedItem == null || expensesListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите расход для удаления.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы действительно хотите удалить этот расход?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int selectedIndex = expensesListBox.SelectedIndex;
                trip.Expenses.RemoveAt(selectedIndex);
                LoadReportData(); 
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}