namespace WPFBrowserClient.Model
{
    /*public class PageContainer
    {
		private static PageContainer _instance = null;
		private PageContainer()
		{
			CompositionManagement.CompositionHandler.Compose(typeof(ISingletonPage), this);
		}
		public static PageContainer Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PageContainer();
				}
				return _instance;
			}
		}

		[ImportMany]
		public ISingletonPage[] SingletonPages { get; set; }

		public T GetPage<T>()
		{
			foreach (ISingletonPage page in SingletonPages)
			{
				if(page is T)
				{
					return (T)page;
				}
			}
			throw new DllNotFoundException(typeof(T).AssemblyQualifiedName);
		}
	}*/
}