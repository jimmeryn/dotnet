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

    public string Name { get; set; }
    public string Surname { get; set; }
  }
}
