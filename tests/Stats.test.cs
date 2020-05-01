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
  /// Stats class tests
  /// <see cref="WorkHoursTracker.Views.StatsView"/>
  /// </summary>  
  public class Stats
  {
    ///<summary>
    /// Convert Time Span to string in fromat hours:minutes
    /// <see cref="WorkHoursTracker.Views.StatsView.TimeSpanToString(TimeSpan)"/>
    ///</summary>
    private string TimeSpanToString(TimeSpan time)
    {
      return string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
    }

    ///<summary>
    /// Convert Time Span to string in fromat hours:minutes
    /// <see cref="WorkHoursTracker.Views.StatsView.TimeSpanToHours(TimeSpan)"/>
    ///</summary>
    private int TimeSpanToHours(TimeSpan time)
    {
      return (int)time.TotalHours > 0 ? (int)Math.Ceiling((double)time.TotalHours) : 0;
    }

    [Fact]
    public void TimeSpanToHoursBasicTest()
    {
      var interval = new DateTime(2020, 1, 3) - new DateTime(2020, 1, 1);
      Assert.Equal(48, TimeSpanToHours(interval));
    }

    [Fact]
    public void TimeSpanToHoursBasicZeroTest()
    {
      var interval = new DateTime(2020, 1, 3) - new DateTime(2020, 1, 6);
      Assert.Equal(0, TimeSpanToHours(interval));
    }

    [Fact]
    public void TimeSpanToStringBasicTest()
    {
      var interval = new DateTime(2020, 1, 3) - new DateTime(2020, 1, 1);
      Assert.Equal("48:00", TimeSpanToString(interval));
    }
  }
}