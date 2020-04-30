using System;

namespace WorkHoursTracker.DataModels
{
  /// <summary>
  /// DataModelObject used to store data calculated from database localy.
  /// <seealso cref="WorkHoursTracker.Models.Time"/>
  /// </summary>
  public class TimeModelObject
  {
    /// <value> Month time spend in work of currend logged employee </value>
    /// <seealso cref="WorkHoursTracker.Views.StatsView"/>
    public string MonthTime { get; set; }

    /// <value> Year time spend in work of currend logged employee </value>
    /// <seealso cref="WorkHoursTracker.Views.StatsView"/>
    public string YearTime { get; set; }
  }
}