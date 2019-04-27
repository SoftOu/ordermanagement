using log4net;
using System;
using System.Linq;
using System.Windows;

namespace OrderManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ILog log = LogManager.GetLogger("Order");
        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Log started");
            base.OnStartup(e);
        }
    }
}
