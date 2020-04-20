using System;

namespace WorkHoursTracker
{
  /// <summary>
  /// Employee model 
  /// </summary>
  public partial class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string JobTitle { get; set; } // shoud be changed to enum type 
  }
}