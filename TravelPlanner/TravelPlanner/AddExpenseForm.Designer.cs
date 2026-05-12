using System;
using System.Windows.Forms;

namespace TravelPlanner
{
    partial class AddExpenseForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox descriptionTextBox;
        private TextBox amountTextBox;
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
            this.Text = "Добавить расход";
            this.Size = new System.Drawing.Size(300, 150);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // descriptionLabel
            var descriptionLabel = new Label();
            descriptionLabel.Location = new System.Drawing.Point(10, 15);
            descriptionLabel.Text = "Описание:";
            descriptionLabel.AutoSize = true;

            // amountLabel
            var amountLabel = new Label();
            amountLabel.Location = new System.Drawing.Point(10, 45);
            amountLabel.Text = "Сумма:";
            amountLabel.AutoSize = true;

            // descriptionTextBox
            this.descriptionTextBox = new TextBox();
            this.descriptionTextBox.Location = new System.Drawing.Point(80, 12);
            this.descriptionTextBox.Size = new System.Drawing.Size(190, 20);

            // amountTextBox
            this.amountTextBox = new TextBox();
            this.amountTextBox.Location = new System.Drawing.Point(80, 42);
            this.amountTextBox.Size = new System.Drawing.Size(190, 20);

            // okButton
            this.okButton = new Button();
            this.okButton.Location = new System.Drawing.Point(100, 75);
            this.okButton.Text = "OK";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Click += new EventHandler(this.OkButton_Click);

            // cancelButton
            this.cancelButton = new Button();
            this.cancelButton.Location = new System.Drawing.Point(185, 75);
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.DialogResult = DialogResult.Cancel;

            // Добавление контролов на форму
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(amountLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
        }
    }
}