using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFBrowserClient.View.Pages;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class StartScrapingCommand : ICommand
    {
        private Page targetPage;

        public StartScrapingCommand(Page toPage)
        {
            this.targetPage = toPage;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            WindowViewModel.MainFrame.Navigate(targetPage);
        }
    }
}
