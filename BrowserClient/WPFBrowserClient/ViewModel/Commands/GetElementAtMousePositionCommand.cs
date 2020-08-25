using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class GetElementAtMousePositionCommand : ICommand
    {
        private ChromiumWebBrowser chromiumWebBrowser;

        public GetElementAtMousePositionCommand(ChromiumWebBrowser chromiumWebBrowser)
        {
            this.chromiumWebBrowser = chromiumWebBrowser;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            Thread thread = new Thread(
                () =>
                {
                    string elementOnPos = "document.onclick = function(e) {var x = event.clientX, y = event.clientY, elementMouseIsOver = document.elementFromPoint(x, y);        elementMouseIsOver.style.border = \"thick solid #0000FF\";  };";
                    chromiumWebBrowser.EvaluateScriptAsync(elementOnPos);
                });

            thread.Start();
        }
    }
}
