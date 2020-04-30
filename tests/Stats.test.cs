using Xunit;
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

using Microsoft.EntityFrameworkCore;

using WorkHoursTracker.Models;

namespace WorkHoursTracker.Test
{
  /// <summary>
  /// Employee class tests
  /// </summary>  
  public class Stats
  {
    /// <summary>
    /// TimeSpanToHours basic test
    /// </summary>
    [Fact]
    public void TimeSpanToHoursTest()
    {
      Assert.Equal("123:43", TimeSpanToHours(new TimeSpan(123, 43, 0)));
    }

    /// <summary>
    /// GetCurrentUserTime basic return type test
    /// </summary>
    [Fact]
    public void GetCurrentUserTimeTypeTest()
    {
      Assert.IsType<List<Time>>(GetCurrentUserTimes());
    }

    /// <summary>
    /// GetCurrentUserTime basic return type test
    /// </summary>
    [Fact]
    public void GetCurrentUserTimeTest()
    {
      Assert.IsType<DateTime>(GetCurrentUserTimes()[0].StartDate);
      Assert.IsType<DateTime>(GetCurrentUserTimes()[0].EndDate);
      Assert.IsType<int>(GetCurrentUserTimes()[0].EmployeeId);
    }

    /// <summary>
    /// GetCurrentUserTime basic return type test
    /// </summary>
    [Fact]
    public void GetCurrentMonthTimeTest()
    {
      Assert.Equal("48:00", CalculateTime(GetYearTimes(DateTime.Now.Year)));
    }




    /// FUNCTIONS TO TEST
    private string CalculateTime(List<Time> times)
    {
      return TimeSpanToHours(new TimeSpan(times.Select(time => time.EndDate.Subtract(time.StartDate)).Sum(r => r.Ticks)));
    }

    private List<Time> GetCurrentUserTimes()
    {
      return new List<Time>(){
        new Time {
          EmployeeId = 4,
          StartDate = DateTime.Now.AddDays(-2),
          EndDate = DateTime.Now,
        }
      };
    }

    private List<Time> GetMonthTimes(int month, int year)
    {
      return GetCurrentUserTimes()
        .FindAll(time =>
          time.StartDate.Month == month &&
          time.StartDate.Year == year);
    }

    private List<Time> GetYearTimes(int year)
    {
      return GetCurrentUserTimes()
        .FindAll(time =>
          time.StartDate.Year == year);
    }


    private string TimeSpanToHours(TimeSpan time)
    {
      return string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
    }
  }
}