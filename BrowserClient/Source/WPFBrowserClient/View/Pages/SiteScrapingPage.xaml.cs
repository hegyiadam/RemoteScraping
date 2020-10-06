﻿using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.UserControls;
using WPFBrowserClient.ViewModel;

namespace WPFBrowserClient.View.Pages
{
    /// <summary>
    /// Interaction logic for SiteScrapingPage.xaml
    /// </summary>
    public partial class SiteScrapingPage : Page, ISingletonPage
    {
        public SiteScrapingPage()
        {
            InitializeComponent();

            ChromiumWebBrowser browser = FindName("browser") as ChromiumWebBrowser;
            DataContext = new SiteScrapingPageViewModel(this,browser);
        }


        private void OpenMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Collapsed;
            CloseMenuButton.Visibility = Visibility.Visible;
        }

        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenuButton.Visibility = Visibility.Collapsed;
            OpenMenuButton.Visibility = Visibility.Visible;

        }

    }
}
