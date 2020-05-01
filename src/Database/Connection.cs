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

    /// <summary>
    /// Constructor establishing connection
    /// </summary>
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
      string[] connectionStringLines = System.IO.File.ReadAllLines(@".\connection.txt");
      string Id = connectionStringLines[0];
      string Password = connectionStringLines[1];
      string Host = connectionStringLines[2];
      string Port = connectionStringLines[3];
      string ServiceName = connectionStringLines[4];
      connection.ConnectionString = "User Id=" + Id + ";Password=" + Password + ";Data Source=" + Host + ":" + Port + "/" + ServiceName;
      try
      {
        if (connection.State == ConnectionState.Closed)
          connection.Open();
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

    /// <summary>
    /// Destructor. Close connection with database
    /// </summary>
    ~Connection()
    {
      connection.Close();
      connection.Dispose();
    }
  }
}