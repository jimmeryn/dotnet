using System;

namespace WorkHoursTracker.DataModels
{
  /// <summary>
  /// DataModelObject used to store data from database localy.
  /// <seealso cref="WorkHoursTracker.Models.Employee"/>
  /// </summary>
  public class DataModelObject
  {
    ///<value> Employee Name </value>
    /// <seealso cref="WorkHoursTracker.Models.Employee.Name"/>
    public string Name { get; set; }

    ///<value> Employee Surname </value>
    /// <seealso cref="WorkHoursTracker.Models.Employee.Surname"/>
    public string Surname { get; set; }

    ///<value> Employee Full name with contains Name and Surname </value>
    /// <seealso cref="WorkHoursTracker.Models.Employee.Name"/>
    /// <seealso cref="WorkHoursTracker.Models.Employee.Surname"/>
    public string FullName { get; set; }

    ///<value> Employee JobTitle </value>
    /// <seealso cref="WorkHoursTracker.Models.Employee.JobTitle"/>
    public string JobTitle { get; set; }
  }
}