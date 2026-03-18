using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelPlanner
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

   
            var trip = new Trip(
                "Париж",
                DateTime.Now,
                DateTime.Now.AddDays(7),
                50000m
            );

            trip.AddExpense(new Expense("Билеты на самолет", 25000m));
            trip.AddExpense(new Expense("Отель", 15000m));

            Application.Run(new MainForm(trip));
        }
    }
}
