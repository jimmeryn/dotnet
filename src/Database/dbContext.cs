using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorkHoursTracker.Models;

namespace WorkHoursTracker
{
  public class DataBaseContext : DbContext
  {
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {

    }
    public DbSet<Employee> employees { get; set; }
    public DbSet<Time> times { get; set; }

    public Connection connection = new Connection();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>().ToTable("Employee");
      modelBuilder.Entity<Time>().ToTable("Time");
    }

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