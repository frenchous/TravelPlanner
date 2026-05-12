using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelPlanner
{
    partial class TaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private DateTimePicker dueDatePicker;
        private NumericUpDown reminderNumericUpDown;
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
            this.components = new System.ComponentModel.Container();

            // Настройка формы
            this.Text = "Задача";
            this.Size = new System.Drawing.Size(450, 280);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label: Название задачи
            var titleLabel = new Label();
            titleLabel.Text = "Название задачи:";
            titleLabel.Location = new System.Drawing.Point(15, 15);
            titleLabel.Size = new System.Drawing.Size(120, 25);
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;

            // TextBox: Название задачи
            this.titleTextBox = new TextBox();
            this.titleTextBox.Location = new System.Drawing.Point(140, 15);
            this.titleTextBox.Size = new System.Drawing.Size(280, 23);
            this.titleTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Label: Описание
            var descLabel = new Label();
            descLabel.Text = "Описание:";
            descLabel.Location = new System.Drawing.Point(15, 50);
            descLabel.Size = new System.Drawing.Size(120, 25);
            descLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            descLabel.TextAlign = ContentAlignment.MiddleLeft;

            // TextBox: Описание (многострочный)
            this.descriptionTextBox = new TextBox();
            this.descriptionTextBox.Location = new System.Drawing.Point(140, 50);
            this.descriptionTextBox.Size = new System.Drawing.Size(280, 60);
            this.descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.descriptionTextBox.Multiline = true;

            // Label: Дедлайн
            var dueLabel = new Label();
            dueLabel.Text = "Дедлайн:";
            dueLabel.Location = new System.Drawing.Point(15, 120);
            dueLabel.Size = new System.Drawing.Size(120, 25);
            dueLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            dueLabel.TextAlign = ContentAlignment.MiddleLeft;

            // DateTimePicker: Дедлайн
            this.dueDatePicker = new DateTimePicker();
            this.dueDatePicker.Location = new System.Drawing.Point(140, 120);
            this.dueDatePicker.Size = new System.Drawing.Size(150, 23);
            this.dueDatePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dueDatePicker.Format = DateTimePickerFormat.Short;
            this.dueDatePicker.Value = DateTime.Now.AddDays(7);

            // Label: Напоминание
            var reminderLabel = new Label();
            reminderLabel.Text = "Уведомлять за (дней):";
            reminderLabel.Location = new System.Drawing.Point(15, 155);
            reminderLabel.Size = new System.Drawing.Size(140, 25);
            reminderLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            reminderLabel.TextAlign = ContentAlignment.MiddleLeft;

            // NumericUpDown: Дни для напоминания
            this.reminderNumericUpDown = new NumericUpDown();
            this.reminderNumericUpDown.Location = new System.Drawing.Point(160, 155);
            this.reminderNumericUpDown.Size = new System.Drawing.Size(70, 23);
            this.reminderNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.reminderNumericUpDown.Minimum = 1;
            this.reminderNumericUpDown.Maximum = 30;
            this.reminderNumericUpDown.Value = 3;

            // Button: OK
            this.okButton = new Button();
            this.okButton.Text = "Сохранить";
            this.okButton.Location = new System.Drawing.Point(110, 200);
            this.okButton.Size = new System.Drawing.Size(100, 35);
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            this.okButton.BackColor = System.Drawing.Color.LightGreen;
            this.okButton.FlatStyle = FlatStyle.System;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);

            // Button: Отмена
            this.cancelButton = new Button();
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Location = new System.Drawing.Point(230, 200);
            this.cancelButton.Size = new System.Drawing.Size(100, 35);
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cancelButton.BackColor = System.Drawing.Color.LightCoral;
            this.cancelButton.FlatStyle = FlatStyle.System;
            this.cancelButton.DialogResult = DialogResult.Cancel;

            // Добавление контролов на форму
            this.Controls.Add(titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(descLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(dueLabel);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(reminderLabel);
            this.Controls.Add(this.reminderNumericUpDown);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
        }
    }
}