using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text.RegularExpressions;

namespace WorkHoursTracker
{
  /// <summary>
  /// Employee validation class
  /// </summary>
  public static class EmployeeValidation
  {
    /// <summary>
    /// Employee data validation.false Used to log in.
    /// </summary>
    public static bool Validate(string name, string surname)
    {
      StringValidator stringValidator = new StringValidator(2, 20);
      try
      {
        stringValidator.Validate(name);
        stringValidator.Validate(surname);
        using (var db = new DataBaseContext())
        {
          if (db.Employees.FirstOrDefault(user =>
          user.Name == name &&
          user.Surname == surname) != null &&
          Regex.IsMatch(name, @"^[a-zA-Z]+$") &&
          Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            return true;
          else
            return false;
        }
      }
      catch (ArgumentException e)
      {
        Console.WriteLine(e);
        return false;
      }
    }
    ///<summary>
    /// Validate new employee data. Used to sing in.
    ///</summary>
    public static bool NewValidate(string name, string surname, string jobTitle)
    {
      StringValidator stringValidator = new StringValidator(2, 20);
      try
      {
        if (Regex.IsMatch(name, @"^[a-zA-Z]+$") && Regex.IsMatch(surname, @"^[a-zA-Z]+$") && Regex.IsMatch(jobTitle, @"^[a-zA-Z]+$"))
        {

          stringValidator.Validate(name);
          stringValidator.Validate(surname);
          stringValidator.Validate(jobTitle);
          using (var db = new DataBaseContext())
          {
            if (db.Employees.FirstOrDefault(user => user.Name == name && user.Surname == surname) == null)
              return true;
            else
              return false;
          }
        }
        else
          return false;
      }
      catch (ArgumentException e)
      {
        Console.WriteLine(e);
        return false;
      }
    }
  }
}