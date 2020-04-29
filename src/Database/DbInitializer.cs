using WorkHoursTracker.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using WorkHoursTracker.Parsing;

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
      if (context.Employees.Any())
      {
        return;
      }
      else
      {
        // json placeholder url
        string url = "http://panamint.ict.pwr.wroc.pl/~wkrzesaj/dotnet_data/db.json";
        var data = GetDataFromUrl(url);
        DataObjecFromJson objectFromJson = JsonConvert.DeserializeObject<DataObjecFromJson>(data);
        objectFromJson.AddToDatabase(context);
      }
    }

    /// <summary>
    /// Used to fetch data from url
    /// </summary>
    private static string GetDataFromUrl(string url)
    {
      using (var webClient = new System.Net.WebClient())
        return webClient.DownloadString(url);
    }
  }
}