using System.Drawing;
using System.Windows.Forms;

namespace TravelPlanner
{
    partial class MainForm
    {
        // УДАЛИТЬ ЭТУ СТРОКУ: private System.ComponentModel.IContainer components = null;
        // Поле components будет только в MainForm.cs

        // Секция поездок
        private GroupBox tripsGroupBox;
        private ListBox tripsListBox;
        private Button createTripButton;
        private Button selectTripButton;
        private Button editTripButton;
        private Button deleteTripButton;
        private Button manageTasksButton;  // НОВАЯ КНОПКА

        // Секция расходов
        private GroupBox expensesGroupBox;
        private Label tripInfoLabel;
        private ListBox expensesListBox;
        private Button addExpenseButton;
        private Button editExpenseButton;
        private Button deleteExpenseButton;
        private Button displayDetailsButton;

        // УДАЛИТЬ МЕТОД Dispose - он будет в MainForm.cs

        private void InitializeComponent()
        {
            // Настройка главной формы
            this.Text = "Планировщик путешествий";
            this.Size = new System.Drawing.Size(900, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ==================== Группа поездок ====================
            this.tripsGroupBox = new GroupBox();
            this.tripsGroupBox.Text = "Мои поездки";
            this.tripsGroupBox.Location = new System.Drawing.Point(10, 10);
            this.tripsGroupBox.Size = new System.Drawing.Size(380, 620);
            this.tripsGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);

            // tripsListBox
            this.tripsListBox = new ListBox();
            this.tripsListBox.Location = new System.Drawing.Point(10, 25);
            this.tripsListBox.Size = new System.Drawing.Size(355, 420);
            this.tripsListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tripsListBox.DoubleClick += new System.EventHandler(this.TripsListBox_DoubleClick);

            // createTripButton
            this.createTripButton = new Button();
            this.createTripButton.Text = "+ Создать поездку";
            this.createTripButton.Location = new System.Drawing.Point(10, 455);
            this.createTripButton.Size = new System.Drawing.Size(170, 40);
            this.createTripButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.createTripButton.BackColor = System.Drawing.Color.LightGreen;
            this.createTripButton.FlatStyle = FlatStyle.System;
            this.createTripButton.Click += new System.EventHandler(this.CreateTripButton_Click);

            // selectTripButton
            this.selectTripButton = new Button();
            this.selectTripButton.Text = "✓ Выбрать поездку";
            this.selectTripButton.Location = new System.Drawing.Point(190, 455);
            this.selectTripButton.Size = new System.Drawing.Size(175, 40);
            this.selectTripButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectTripButton.BackColor = System.Drawing.Color.LightBlue;
            this.selectTripButton.FlatStyle = FlatStyle.System;
            this.selectTripButton.Click += new System.EventHandler(this.SelectTripButton_Click);

            // editTripButton
            this.editTripButton = new Button();
            this.editTripButton.Text = "✎ Редактировать поездку";
            this.editTripButton.Location = new System.Drawing.Point(10, 505);
            this.editTripButton.Size = new System.Drawing.Size(170, 40);
            this.editTripButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editTripButton.BackColor = System.Drawing.Color.LightYellow;
            this.editTripButton.FlatStyle = FlatStyle.System;
            this.editTripButton.Click += new System.EventHandler(this.EditTripButton_Click);

            // deleteTripButton
            this.deleteTripButton = new Button();
            this.deleteTripButton.Text = "✗ Удалить поездку";
            this.deleteTripButton.Location = new System.Drawing.Point(190, 505);
            this.deleteTripButton.Size = new System.Drawing.Size(175, 40);
            this.deleteTripButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteTripButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteTripButton.FlatStyle = FlatStyle.System;
            this.deleteTripButton.Click += new System.EventHandler(this.DeleteTripButton_Click);

            // НОВАЯ КНОПКА: Управление задачами
            this.manageTasksButton = new Button();
            this.manageTasksButton.Text = "📋 Управление задачами";
            this.manageTasksButton.Location = new System.Drawing.Point(10, 560);
            this.manageTasksButton.Size = new System.Drawing.Size(355, 40);
            this.manageTasksButton.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            this.manageTasksButton.BackColor = System.Drawing.Color.LightBlue;
            this.manageTasksButton.FlatStyle = FlatStyle.System;
            this.manageTasksButton.Click += new System.EventHandler(this.ManageTasksButton_Click);

            this.tripsGroupBox.Controls.Add(this.tripsListBox);
            this.tripsGroupBox.Controls.Add(this.createTripButton);
            this.tripsGroupBox.Controls.Add(this.selectTripButton);
            this.tripsGroupBox.Controls.Add(this.editTripButton);
            this.tripsGroupBox.Controls.Add(this.deleteTripButton);
            this.tripsGroupBox.Controls.Add(this.manageTasksButton);

            // ==================== Группа расходов ====================
            this.expensesGroupBox = new GroupBox();
            this.expensesGroupBox.Text = "Управление расходами";
            this.expensesGroupBox.Location = new System.Drawing.Point(400, 10);
            this.expensesGroupBox.Size = new System.Drawing.Size(480, 620);
            this.expensesGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);

