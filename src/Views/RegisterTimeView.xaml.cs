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
    /// <summary>
    /// RegisterTimeView class basic constructor, starting clock and updating current employee work state.
    /// </summary>
    public RegisterTimeView()
    {
      InitializeComponent();
      StartClock();
      UpdateWorkState();
    }

    /// <summary>
    /// Start clock that is visable on the screen.
    /// </summary>
    private void StartClock()
    {
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromSeconds(1);
      timer.Tick += tickevent;
      timer.Start();
    }

    /// <summary>
    /// Update clock every second
    /// </summary>
    private void tickevent(object sender, EventArgs e)
    {
      datalbl.Text = DateTime.Now.ToString();
    }

    /// <summary>
    /// Updating work state which is string visiable on the screen and making sure one button is disable.
    /// </summary>
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

    /// <summary>
    /// Change buttons state.
    /// </summary>
    private void EnableWorkingButtons(bool isWorking)
    {
      StartWorkingButton.IsEnabled = !isWorking;
      StopWorkingButton.IsEnabled = isWorking;
    }

    /// <summary>
    /// RegisterTimeView class main logic. Start new time or update previously started and store it in database.
    /// </summary>
    public void registerTime(object sender, RoutedEventArgs e)
    {
      // Check if current employee is working or not and set start or stop time accordingly
      using (var context = new DataBaseContext())
      {
        try
        {
          var currentEmployee = context.Employees.FirstOrDefault(user =>
              user.Name == ((App)Application.Current).Name &&
              user.Surname == ((App)Application.Current).Surname);
          if (currentEmployee != null)
          {
            if (currentEmployee.CurrentTimeId == null)
            {
              var time = new Time
              {
                TimeId = context.Times.DefaultIfEmpty().Max(t => t.TimeId) + 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                EmployeeId = currentEmployee.EmployeeId
              };
              context.Times.Add(time);
              currentEmployee.Times.Add(time);
              currentEmployee.CurrentTimeId = time.TimeId;
              ((App)Application.Current).CurrentTimeId = time.TimeId;
            }
            else
            {
              var currentTime = context.Times.FirstOrDefault(time => time.TimeId == currentEmployee.CurrentTimeId);
              currentTime.EndDate = DateTime.Now;
              context.Times.Update(currentTime);
              currentEmployee.CurrentTimeId = null;
              ((App)Application.Current).CurrentTimeId = null;
            }
            context.Employees.Update(currentEmployee);
            context.SaveChanges();
            UpdateWorkState();
          }
        }
        catch (System.Exception ex)
        {
          throw ex;
        }
      }
    }
  }
}
