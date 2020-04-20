using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace WorkHoursTracker
{
  /// <summary>
  /// Establish connection with database
  /// </summary>
  public class Connection
  {
    private OracleConnection connection;

    public Connection()
    {
      Connect();
    }
    /// <summary>
    /// Method to establish connection to Oracle database
    /// </summary>
    private void Connect()
    {
      connection = new OracleConnection();
      connection.ConnectionString = "User Id=test;Password=test;Data Source=localhost:1521/xe";
      try
      {
        if (connection.State == ConnectionState.Closed)
        {
          connection.Open();
          Console.WriteLine("Connected to Oaracle: " + connection.ServerVersion);
          Console.WriteLine("State: " + connection.State);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        Console.WriteLine("Cannot connect to Oaracle DataBase");
        connection.Dispose();
        connection.Close();
      }
      finally
      {
        connection.Close();
      }
    }

    /// <summary>
    /// Method to close connection to Oracle database
    /// </summary>
    private void Disconnect()
    {
      connection.Close();
      connection.Dispose();
    }

    ~Connection()
    {
      connection.Close();
      connection.Dispose();
    }

    /// <summary>
    /// Method to read data from oracle db
    /// </summary>
    public void ReadData()
    {
      Console.WriteLine("ReadingDataFromDataBase!");
      // jakies zapytania do oracle db w stylu From * Table ...
      Console.WriteLine("ENDEDReadingDataFromDataBase!");
    }
  }
}