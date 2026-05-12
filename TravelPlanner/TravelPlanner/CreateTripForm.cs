using System;
using System.Windows.Forms;

namespace TravelPlanner
{
    public partial class CreateTripForm : Form
    {
        public string Destination { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal Budget { get; private set; }

        private bool isEditMode;

        // Конструктор для создания новой поездки (без параметров)
        public CreateTripForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Создание новой поездки";
        }

        // Конструктор для редактирования поездки (с 4 параметрами)
        public CreateTripForm(string destination, DateTime startDate, DateTime endDate, decimal budget)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "Редактирование поездки";

            destinationTextBox.Text = destination;
            startDatePicker.Value = startDate;
            endDatePicker.Value = endDate;
            budgetTextBox.Text = budget.ToString();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // Валидация направления
            if (string.IsNullOrWhiteSpace(destinationTextBox.Text))
            {
                MessageBox.Show("Введите направление путешествия.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Валидация дат
            if (endDatePicker.Value <= startDatePicker.Value)
            {
                MessageBox.Show("Дата окончания не может быть раньше или равна дате начала.",
                    "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Валидация бюджета
            if (!decimal.TryParse(budgetTextBox.Text, out decimal budget) || budget <= 0)
            {
                MessageBox.Show("Введите корректную положительную сумму бюджета.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Сохранение данных
            Destination = destinationTextBox.Text;
            StartDate = startDatePicker.Value;
            EndDate = endDatePicker.Value;
            Budget = budget;

            string message = isEditMode ?
                $"Поездка в {Destination} успешно обновлена!" :
                $"Поездка в {Destination} успешно создана!";

            MessageBox.Show(message, "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}