using BrowserManagement.Wrappers.CefSharpWrapper;
using System;
using CefSharp.Wpf;

namespace BrowserManagement
{
    public static class BrowserWrapperFactory
    {
        private const string NOT_SUPPORTED_BROWSER = "This type is not supported!";

        public static IBrowserWrapper CreateBrowserWrapper<T>(T browser)
        {
            if (typeof(T) == typeof(ChromiumWebBrowser))
            {
                return new CefSharpWrapper(browser as ChromiumWebBrowser);
            }
            throw new InvalidOperationException(NOT_SUPPORTED_BROWSER);
        }
    }
}