using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkHoursTracker.Models
{
  /// <summary>
  /// Employee model 
  /// </summary>
  public partial class Employee
  {
    public Employee()
    {
      this.Times = new HashSet<Time>();
    }

    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string JobTitle { get; set; } // shoud be changed to enum type 
    public virtual ICollection<Time> Times { get; set; }
  }
}