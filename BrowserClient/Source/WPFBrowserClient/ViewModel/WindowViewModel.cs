using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.Pages;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class WindowViewModel
    {
        public static Page ActualPage { get; set; } = PageContainer.Instance.GetPage<RootSitePage>();

        public static Frame MainFrame
        {
            get
            {
                return MainWindow.FindName("mainFrame") as Frame;

            }
        }

        public static Window MainWindow
        {
            get
            {
                return Application.Current.MainWindow;

            }
        }
    }
}
