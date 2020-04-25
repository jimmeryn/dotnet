using WorkHoursTracker.Models;
using System;
using System.Linq;

namespace WorkHoursTracker.Data
{
  public static class DbInitializer
  {
    public static void Initialize(DataBaseContext context)
    {
      context.Database.EnsureCreated();
      if (context.employees.Any())
      {
        return;
      }
      else
      {
        // TODO: get employees from json file/ json.placeholder
        var Employees = new Employee[] { new Employee { Name = "Jonh", Surname = "Smith", JobTitle = "Worker" } };
        foreach (Employee employee in Employees)
        {
          context.employees.Add(employee);
        }
        context.SaveChanges();
      }

    }
  }
}