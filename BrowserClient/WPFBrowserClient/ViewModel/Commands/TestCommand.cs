using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class TestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public string Msg { get; set; }

        public TestCommand(string msg)
        {
            Msg = msg;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show(Msg);
        }
    }
}
