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
    public int TimeId { get; set; }

    ///<value> Employee id, foreign key </value>
    public int EmployeeId { get; set; }

    ///<value> Employee asociated with time </value>
    public Employee Employee { get; set; }

    ///<value> Time of work start </value>
    public DateTime StartDate { get; set; }

    ///<value> Time of work end </value>
    public DateTime EndDate { get; set; }
  }
}