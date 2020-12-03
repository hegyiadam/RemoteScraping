using HubHandling;
using ProcessorDesktop.ViewModel;
using PythonExecution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
        public MainWindowViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
            Closing += ViewModel.CloseHandler;
            ViewModel.StartHandler();
        }

        private void MasterConnection_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ConnectToMaster();
        }

        private void ProcessorConnection_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DetectProcessor();
        }
    }
}
