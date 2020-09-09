using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBrowserClient.Model
{
    public class ActualWebPage : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		private string url;


		private static ActualWebPage _instance = null;
		private ActualWebPage() { }
		public static ActualWebPage Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ActualWebPage();
				}
				return _instance;
			}
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
