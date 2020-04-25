using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using WorkHoursTracker.Models;

namespace WorkHoursTracker
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public App()
    {
      Connection connection = new Connection();
      // connection.ReadData();
      Time time = new Time();
      Employee employee = new Employee();
    }
  }
}
