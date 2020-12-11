using System.Threading.Tasks;
using System.Windows.Controls;
using CefSharp;

namespace BrowserManagement
{
    public delegate void ControlKeyHandler();

    public interface IBrowserWrapper
    {
        event ControlKeyHandler ControlKeyPressed;

        void AutoHighlightControl();

        Control GetControl();

        Task<JavascriptResponse> GetElementOnMousePosition();

        Task<JavascriptResponse> GetSiblingsOnMousePosition();

        void HighlightControl(string selector);

        void RemoveAutoHighlightControl();

        void RemoveHighlightControl(string selector);
    }
}