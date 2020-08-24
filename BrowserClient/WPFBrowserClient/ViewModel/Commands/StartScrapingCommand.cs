using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFBrowserClient.View.Pages;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class StartScrapingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("dfsdf");
            WindowViewModel.Instance.ActualPage = new SiteScrapingPage()
            {
                DataContext = new RootSitePageViewModel()
            };
        }
    }
}
