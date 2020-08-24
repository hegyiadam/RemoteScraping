using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBrowserClient.Model
{
    public class ActualPage : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		private string url;


		public ActualPage(string actualUrl)
		{
			url = actualUrl;
		}


		public string URL
		{
			get { return url; }
			set
			{
				url = value;
				OnPropertyChanged("URL");
			}
		}


		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
