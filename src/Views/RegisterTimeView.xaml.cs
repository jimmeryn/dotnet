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
using System.Windows.Threading;

namespace WorkHoursTracker.Views
{
  /// <summary>
  /// Interaction logic for RegisterTimeView.xaml
  /// </summary>
  public partial class RegisterTimeView : UserControl
  {
    public RegisterTimeView()
    {
      InitializeComponent();
      StartClock();
    }

    private void StartClock()
    {
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromSeconds(1);
      timer.Tick += tickevent;
      timer.Start();
    }

    private void tickevent(object sender, EventArgs e)
    {
      datalbl.Text = DateTime.Now.ToString();
    }
  }
}
