using System.Configuration;
using System.Data;
using System.Windows;
using SharedLibrary.Models;

namespace StudSim
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Apiservice service { get; private set;  }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            service = new Apiservice();
        }
    }

}
