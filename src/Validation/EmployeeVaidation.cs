using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkHoursTracker
{
  /// <summary>
  /// Employee validation class
  /// </summary>
  public static class EmployeeValidation
  {
    /// <summary>
    /// Employee validation
    /// </summary>
    public static bool Validate(string name, string surname)
    {
      using (var db = new DataBaseContext())
      {
        if (db.Employees.FirstOrDefault(user => user.Name == name && user.Surname == surname) == null)
          return false;
        else
          return true;
      }
    }
  }
}