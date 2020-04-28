using System;
using System.Windows;
using System.Windows.Controls;
using WorkHoursTracker.DataModels;

namespace WorkHoursTracker.Views
{
  /// <summary>
  /// Interaction logic for HelloView.xaml
  /// </summary>
  public partial class HelloView : UserControl
  {
    public HelloView()
    {
      InitializeComponent();
      DataModelObject FullNameContext = new DataModelObject() { Name = ((App)Application.Current).Name, Surname = ((App)Application.Current).Surname, JobTitle = "Worker" };
      UserDataName.DataContext = FullNameContext;
      UserDataSurname.DataContext = FullNameContext;
      UserDataJobTitle.DataContext = FullNameContext;
    }
  }
}
