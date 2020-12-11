using HubHandling;
using System.Windows;

namespace ProcessorDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ExecutionStack.StartExecution(this.Dispatcher);
        }
    }
}