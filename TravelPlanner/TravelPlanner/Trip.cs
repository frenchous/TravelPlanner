using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TravelPlanner
{
    public class Trip
    {
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<TripTask> Tasks { get; set; }

        [JsonConstructor]
        public Trip(string destination, DateTime startDate, DateTime endDate, decimal budget)
        {
            Destination = destination;
            StartDate = startDate;
            EndDate = endDate;
            Budget = budget;
            Expenses = new List<Expense>();
            Tasks = new List<TripTask>();
        }

        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
        }

        public void AddTask(TripTask task)
        {
            Tasks.Add(task);
        }

        public decimal CalculateTotalExpenses()
        {
            return Expenses.Sum(e => e.Amount);
        }

        public decimal RemainingBudget()
        {
            return Budget - CalculateTotalExpenses();
        }

        public List<TripTask> GetOverdueTasks()
        {
            return Tasks.Where(t => t.IsOverdue()).ToList();
        }

        public List<TripTask> GetUpcomingTasks(int daysAhead = 7)
        {
            return Tasks.Where(t => !t.IsCompleted &&
                t.DueDate >= DateTime.Now &&
                t.DueDate <= DateTime.Now.AddDays(daysAhead)).ToList();
        }

        public void DisplayTripDetails()
        {
            var reportForm = new TripReportForm(this);
            reportForm.ShowDialog();
        }
    }
}