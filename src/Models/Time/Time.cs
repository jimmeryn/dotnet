using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkHoursTracker.Models
{
  /// <summary>
  /// Time model 
  /// </summary>
  public class Time
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int TimeID { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}