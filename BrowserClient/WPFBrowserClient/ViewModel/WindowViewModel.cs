using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.Pages;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class WindowViewModel
    {
		private static WindowViewModel _instance = null;
		private WindowViewModel() { }
		public static WindowViewModel Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new WindowViewModel();
				}
				return _instance;
			}
		}


		private Page actualPage = new RootSitePage()
		{
			DataContext = new RootSitePageViewModel()
		};

		public Page ActualPage
		{
			get { return actualPage; }
			set
			{
				actualPage = value;
				OnPropertyChanged("ActualPage");
			}
		}

		public ICommand StartScrapingCommand 
		{ 
			get
			{
				return new StartScrapingCommand();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
    }
}
