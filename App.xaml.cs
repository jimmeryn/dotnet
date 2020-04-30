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

    ///<value> EmployeeId stored localy in app.</value>
    ///<see cref="WorkHoursTracker.Models.Employee.EmployeeId"/>
    public int EmployeeId { get; set; }

    ///<value> Name stored localy in app.</value>
    ///<see cref="WorkHoursTracker.Models.Employee.Name"/>
    public string Name { get; set; }

    ///<value> Surname stored localy in app.</value>
    ///<see cref="WorkHoursTracker.Models.Employee.Surname"/>
    public string Surname { get; set; }

    ///<value> JobTitle stored localy in app.</value>
    ///<see cref="WorkHoursTracker.Models.Employee.JobTitle"/>
    public string JobTitle { get; set; }

    ///<value> CurentTimeId stored localy in app.</value>
    ///<see cref="WorkHoursTracker.Models.Employee.CurrentTimeId"/>
    public Nullable<int> CurrentTimeId { get; set; }

    /// <summary>
    /// CreateCurrentEmployee is a method in the App class creating instance of Employee stored localy in memory.
    /// </summary>
    /// <param name="name">Name of currently logged employee.</param>
    /// <param name="surname">Surname of currently logged employee.</param>
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