            // tripInfoLabel
            this.tripInfoLabel = new Label();
            this.tripInfoLabel.Location = new System.Drawing.Point(10, 25);
            this.tripInfoLabel.Size = new System.Drawing.Size(455, 60);
            this.tripInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tripInfoLabel.BorderStyle = BorderStyle.FixedSingle;
            this.tripInfoLabel.TextAlign = ContentAlignment.MiddleLeft;

            // expensesListBox
            this.expensesListBox = new ListBox();
            this.expensesListBox.Location = new System.Drawing.Point(10, 95);
            this.expensesListBox.Size = new System.Drawing.Size(455, 380);
            this.expensesListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.expensesListBox.ScrollAlwaysVisible = true;
            this.expensesListBox.SelectedIndexChanged += new System.EventHandler(this.ExpensesListBox_SelectedIndexChanged);

            // addExpenseButton
            this.addExpenseButton = new Button();
            this.addExpenseButton.Text = "+ Добавить расход";
            this.addExpenseButton.Location = new System.Drawing.Point(10, 490);
            this.addExpenseButton.Size = new System.Drawing.Size(145, 40);
            this.addExpenseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addExpenseButton.BackColor = System.Drawing.Color.LightGreen;
            this.addExpenseButton.FlatStyle = FlatStyle.System;
            this.addExpenseButton.Click += new System.EventHandler(this.AddExpenseButton_Click);

            // editExpenseButton
            this.editExpenseButton = new Button();
            this.editExpenseButton.Text = "✎ Редактировать расход";
            this.editExpenseButton.Location = new System.Drawing.Point(165, 490);
            this.editExpenseButton.Size = new System.Drawing.Size(145, 40);
            this.editExpenseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editExpenseButton.BackColor = System.Drawing.Color.LightYellow;
            this.editExpenseButton.FlatStyle = FlatStyle.System;
            this.editExpenseButton.Click += new System.EventHandler(this.EditExpenseButton_Click);

            // deleteExpenseButton
            this.deleteExpenseButton = new Button();
            this.deleteExpenseButton.Text = "✗ Удалить расход";
            this.deleteExpenseButton.Location = new System.Drawing.Point(320, 490);
            this.deleteExpenseButton.Size = new System.Drawing.Size(145, 40);
            this.deleteExpenseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteExpenseButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteExpenseButton.FlatStyle = FlatStyle.System;
            this.deleteExpenseButton.Click += new System.EventHandler(this.DeleteExpenseButton_Click);

            // displayDetailsButton
            this.displayDetailsButton = new Button();
            this.displayDetailsButton.Text = "📊 Показать полный отчет";
            this.displayDetailsButton.Location = new System.Drawing.Point(165, 550);
            this.displayDetailsButton.Size = new System.Drawing.Size(300, 40);
            this.displayDetailsButton.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            this.displayDetailsButton.BackColor = System.Drawing.Color.LightGray;
            this.displayDetailsButton.FlatStyle = FlatStyle.System;
            this.displayDetailsButton.Click += new System.EventHandler(this.DisplayDetailsButton_Click);

            this.expensesGroupBox.Controls.Add(this.tripInfoLabel);
            this.expensesGroupBox.Controls.Add(this.expensesListBox);
            this.expensesGroupBox.Controls.Add(this.addExpenseButton);
            this.expensesGroupBox.Controls.Add(this.editExpenseButton);
            this.expensesGroupBox.Controls.Add(this.deleteExpenseButton);
            this.expensesGroupBox.Controls.Add(this.displayDetailsButton);

            // Добавление на форму
            this.Controls.Add(this.tripsGroupBox);
            this.Controls.Add(this.expensesGroupBox);
        }
    }
}