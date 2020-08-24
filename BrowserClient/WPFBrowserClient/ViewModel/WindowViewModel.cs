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

        public Page ActualPage { get; set; } = new RootSitePage();

        public static Frame MainFrame
        {
            get
            {
                return (Frame)Application.Current.MainWindow.FindName("mainFrame");

            }
        }

	}
}
