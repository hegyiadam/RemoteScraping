using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BrowserManagement
{

    public delegate void ControlKeyHandler();
    public interface IBrowserWrapper
    {
        event ControlKeyHandler ControlKeyPressed;
        Control GetControl();
        void AutoHighlightControl();
        void RemoveAutoHighlightControl();
        void HighlightControl(string selector);
        void RemoveHighlightControl(string selector);
        Task<JavascriptResponse> GetElementOnMousePosition();
        Task<JavascriptResponse> GetSiblingsOnMousePosition();
    }
}
