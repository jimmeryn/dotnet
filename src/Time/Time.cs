using System;

namespace WorkHoursTracker
{
  /// <summary>
  /// Time model 
  /// </summary>
  public partial class Time
  {
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}