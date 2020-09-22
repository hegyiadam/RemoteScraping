using HubHandling;
using PythonExecution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ProcessorDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Executable execution;
        public MainWindow()
        {
            InitializeComponent();
            Closing += CloseHandler;
            HubConnector.Start();
            execution = new Executable();
            HubConnector.SubscribeToDownloadSelector(downloadSelectorHandler);
        }

        private void downloadSelectorHandler(string selector)
        {
            execution.find_tag_by_css_selector("http://127.0.0.1:5000/", selector);
        }

        private void CloseHandler(object sender, CancelEventArgs e)
        {
            HubConnector.Stop();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            HubConnector.SendCommand();
        }

    }
}
