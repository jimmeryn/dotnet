using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using WorkHoursTracker.Models;
using WorkHoursTracker.Data;

namespace WorkHoursTracker
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    /// <summary>
    /// App constructor
    /// </summary>
    public App()
    {
      using (var context = new DataBaseContext())
      {
        DbInitializer.Initialize(context);
      }
    }

    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string JobTitle { get; set; }
    public Nullable<int> CurrentTimeId { get; set; }

    public void CreateCurrentEmployee(string name, string surname)
    {
      Name = name;
      Surname = surname;
      using (var db = new DataBaseContext())
      {
        var currentEmployee = db.Employees.FirstOrDefault(user => user.Name == name && user.Surname == surname);
        if (currentEmployee != null)
        {
          EmployeeId = currentEmployee.EmployeeId;
          JobTitle = currentEmployee.JobTitle;
          CurrentTimeId = currentEmployee.CurrentTimeId;
        }
      }
    }
  }
}
