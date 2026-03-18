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
    public partial class AddExpenseForm : Form
    {
        public string Description { get; private set; }
        public decimal Amount { get; private set; }

        private TextBox descriptionTextBox;
        private TextBox amountTextBox;
        private Button okButton;
        private Button cancelButton;

        public AddExpenseForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Добавить расход";
            this.Size = new System.Drawing.Size(300, 150);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var descriptionLabel = new Label
            {
                Location = new System.Drawing.Point(10, 15),
                Text = "Описание:",
                AutoSize = true
            };

            var amountLabel = new Label
            {
                Location = new System.Drawing.Point(10, 45),
                Text = "Сумма:",
                AutoSize = true
            };

            descriptionTextBox = new TextBox
            {
                Location = new System.Drawing.Point(80, 12),
                Size = new System.Drawing.Size(190, 20)
            };

            amountTextBox = new TextBox
            {
                Location = new System.Drawing.Point(80, 42),
                Size = new System.Drawing.Size(190, 20)
            };

            okButton = new Button
            {
                Location = new System.Drawing.Point(100, 75),
                Text = "OK",
                Size = new System.Drawing.Size(75, 25),
                DialogResult = DialogResult.OK
            };
            okButton.Click += OkButton_Click;

            cancelButton = new Button
            {
                Location = new System.Drawing.Point(185, 75),
                Text = "Отмена",
                Size = new System.Drawing.Size(75, 25),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] {
                descriptionLabel, amountLabel,
                descriptionTextBox, amountTextBox,
                okButton, cancelButton
            });
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Введите описание расхода.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (!decimal.TryParse(amountTextBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную положительную сумму.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            Description = descriptionTextBox.Text;
            Amount = amount;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
