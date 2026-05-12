using System.Drawing;
using System.Windows.Forms;

namespace TravelPlanner
{
    partial class TripTasksForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox tasksListBox;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button completeButton;
        private Button closeButton;
        private Label infoLabel;

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
            this.Size = new System.Drawing.Size(650, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label информации о поездке
            this.infoLabel = new Label();
            this.infoLabel.Location = new System.Drawing.Point(10, 10);
            this.infoLabel.Size = new System.Drawing.Size(615, 45);
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            this.infoLabel.BorderStyle = BorderStyle.FixedSingle;
            this.infoLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.infoLabel.Padding = new Padding(10, 0, 0, 0);

            // ListBox для списка задач
            this.tasksListBox = new ListBox();
            this.tasksListBox.Location = new System.Drawing.Point(10, 65);
            this.tasksListBox.Size = new System.Drawing.Size(615, 300);
            this.tasksListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tasksListBox.SelectedIndexChanged += new System.EventHandler(this.TasksListBox_SelectedIndexChanged);

            // Кнопка: Добавить задачу
            this.addButton = new Button();
            this.addButton.Text = "+ Добавить задачу";
            this.addButton.Location = new System.Drawing.Point(10, 380);
            this.addButton.Size = new System.Drawing.Size(130, 40);
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            this.addButton.BackColor = System.Drawing.Color.LightGreen;
            this.addButton.FlatStyle = FlatStyle.System;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);

            // Кнопка: Редактировать
            this.editButton = new Button();
            this.editButton.Text = "✎ Редактировать";
            this.editButton.Location = new System.Drawing.Point(150, 380);
            this.editButton.Size = new System.Drawing.Size(120, 40);
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editButton.BackColor = System.Drawing.Color.LightYellow;
            this.editButton.FlatStyle = FlatStyle.System;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);

            // Кнопка: Отметить выполненной
            this.completeButton = new Button();
            this.completeButton.Text = "✓ Отметить выполненной";
            this.completeButton.Location = new System.Drawing.Point(280, 380);
            this.completeButton.Size = new System.Drawing.Size(140, 40);
            this.completeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.completeButton.BackColor = System.Drawing.Color.LightBlue;
            this.completeButton.FlatStyle = FlatStyle.System;
            this.completeButton.Click += new System.EventHandler(this.CompleteButton_Click);

            // Кнопка: Удалить
            this.deleteButton = new Button();
            this.deleteButton.Text = "✗ Удалить";
            this.deleteButton.Location = new System.Drawing.Point(430, 380);
            this.deleteButton.Size = new System.Drawing.Size(100, 40);
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteButton.FlatStyle = FlatStyle.System;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);

            // Кнопка: Закрыть
            this.closeButton = new Button();
            this.closeButton.Text = "Закрыть";
            this.closeButton.Location = new System.Drawing.Point(540, 380);
            this.closeButton.Size = new System.Drawing.Size(85, 40);
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeButton.BackColor = System.Drawing.Color.LightGray;
            this.closeButton.FlatStyle = FlatStyle.System;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            // Добавление контролов на форму
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.tasksListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.closeButton);
        }
    }
}