using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using WorkHoursTracker.Models;

namespace WorkHoursTracker.Views
{
  /// <summary>
  /// Interaction logic for RegisterTimeView.xaml
  /// </summary>
  public partial class RegisterTimeView : UserControl
  {
    public RegisterTimeView()
    {
      InitializeComponent();
      StartClock();
      UpdateWorkState();
    }

    private void StartClock()
    {
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromSeconds(1);
      timer.Tick += tickevent;
      timer.Start();
    }

    private void tickevent(object sender, EventArgs e)
    {
      datalbl.Text = DateTime.Now.ToString();
    }

    private void UpdateWorkState()
    {
      if (((App)Application.Current).CurrentTimeId != null)
      {
        EnableWorkingButtons(true);
        State.Text = "At Work";
      }
      else
      {
        EnableWorkingButtons(false);
        State.Text = "Not Working";
      }
    }

    private void EnableWorkingButtons(bool isWorking)
    {
      StartWorkingButton.IsEnabled = !isWorking;
      StopWorkingButton.IsEnabled = isWorking;
    }

    public void registerTime(object sender, RoutedEventArgs e)
    {
      // check if curren employee is working or not and set start or stop time acordingly
      using (var context = new DataBaseContext())
      {
        try
        {
          context.Database.EnsureCreated();
          var currentEmployee = context.Employees.FirstOrDefault(user =>
              user.Name == ((App)Application.Current).Name &&
              user.Surname == ((App)Application.Current).Surname);
          if (currentEmployee != null)
          {
            var time = new Time
            {
              StartDate = DateTime.Now,
              EndDate = DateTime.Now,
              EmployeeId = currentEmployee.EmployeeId
            };
            context.Times.Add(time);
            currentEmployee.Times.Add(time);
            context.Employees.Update(currentEmployee);
            foreach (var item in context.Employees.FirstOrDefault().Times)
              System.Console.WriteLine(item.TimeId);
            context.SaveChanges();
          }
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
        {
          Console.WriteLine(ex.Entries);
          throw ex;
        }
        catch (System.Exception ex)
        {
          throw ex;
        }
      }
    }
  }
}
