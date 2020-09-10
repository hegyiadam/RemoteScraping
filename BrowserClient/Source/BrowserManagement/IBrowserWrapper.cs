using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserManagement
{
    public interface IBrowserWrapper
    {
        T GetBrowser<T>() where T : class;
        void HighlightControl();
        Task<JavascriptResponse> GetElementOnMousePosition();
    }
}
