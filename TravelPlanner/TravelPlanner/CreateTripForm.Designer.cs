using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelPlanner
{
    partial class CreateTripForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox destinationTextBox;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private TextBox budgetTextBox;
        private Button okButton;
        private Button cancelButton;

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
            this.Text = "Создание поездки";
            this.Size = new System.Drawing.Size(420, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Destination Label
            var destinationLabel = new Label();
            destinationLabel.Text = "Направление:";
            destinationLabel.Location = new System.Drawing.Point(20, 25);
            destinationLabel.Size = new System.Drawing.Size(120, 30);
            destinationLabel.Font = new System.Drawing.Font("Segoe UI", 10F);

            // destinationTextBox
            this.destinationTextBox = new TextBox();
            this.destinationTextBox.Location = new System.Drawing.Point(150, 25);
            this.destinationTextBox.Size = new System.Drawing.Size(230, 27);
            this.destinationTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Start Date Label
            var startDateLabel = new Label();
            startDateLabel.Text = "Дата начала:";
            startDateLabel.Location = new System.Drawing.Point(20, 65);
            startDateLabel.Size = new System.Drawing.Size(120, 30);
            startDateLabel.Font = new System.Drawing.Font("Segoe UI", 10F);

            // startDatePicker
            this.startDatePicker = new DateTimePicker();
            this.startDatePicker.Location = new System.Drawing.Point(150, 65);
            this.startDatePicker.Size = new System.Drawing.Size(230, 27);
            this.startDatePicker.Format = DateTimePickerFormat.Short;
            this.startDatePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.startDatePicker.Value = DateTime.Now;

            // End Date Label
            var endDateLabel = new Label();
            endDateLabel.Text = "Дата окончания:";
            endDateLabel.Location = new System.Drawing.Point(20, 105);
            endDateLabel.Size = new System.Drawing.Size(120, 30);
            endDateLabel.Font = new System.Drawing.Font("Segoe UI", 10F);

            // endDatePicker
            this.endDatePicker = new DateTimePicker();
            this.endDatePicker.Location = new System.Drawing.Point(150, 105);
            this.endDatePicker.Size = new System.Drawing.Size(230, 27);
            this.endDatePicker.Format = DateTimePickerFormat.Short;
            this.endDatePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.endDatePicker.Value = DateTime.Now.AddDays(7);

            // Budget Label
            var budgetLabel = new Label();
            budgetLabel.Text = "Бюджет (руб.):";
            budgetLabel.Location = new System.Drawing.Point(20, 145);
            budgetLabel.Size = new System.Drawing.Size(120, 30);
            budgetLabel.Font = new System.Drawing.Font("Segoe UI", 10F);

            // budgetTextBox
            this.budgetTextBox = new TextBox();
            this.budgetTextBox.Location = new System.Drawing.Point(150, 145);
            this.budgetTextBox.Size = new System.Drawing.Size(230, 27);
            this.budgetTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);

            // okButton
            this.okButton = new Button();
            this.okButton.Text = "Сохранить";
            this.okButton.Location = new System.Drawing.Point(90, 200);
            this.okButton.Size = new System.Drawing.Size(110, 45);
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.okButton.BackColor = System.Drawing.Color.LightGreen;
            this.okButton.FlatStyle = FlatStyle.System;
            this.okButton.Click += new EventHandler(this.OkButton_Click);

            // cancelButton
            this.cancelButton = new Button();
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Location = new System.Drawing.Point(220, 200);
            this.cancelButton.Size = new System.Drawing.Size(110, 45);
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cancelButton.BackColor = System.Drawing.Color.LightCoral;
            this.cancelButton.FlatStyle = FlatStyle.System;
            this.cancelButton.DialogResult = DialogResult.Cancel;

            // Добавление контролов на форму
            this.Controls.Add(destinationLabel);
            this.Controls.Add(this.destinationTextBox);
            this.Controls.Add(startDateLabel);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(endDateLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(budgetLabel);
            this.Controls.Add(this.budgetTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
        }
    }
}