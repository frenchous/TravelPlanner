using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class Trip
    {
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public List<Expense> Expenses { get; set; }

        public Trip(string destination, DateTime startDate, DateTime endDate, decimal budget)
        {
            Destination = destination;
            StartDate = startDate;
            EndDate = endDate;
            Budget = budget;
            Expenses = new List<Expense>();
        }

        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
        }

        public decimal CalculateTotalExpenses()
        {
            return Expenses.Sum(e => e.Amount);
        }

        public decimal RemainingBudget()
        {
            return Budget - CalculateTotalExpenses();
        }

        public void DisplayTripDetails()
        {
            var reportForm = new TripReportForm(this);
            reportForm.ShowDialog();
        }
    }
}
