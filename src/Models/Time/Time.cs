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
    ///<value> Time Id </value>
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int TimeID { get; set; }

    ///<value> Employee id, foreign key </value>
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    ///<value> Employee asociated with time </value>
    public virtual Employee Employee { get; set; }

    ///<value> Time of work start </value>
    public DateTime StartDate { get; set; }

    ///<value> Time of work end </value>
    public DateTime EndDate { get; set; }
  }
}