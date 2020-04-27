﻿using System;
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

namespace WorkHoursTracker
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    /// <summary>
    /// Constructor initializing main window component 
    /// </summary> 
    public MainWindow()
    {
      InitializeComponent();
    }

    public void LogInButtonClicked(object sender, RoutedEventArgs e)
    {
      if (EmployeeValidation.Validate(EmployeeName.Text, EmployeeSurname.Text) || true /* FOR DEVELOPMENT*/)
      {
        HomeWindow window = new HomeWindow();
        window.Show();
        this.Close();
      }
      else
        MessageBox.Show("Cannot login as " + EmployeeName.Text + " " + EmployeeSurname.Text);
    }

  }
}
