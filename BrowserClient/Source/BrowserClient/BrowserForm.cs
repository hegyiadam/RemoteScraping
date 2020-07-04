using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserClient
{
    public partial class BrowserClientForm : Form
    {
        public string URL { get; set; } = "www.google.co.uk";
        public string InitTextOfTextBox { get; set; } = "Press CTRL to get infos about a control";

        public BrowserClientForm()
        {
            InitializeComponent();
            InitializeControls();
            InitialProcesses();
        }

        private void InitializeControls()
        {
            URLTextBox.Text = URL;
            URLTextBox.TextChanged += ReadURL;
            logTextBox.Text = InitTextOfTextBox;
        }

        private void InitialProcesses()
        {
            NavigateToURL();
        }

        private void NavigateToURL()
        {
            webBrowser.Navigate(URL);
        }

        private void ReadURL(object sender, EventArgs e)
        {
            URL = URLTextBox.Text;
        }
        private void DumpLog(string logMessage)
        {
            logTextBox.Text = logMessage;
            Console.WriteLine(logMessage);
            Debug.Write(logMessage);
        }

        private void URLTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (KeyIsEnter(e))
            {
                NavigateToURL();
            }
        }

        private void KeyPressedOnWebBrowser(object sender, PreviewKeyDownEventArgs e)
        {
            if (KeyIsCTRL(e))
            {
                InspectElementOnMousePosition();
            }
        }


        private Point GetMousePositionOnPage()
        {
            Point point = Cursor.Position;
            Point relativePosition = webBrowser.PointToClient(point);
            return relativePosition;
        }




        private bool KeyIsCTRL(PreviewKeyDownEventArgs keyEvent)
        {
            return keyEvent.Control == true;
        }
        private bool KeyIsEnter(KeyEventArgs keyEvent)
        {
            return keyEvent.KeyValue == 13;
        }

        private void InspectElementOnMousePosition()
        {
            HtmlElement element = GetHtmlElementOnMousePosition();
            HandleHtmlElement(element);
        }

        private void HandleHtmlElement(HtmlElement element)
        {
            string logMessage = GetInfosAboutHtmlElement(element);
            DumpLog(logMessage);
        }

        private string GetInfosAboutHtmlElement(HtmlElement element)
        {
            if (element != null)
            {
                return CreateInfoString(element);
            }
            else
            {
                return "No element was found!";
            }
        }

        private HtmlElement GetHtmlElementOnMousePosition()
        {
            Point point = GetMousePositionOnPage();
            return webBrowser.Document.GetElementFromPoint(point);
        }

        private string CreateInfoString(HtmlElement htmlElement)
        {
            return
                TitleToString("element " + GetMousePositionOnPage()) +
                PropertyWithToString("Name", htmlElement.Name) +
                PropertyWithToString("Id", htmlElement.Id) +
                PropertyWithToString("TagName", htmlElement.TagName) +
                PropertyWithToString("DomElement", htmlElement.DomElement) +
                TitleToString("attributes") +
                PropertyWithToString("Id", htmlElement.GetAttribute("id")) +
                PropertyWithToString("Classname", htmlElement.GetAttribute("className"));
        }
        private string TitleToString(string title)
        {
            return "\n\t**" + title.ToUpper() + "**\n\n";
        }
        private string PropertyWithToString(string name, object value)
        {
            return name + " : " + value + ";\n";
        }

    }
}
