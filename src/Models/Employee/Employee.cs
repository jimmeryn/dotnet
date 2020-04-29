using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkHoursTracker.Models
{
  /// <summary>
  /// Employee model 
  /// </summary>
  public partial class Employee
  {
    /// <summary>
    /// Employee constructor.
    /// Creating empty Times hash set
    /// </summary>
    public Employee()
    {
      Times = new HashSet<Time>();
    }

    ///<value> Employee key, auto generated </value>
    public int EmployeeId { get; set; }

    ///<value> Employee name </value>
    [Required]
    public string Name { get; set; }

    ///<value> Employee surname </value>
    [Required]
    public string Surname { get; set; }

    ///<value> Employee job title </value>
    [Required]
    public string JobTitle { get; set; } // shoud be changed to enum type 

    ///<value> Collection of time for Employee </value>
    public ICollection<Time> Times { get; set; }

    ///<value> Curent time id (if Employee currently working) </value>
    public int? CurrentTimeId { get; set; }
  }
}