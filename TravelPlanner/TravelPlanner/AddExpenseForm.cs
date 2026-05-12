using System;
using System.Windows.Forms;

namespace TravelPlanner
{
    public partial class AddExpenseForm : Form
    {
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        private bool isEditMode;

        public AddExpenseForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Добавить расход";
        }

        public AddExpenseForm(string description, decimal amount)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "Редактировать расход";
            descriptionTextBox.Text = description;
            amountTextBox.Text = amount.ToString();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // Валидация описания
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Введите описание расхода.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Валидация суммы - проверка на отрицательную сумму
            if (!decimal.TryParse(amountTextBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную положительную сумму.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Сохранение данных
            Description = descriptionTextBox.Text;
            Amount = amount;

            // Сообщение об успешном добавлении/редактировании
            string message = isEditMode ?
                $"Расход \"{Description}\" на сумму {Amount:C} успешно отредактирован!" :
                $"Расход \"{Description}\" на сумму {Amount:C} успешно добавлен!";

            MessageBox.Show(message, "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Успешное завершение
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}