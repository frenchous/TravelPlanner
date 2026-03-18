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
    public partial class TripReportForm : Form
    {
        private Trip trip;

        public TripReportForm(Trip trip)
        {
            this.trip = trip;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Отчет по путешествию";
            this.Size = new System.Drawing.Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            var titleLabel = new Label
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(460, 25),
                Text = $"Отчет о поездке в {trip.Destination}",
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            var infoGroupBox = new GroupBox
            {
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(460, 100),
                Text = "Информация о поездке"
            };

            var startDateLabel = new Label
            {
                Location = new System.Drawing.Point(10, 20),
                Text = $"Дата начала: {trip.StartDate:dd.MM.yyyy}",
                AutoSize = true
            };

            var endDateLabel = new Label
            {
                Location = new System.Drawing.Point(10, 40),
                Text = $"Дата окончания: {trip.EndDate:dd.MM.yyyy}",
                AutoSize = true
            };

            var budgetLabel = new Label
            {
                Location = new System.Drawing.Point(10, 60),
                Text = $"Бюджет: {trip.Budget:C}",
                AutoSize = true
            };

            infoGroupBox.Controls.AddRange(new Control[] { startDateLabel, endDateLabel, budgetLabel });

            var financeGroupBox = new GroupBox
            {
                Location = new System.Drawing.Point(10, 150),
                Size = new System.Drawing.Size(460, 80),
                Text = "Финансовая информация"
            };

            var totalExpenses = trip.CalculateTotalExpenses();
            var remainingBudget = trip.RemainingBudget();

            var totalExpensesLabel = new Label
            {
                Location = new System.Drawing.Point(10, 20),
                Text = $"Всего расходов: {totalExpenses:C}",
                AutoSize = true
            };

            var remainingBudgetLabel = new Label
            {
                Location = new System.Drawing.Point(10, 40),
                Text = $"Оставшийся бюджет: {remainingBudget:C}",
                AutoSize = true,
                ForeColor = remainingBudget >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red
            };

            financeGroupBox.Controls.AddRange(new Control[] { totalExpensesLabel, remainingBudgetLabel });

            var expensesGroupBox = new GroupBox
            {
                Location = new System.Drawing.Point(10, 240),
                Size = new System.Drawing.Size(460, 110),
                Text = "Список расходов"
            };

            var expensesListBox = new ListBox
            {
                Location = new System.Drawing.Point(10, 20),
                Size = new System.Drawing.Size(440, 80),
                ScrollAlwaysVisible = true
            };

            if (trip.Expenses.Any())
            {
                foreach (var expense in trip.Expenses)
                {
                    expensesListBox.Items.Add(expense.ToString());
                }
            }
            else
            {
                expensesListBox.Items.Add("Нет добавленных расходов");
            }

            expensesGroupBox.Controls.Add(expensesListBox);

            var closeButton = new Button
            {
                Location = new System.Drawing.Point(200, 360),
                Text = "Закрыть",
                Size = new System.Drawing.Size(75, 25)
            };
            closeButton.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                titleLabel,
                infoGroupBox,
                financeGroupBox,
                expensesGroupBox,
                closeButton
            });
        }
    }
}
