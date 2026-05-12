using System;
using System.Text.Json.Serialization;

namespace TravelPlanner
{
    public class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        [JsonConstructor]
        public Expense(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
            Date = DateTime.Now;
        }

        public Expense() { }

        public override string ToString()
        {
            return $"{Description} - {Amount:C} ({Date:dd.MM.yyyy})";
        }
    }
}