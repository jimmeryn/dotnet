using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkHoursTracker.Models;

using WorkHoursTracker.ViewModels;

namespace WorkHoursTracker
{
  /// <summary>
  /// Interaction logic for HomeWindow.xaml
  /// </summary>
  public partial class SingUpWindow : Window
  {
    /// <summary>
    /// Constructor initializing Home window component 
    /// </summary> 
    public SingUpWindow()
    {
      InitializeComponent();
    }

    ///<summary>
    /// Go back to log in window.
    ///</summary>
    public void LogInButtonClicked(object sender, RoutedEventArgs e)
    {
      MainWindow window = new MainWindow();
      window.Show();
      this.Close();
    }

    ///<summary>
    /// Get user data to creating new user. 
    ///</summary>
    public void SingUpButtonClicked(object sender, RoutedEventArgs e)
    {
      if (EmployeeValidation.NewValidate(EmployeeName.Text, EmployeeSurname.Text, EmployeeJobTitle.Text))
      {
        MessageBox.Show("Singed Up as: " + EmployeeName.Text + " " + EmployeeSurname.Text + " " + EmployeeJobTitle.Text);
        AddNewEmployee(EmployeeName.Text, EmployeeSurname.Text, EmployeeJobTitle.Text);
        MainWindow window = new MainWindow();
        window.Show();
        this.Close();
      }
      else
        MessageBox.Show("Could not sing up. Invalid data");
    }

    ///<summary>
    /// Add new employee to database.
    ///</summary>
    private void AddNewEmployee(string name, string surname, string jobTitle)
    {
      using (var context = new DataBaseContext())
      {
        context.Database.EnsureCreated();
        var employee = new Employee { Name = name, Surname = surname, JobTitle = jobTitle };
        context.Employees.Add(employee);
        context.SaveChanges();
      }
    }
  }
}
