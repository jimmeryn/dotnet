using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorkHoursTracker.Models;

namespace WorkHoursTracker
{
  /// <summary>
  /// Data Base context class
  /// </summary>
  public class DataBaseContext : DbContext
  {
    ///<value> Employees set </value>
    public DbSet<Employee> Employees { get; set; }

    ///<value> Times set </value>
    public DbSet<Time> Times { get; set; }

    ///<value> Connection with database </value>
    public Connection connection = new Connection();

    /// <summary>
    /// Building model for database
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>().ToTable("Employee");
      modelBuilder.Entity<Time>().ToTable("Time");
    }

    /// <summary>
    /// Used when configuring database
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string[] connectionStringLines = System.IO.File.ReadAllLines(@".\connection.txt");
      string Id = connectionStringLines[0];
      string Password = connectionStringLines[1];
      string Host = connectionStringLines[2];
      string Port = connectionStringLines[3];
      string ServiceName = connectionStringLines[4];
      optionsBuilder.UseOracle(@"User Id=" + Id + ";Password=" + Password + ";Data Source=(DESCRIPTION = " +
          " (ADDRESS = (PROTOCOL = TCP)(HOST = " + Host + ")(PORT = " + Port + "))" +
          "(CONNECT_DATA =" +
          " (SERVER = DEDICATED)" +
          "(SERVICE_NAME = " + ServiceName + ")" +
          "));");
    }
  }
}