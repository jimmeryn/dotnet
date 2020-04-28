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

using WorkHoursTracker.ViewModels;
using WorkHoursTracker.DataModels;

namespace WorkHoursTracker
{
  /// <summary>
  /// Interaction logic for HomeWindow.xaml
  /// </summary>
  public partial class HomeWindow : Window
  {
    /// <summary>
    /// Constructor initializing Home window component 
    /// </summary> 
    public HomeWindow()
    {
      InitializeComponent();
      DataContext = new HelloViewModel();
      DataModelObject FullNameContext = new DataModelObject() { FullName = ((App)Application.Current).Name + ((App)Application.Current).Surname };
      LoggedAs.DataContext = FullNameContext;
    }

    public void LogOutButtonClicked(object sender, RoutedEventArgs e)
    {
      MainWindow window = new MainWindow();
      window.Show();
      this.Close();
    }

    private void RegisterTimeViewButtonClicked(object sender, RoutedEventArgs e)
    {
      DataContext = new RegisterTimeViewModel();
    }

    private void StatsViewButtonClicked(object sender, RoutedEventArgs e)
    {
      DataContext = new StatsViewModel();
    }

    private void ExitButtonClicked(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

  }
}
