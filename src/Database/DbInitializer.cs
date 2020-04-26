using WorkHoursTracker.Models;
using System;
using System.Linq;

namespace WorkHoursTracker.Data
{
  /// <summary>
  /// Initialize database class
  /// </summary>
  public static class DbInitializer
  {
    /// <summary>
    /// Used to initialize database
    /// </summary>
    public static void Initialize(DataBaseContext context)
    {
      context.Database.EnsureCreated();
      if (context.Employees.Any())
      {
        return;
      }
      else
      {
        // TODO: get employees from json file/ json.placeholder
        var Employees = new Employee[] { new Employee { Name = "Jonh", Surname = "Smith", JobTitle = "Worker" } };
        foreach (Employee employee in Employees)
        {
          context.Employees.Add(employee);
        }
        context.SaveChanges();
      }

    }
  }
}