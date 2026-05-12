using System;
using System.Text.Json.Serialization;

namespace TravelPlanner
{
    public class TripTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ReminderDaysBefore { get; set; }

        [JsonConstructor]
        public TripTask(string title, string description, DateTime dueDate, int reminderDaysBefore = 3)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
            CreatedDate = DateTime.Now;
            ReminderDaysBefore = reminderDaysBefore;
        }

        public TripTask() { }

        public bool IsOverdue()
        {
            return !IsCompleted && DueDate < DateTime.Now;
        }

        public bool ShouldNotify()
        {
            if (IsCompleted) return false;
            TimeSpan timeUntilDue = DueDate - DateTime.Now;
            return timeUntilDue.TotalDays <= ReminderDaysBefore && timeUntilDue.TotalDays >= 0;
        }

        public string GetStatusString()
        {
            if (IsCompleted) return "✓ Выполнена";
            if (IsOverdue()) return "⚠ Просрочена!";
            if (ShouldNotify()) return "🔔 Скоро!";
            return "○ Ожидает";
        }

        public override string ToString()
        {
            return $"[{GetStatusString()}] {Title} - {Description} (до {DueDate:dd.MM.yyyy})";
        }
    }
}