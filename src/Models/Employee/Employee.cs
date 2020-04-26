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
    /// <summary>
    /// Employee constructor.
    /// Creating empty Times hash set
    /// </summary>
    public Employee()
    {
      this.Times = new HashSet<Time>();
    }

    ///<value> Employee key, auto generated </value>
    public int EmployeeID { get; set; }

    ///<value> Employee name </value>
    public string Name { get; set; }

    ///<value> Employee surname </value>
    public string Surname { get; set; }

    ///<value> Employee job title </value>
    public string JobTitle { get; set; } // shoud be changed to enum type 

    ///<value> collection of time for Employee </value>
    public virtual ICollection<Time> Times { get; set; }
  }
}