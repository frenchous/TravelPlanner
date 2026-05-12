using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelPlanner
{
    partial class TripReportForm
    {
        private System.ComponentModel.IContainer components = null;

  
        private Button closeButton;
        private Button editExpenseButton;    
        private Button deleteExpenseButton;  
        private GroupBox infoGroupBox;
        private GroupBox financeGroupBox;
        private GroupBox expensesGroupBox;
        private ListBox expensesListBox;
        private Label titleLabel;
        private Label startDateLabel;
        private Label endDateLabel;
        private Label budgetLabel;
        private Label totalExpensesLabel;
        private Label remainingBudgetLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Настройка формы
            this.Text = "Отчет по путешествию";
            this.Size = new System.Drawing.Size(550, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // titleLabel
            this.titleLabel = new Label();
            this.titleLabel.Location = new System.Drawing.Point(10, 10);
            this.titleLabel.Size = new System.Drawing.Size(510, 30);
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // infoGroupBox
            this.infoGroupBox = new GroupBox();
            this.infoGroupBox.Location = new System.Drawing.Point(10, 50);
            this.infoGroupBox.Size = new System.Drawing.Size(510, 110);
            this.infoGroupBox.Text = "Информация о поездке";

            // startDateLabel
            this.startDateLabel = new Label();
            this.startDateLabel.Location = new System.Drawing.Point(10, 25);
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F);

            // endDateLabel
            this.endDateLabel = new Label();
            this.endDateLabel.Location = new System.Drawing.Point(10, 50);
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F);

            // budgetLabel
            this.budgetLabel = new Label();
            this.budgetLabel.Location = new System.Drawing.Point(10, 75);
            this.budgetLabel.AutoSize = true;
            this.budgetLabel.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.infoGroupBox.Controls.Add(this.startDateLabel);
            this.infoGroupBox.Controls.Add(this.endDateLabel);
            this.infoGroupBox.Controls.Add(this.budgetLabel);

            // financeGroupBox
            this.financeGroupBox = new GroupBox();
            this.financeGroupBox.Location = new System.Drawing.Point(10, 170);
            this.financeGroupBox.Size = new System.Drawing.Size(510, 90);
            this.financeGroupBox.Text = "Финансовая информация";

            // totalExpensesLabel
            this.totalExpensesLabel = new Label();
            this.totalExpensesLabel.Location = new System.Drawing.Point(10, 25);
            this.totalExpensesLabel.AutoSize = true;
            this.totalExpensesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);

            // remainingBudgetLabel
            this.remainingBudgetLabel = new Label();
            this.remainingBudgetLabel.Location = new System.Drawing.Point(10, 50);
            this.remainingBudgetLabel.AutoSize = true;
            this.remainingBudgetLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.financeGroupBox.Controls.Add(this.totalExpensesLabel);
            this.financeGroupBox.Controls.Add(this.remainingBudgetLabel);

            // expensesGroupBox
            this.expensesGroupBox = new GroupBox();
            this.expensesGroupBox.Location = new System.Drawing.Point(10, 270);
            this.expensesGroupBox.Size = new System.Drawing.Size(510, 130);
            this.expensesGroupBox.Text = "Список расходов";

            // expensesListBox
            this.expensesListBox = new ListBox();
            this.expensesListBox.Location = new System.Drawing.Point(10, 20);
            this.expensesListBox.Size = new System.Drawing.Size(490, 95);
            this.expensesListBox.ScrollAlwaysVisible = true;
            this.expensesListBox.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.expensesGroupBox.Controls.Add(this.expensesListBox);

            // editExpenseButton - исправленное имя
            this.editExpenseButton = new Button();
            this.editExpenseButton.Text = "Редактировать расход";
            this.editExpenseButton.Location = new System.Drawing.Point(130, 410);
            this.editExpenseButton.Size = new System.Drawing.Size(130, 30);
            this.editExpenseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editExpenseButton.BackColor = System.Drawing.Color.LightYellow;
            this.editExpenseButton.FlatStyle = FlatStyle.System;
            this.editExpenseButton.Click += new EventHandler(this.EditExpenseButton_Click);

            // deleteExpenseButton - исправленное имя
            this.deleteExpenseButton = new Button();
            this.deleteExpenseButton.Text = "Удалить расход";
            this.deleteExpenseButton.Location = new System.Drawing.Point(270, 410);
            this.deleteExpenseButton.Size = new System.Drawing.Size(130, 30);
            this.deleteExpenseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteExpenseButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteExpenseButton.FlatStyle = FlatStyle.System;
            this.deleteExpenseButton.Click += new EventHandler(this.DeleteExpenseButton_Click);

            // closeButton
            this.closeButton = new Button();
            this.closeButton.Text = "Закрыть";
            this.closeButton.Location = new System.Drawing.Point(410, 410);
            this.closeButton.Size = new System.Drawing.Size(100, 30);
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeButton.BackColor = System.Drawing.Color.LightGray;
            this.closeButton.FlatStyle = FlatStyle.System;
            this.closeButton.Click += new EventHandler(this.CloseButton_Click);

            // Добавление контролов на форму
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.financeGroupBox);
            this.Controls.Add(this.expensesGroupBox);
            this.Controls.Add(this.editExpenseButton);
            this.Controls.Add(this.deleteExpenseButton);
            this.Controls.Add(this.closeButton);
        }
    }
}