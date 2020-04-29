using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using WorkHoursTracker.Models;

namespace WorkHoursTracker.Parsing
{
  public class DataObjecFromJson
  {
    ///<value> Employees array. Look at data context </value>
    public Employee[] Employees;

    ///<value> Times array. Look at data context </value>    
    public Time[] Times;

    ///<summary>
    /// Adding data from current object to database
    ///</summary>
    public void AddToDatabase(DataBaseContext context)
    {
      foreach (var employee in Employees)
        context.Employees.Add(employee);

      foreach (var time in Times)
        context.Times.Add(time);

      context.SaveChanges();
    }
  }
}