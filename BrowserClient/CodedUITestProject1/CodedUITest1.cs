using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITestProject1
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        private const string PROCESSNAME = "WPFBrowserClient.exe";
        private UIScraperBrowserWindow window;
        private readonly Point PAGE_SELECTOR_POSITION = new Point(500, 730);
        private readonly Point LINK_SELECTOR_POSITION = new Point(500, 470);
        private readonly Point TAG_POSITION = new Point(500, 370);

        public CodedUITest1()
        {
            StartApplication();
            Mouse.MouseMoveSpeed = 10000;
        }

        private void StartApplication()
        {
            Process.Start(@"C:\WS\others\RemoteScrapingBranches\pcclient\BrowserClient\Deploy\" + PROCESSNAME);
            window = new UIScraperBrowserWindow();
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            Thread.Sleep(2000);
            ClickOnStartWebScraping();
            NavigationIteration();
            ClickIteration();
            GetElementAtMousePosition();
            ExecuteScraping();
        }

        private void ExecuteScraping()
        {
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UICommandListList.UIItemListItem3, ModifierKeys.None);
            Thread.Sleep(2000);
        }

        private void GetElementAtMousePosition()
        {
            NavigateToArticle();
            ClickOnGetElementAtMousePosition();
            SelectTag();
        }

        private void SelectTag()
        {
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, TAG_POSITION);
            Thread.Sleep(1000);
            Keyboard.PressModifierKeys(ModifierKeys.Control);
        }

        private void ClickOnGetElementAtMousePosition()
        {
            Thread.Sleep(4000);
            Mouse.Click(window.UIMainFramePane.UICommandListList.UIItemListItem2, ModifierKeys.None);
            Thread.Sleep(2000);
        }

        private void NavigateToArticle()
        {
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, new Point(1000, 600));
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, LINK_SELECTOR_POSITION);
            Thread.Sleep(2000);
        }

        private void ClickIteration()
        {
            ClickOnClickIterationTask();
            SelectArticleIteration();
        }

        private void NavigationIteration()
        {
            ClickOnNavigationIterationTask();
            SelectPageIteration();
        }

        private void SelectArticleIteration()
        {
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, new Point(1000, 600));
            Thread.Sleep(2000);
            Mouse.MouseMoveSpeed = 10000;
            Mouse.Move(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, LINK_SELECTOR_POSITION);
            Thread.Sleep(1000);
            Keyboard.PressModifierKeys(ModifierKeys.Control);
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UIYesButton2, ModifierKeys.None);
            Thread.Sleep(1000);
        }

        private void ClickOnClickIterationTask()
        {
            Thread.Sleep(4000);
            Mouse.Click(window.UIMainFramePane.UICommandListList.UIItemListItem1, ModifierKeys.None);
            Thread.Sleep(2000);
        }

        private void SelectPageIteration()
        {
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, new Point(1000, 600));
            Thread.Sleep(2000);
            Mouse.MouseMoveSpeed = 10000;
            Mouse.Move(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, PAGE_SELECTOR_POSITION);
            Thread.Sleep(1000);
            Keyboard.PressModifierKeys(ModifierKeys.Control);
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UIYesButton, ModifierKeys.None);
            Thread.Sleep(1000);
        }

        private void ClickOnNavigationIterationTask()
        {
            Thread.Sleep(4000);
            Mouse.Click(window.UIMainFramePane.UIOpenMenuButtonButton, ModifierKeys.None);
            Mouse.Click(window.UIMainFramePane.UICommandListList.UIItemListItem, ModifierKeys.None);
            Thread.Sleep(2000);
        }

        private void ClickOnStartWebScraping()
        {
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UIStartScrapingButton, ModifierKeys.None);
        }


        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
