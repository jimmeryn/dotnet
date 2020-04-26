using WorkHoursTracker.Models;
using System;
using System.Linq;
using System.Net.Http;

namespace WorkHoursTracker.Data
{
  /// <summary>
  /// Initialize database class
  /// </summary>
  public static class DbInitializer
  {
    /// <summary>
    /// Used to initialize database
    /// </summary>
    public static void Initialize(DataBaseContext context)
    {
      context.Database.EnsureCreated();
      if (context.Employees.Any())
      {
        // json placeholder url
        string url = "http://panamint.ict.pwr.wroc.pl/~wkrzesaj/dotnet_data/db.json";
        GetDataFromUrl(url);
        return;
      }
      else
      {
        // TODO: get employees from json file/ json.placeholder
        var Employees = new Employee[] { new Employee { Name = "Jonh", Surname = "Smith", JobTitle = "Worker" } };
        foreach (Employee employee in Employees)
        {
          context.Employees.Add(employee);
        }
        context.SaveChanges();
      }
    }

    /// <summary>
    /// Used to fetch data from url
    /// </summary>
    private static async void GetDataFromUrl(string url)
    {
      Console.WriteLine("Getting data from: " + url);
      try
      {
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage res = await client.GetAsync(url))
        using (HttpContent content = res.Content)
        {
          Console.WriteLine("Client: " + client + "res: " + res + "content: " + content);
          var data = await content.ReadAsStringAsync();
          if (data != null) Console.WriteLine(data);
          else Console.WriteLine("No Data");
        }


      }
      catch (Exception exception)
      {
        Console.WriteLine("Exception :" + exception);
      }
    }
  }
}