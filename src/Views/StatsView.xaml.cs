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

using LiveCharts;
using LiveCharts.Wpf;

using Microsoft.EntityFrameworkCore;

using WorkHoursTracker.Models;
using WorkHoursTracker.DataModels;

namespace WorkHoursTracker.Views
{
  /// <summary>
  /// Interaction logic for StatsView.xaml
  /// </summary>
  public partial class StatsView : UserControl
  {
    public StatsView()
    {
      InitializeComponent();
      TimeModelObject StatsContext = new TimeModelObject()
      {
        MonthTime = TimeSpanToHours(CalculateMonthTime(DateTime.Now.Month)),
        YearTime = TimeSpanToHours(CalculateYearTime()),
      };
      ThisMonthTime.DataContext = StatsContext;
      ThisYearTime.DataContext = StatsContext;
    }

    ///<summary>
    /// Calculate certain month work time and return it as Time Span
    ///</summary>
    public TimeSpan CalculateMonthTime(int month)
    {
      using (var context = new DataBaseContext())
      {
        return new TimeSpan(
          // get all times from Employee with current employeeId
          context.Times.Where(time =>
            time.EmployeeId == ((App)Application.Current).EmployeeId)
            .Where(time => time.StartDate.Year == DateTime.Now.Year && time.StartDate.Month == month)
          // summ all durations (difference between startDate and stopDate)
          .Select(time =>
            time.EndDate.Subtract(time.StartDate)).Sum(r => r.Ticks));
      }
    }

    ///<summary>
    /// Calculate this year work time and return it as Time Span
    ///</summary>
    public TimeSpan CalculateYearTime()
    {
      using (var context = new DataBaseContext())
      {
        return new TimeSpan(
          // get all times from Employee with current employeeId
          context.Times.Where(time =>
            time.EmployeeId == ((App)Application.Current).EmployeeId)
            .Where(time => time.StartDate.Year == DateTime.Now.Year)
          // summ all durations (difference between startDate and stopDate)
          .Select(time =>
            time.EndDate.Subtract(time.StartDate)).Sum(r => r.Ticks));
      }
    }

    ///<summary>
    /// Convert Time Span to string in fromat hours:minutes
    ///</summary>
    private string TimeSpanToHours(TimeSpan time)
    {
      return string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
    }
  }
}
