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
        MonthTime = TimeSpanToString(CalculateMonthTime(DateTime.Now.Month)),
        YearTime = TimeSpanToString(CalculateYearTime()),
      };
      ThisMonthTime.DataContext = StatsContext;
      ThisYearTime.DataContext = StatsContext;

      SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Hours: ",
                    Values = new ChartValues<int> { TimeSpanToHours(CalculateMonthTime(1)),
                      TimeSpanToHours(CalculateMonthTime(2)),
                      TimeSpanToHours(CalculateMonthTime(3)),
                      TimeSpanToHours(CalculateMonthTime(4)),
                      TimeSpanToHours(CalculateMonthTime(5)),
                      TimeSpanToHours(CalculateMonthTime(6)),
                      TimeSpanToHours(CalculateMonthTime(7)),
                      TimeSpanToHours(CalculateMonthTime(8)),
                      TimeSpanToHours(CalculateMonthTime(9)),
                      TimeSpanToHours(CalculateMonthTime(10)),
                      TimeSpanToHours(CalculateMonthTime(11)),
                      TimeSpanToHours(CalculateMonthTime(12)) }
                }
            };
      Labels = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
      Formatter = value => value.ToString("N");

      DataContext = this;
    }

    public SeriesCollection SeriesCollection { get; set; }
    public string[] Labels { get; set; }
    public Func<double, string> Formatter { get; set; }

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
    private string TimeSpanToString(TimeSpan time)
    {
      return string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
    }

    ///<summary>
    /// Convert Time Span to string in fromat hours:minutes
    ///</summary>
    private int TimeSpanToHours(TimeSpan time)
    {
      return (int)time.TotalHours;
    }


  }
}
