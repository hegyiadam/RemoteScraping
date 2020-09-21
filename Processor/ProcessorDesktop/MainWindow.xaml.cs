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
        public MainWindow()
        {
            InitializeComponent();
            Closing += CloseHandler;
            HubConnector.Start();
            Executable execution = new Executable();
            execution.find_tag_by_css_selector("https://stackoverflow.com/questions/24801548/how-to-use-css-selectors-to-retrieve-specific-links-lying-in-some-class-using-be", "#answer-24801950 > div > div.answercell.post-layout--right > div.s-prose.js-post-body");
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
