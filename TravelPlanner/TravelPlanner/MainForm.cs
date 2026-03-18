using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelPlanner
{
    public partial class MainForm : Form
    {
        private Trip trip;
        private Button addExpenseButton;
        private Button displayDetailsButton;
        private Label tripInfoLabel;
        private ListBox expensesListBox;

        public MainForm(Trip trip)
        {
            this.trip = trip;
            InitializeComponent();
            UpdateExpensesList();
        }

        private void InitializeComponent()
        {
            this.Text = "Планировщик путешествий";
            this.Size = new System.Drawing.Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            tripInfoLabel = new Label
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(360, 60),
                Text = $"Поездка в {trip.Destination}\n" +
                       $"Даты: {trip.StartDate:dd.MM.yyyy} - {trip.EndDate:dd.MM.yyyy}\n" +
                       $"Бюджет: {trip.Budget:C}",
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            };

            expensesListBox = new ListBox
            {
                Location = new System.Drawing.Point(10, 80),
                Size = new System.Drawing.Size(360, 180),
                ScrollAlwaysVisible = true
            };

            addExpenseButton = new Button
            {
                Location = new System.Drawing.Point(10, 270),
                Text = "Добавить расход",
                Size = new System.Drawing.Size(120, 30)
            };
            addExpenseButton.Click += AddExpenseButton_Click;

            displayDetailsButton = new Button
            {
                Location = new System.Drawing.Point(140, 270),
                Text = "Показать отчет",
                Size = new System.Drawing.Size(120, 30)
            };
            displayDetailsButton.Click += DisplayDetailsButton_Click;

            this.Controls.AddRange(new Control[] {
                tripInfoLabel,
                expensesListBox,
                addExpenseButton,
                displayDetailsButton
            });
        }

        private void AddExpenseButton_Click(object sender, EventArgs e)
        {
            var addExpenseForm = new AddExpenseForm();
            if (addExpenseForm.ShowDialog() == DialogResult.OK)
            {
                var expense = new Expense(addExpenseForm.Description, addExpenseForm.Amount);
                trip.AddExpense(expense);
                UpdateExpensesList();
            }
        }

        private void DisplayDetailsButton_Click(object sender, EventArgs e)
        {
            trip.DisplayTripDetails();
        }

        private void UpdateExpensesList()
        {
            expensesListBox.Items.Clear();
            if (trip.Expenses.Count == 0)
            {
                expensesListBox.Items.Add("Нет добавленных расходов");
            }
            else
            {
                foreach (var expense in trip.Expenses)
                {
                    expensesListBox.Items.Add(expense.ToString());
                }

                decimal total = trip.CalculateTotalExpenses();
                decimal remaining = trip.RemainingBudget();

                expensesListBox.Items.Add("");
                expensesListBox.Items.Add($"Всего расходов: {total:C}");
                expensesListBox.Items.Add($"Остаток бюджета: {remaining:C}");
            }
        }
    }
}
