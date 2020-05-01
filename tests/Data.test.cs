using Xunit;
using System;

using WorkHoursTracker.Data;

namespace WorkHoursTracker.Test
{
  public class DataTest
  {
    /// <summary>
    /// Used to fetch data from url
    ///<seealso cref="DbInitializer.GetDataFromUrl(string)"/>
    /// </summary>
    private static string GetDataFromUrl(string url)
    {
      using (var webClient = new System.Net.WebClient())
        return webClient.DownloadString(url);
    }

    [Theory]
    [InlineData("http://panamint.ict.pwr.wroc.pl/~wkrzesaj/dotnet_data/db.json")]
    public void InitialDataTypeTest(string url)
    {
      Assert.IsType<string>(GetDataFromUrl(url));
    }
  }
}