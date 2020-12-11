using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using MongoDB.Bson;
using MongoDB.Driver;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Point = System.Drawing.Point;

namespace CodedUITestProject1
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class ScrapingWorkflowTests
    {
        private const string PROCESSNAME = "WPFBrowserClient.exe";
        private const int ServerPort = 3333;
        private readonly Point LINK_SELECTOR_POSITION = new Point(500, 470);
        private readonly Point PAGE_SELECTOR_POSITION = new Point(500, 730);
        private readonly Point TAG_POSITION = new Point(500, 370);
        private UIMap map;
        private string sessionId;
        private TestContext testContextInstance;
        private UIScraperBrowserWindow window;

        public ScrapingWorkflowTests()
        {
            StartApplication();
        }

        public string BrowserComponentLauncherPath => ConfigurationManager.AppSettings["BrowserComponentLauncherPath"];
        public string MasterComponentLauncherPath => ConfigurationManager.AppSettings["MasterComponentLauncherPath"];
        public string ProcessorComponentLauncherPath => ConfigurationManager.AppSettings["ProcessorComponentLauncherPath"];

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

        [TestMethod]
        public void Scenario1_Test()
        {
            int expectedResultCount = 10;

            ClickOnStartWebScraping();
            NavigationIteration();
            ClickIteration();
            GetElementAtMousePosition();
            ExecuteScraping();
            WaitForResult();

            int numberOfResults = GetNumberOfResults();
            Assert.AreEqual(expectedResultCount, numberOfResults);
        }

        private void ClickIteration()
        {
            ClickOnClickIterationTask();
            SelectArticleIteration();
        }

        private void ClickOnClickIterationTask()
        {
            Thread.Sleep(4000);
            Mouse.Click(window.UIMainFramePane.UICommandListList.UIItemListItem1, ModifierKeys.None);
            Thread.Sleep(2000);
        }

        private void ClickOnGetElementAtMousePosition()
        {
            Thread.Sleep(4000);
            Mouse.Click(window.UIMainFramePane.UICommandListList.UIItemListItem2, ModifierKeys.None);
            Thread.Sleep(2000);
        }

        private void ClickOnNavigationIterationTask()
        {
            Thread.Sleep(4000);
            Mouse.Click(
                window.UIMainFramePane.UIOpenMenuButtonButton,
                ModifierKeys.None);
            Mouse.Click(
                window.UIMainFramePane.UICommandListList.UIItemListItem,
                ModifierKeys.None);
            Thread.Sleep(2000);
        }

        private void ClickOnStartWebScraping()
        {
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UIStartScrapingButton, ModifierKeys.None);
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

        private string GetLastSessionId()
        {
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017/");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("RemoteScrape");
            IMongoCollection<BsonDocument> masteridCollection = mongoDatabase.GetCollection<BsonDocument>("masterids");
            return masteridCollection.Find<BsonDocument>(_ => true).ToList().Last()["Id"].ToString();
        }

        private int GetNumberOfResults()
        {
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017/");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("RemoteScrape");
            IMongoCollection<BsonDocument> resultCollection = mongoDatabase.GetCollection<BsonDocument>("result");
            return Convert.ToInt32(resultCollection.Find(x => x["SessionId"] == sessionId).Count());
        }

        private void NavigateToArticle()
        {
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, new Point(1000, 600));
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, LINK_SELECTOR_POSITION);
            Thread.Sleep(2000);
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

        private void SelectPageIteration()
        {
            Mouse.Click(
                window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage,
                new Point(1000, 600));
            Thread.Sleep(2000);
            Mouse.MouseMoveSpeed = 10000;
            Mouse.Move(
                window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage,
                PAGE_SELECTOR_POSITION);
            Thread.Sleep(1000);
            Keyboard.PressModifierKeys(ModifierKeys.Control);
            Thread.Sleep(2000);
            Mouse.Click(window.UIMainFramePane.UIYesButton, ModifierKeys.None);
            Thread.Sleep(1000);
        }

        private void SelectTag()
        {
            Mouse.Click(window.UIMainFramePane.UIBrowserUserControlCustom.UIPART_imageImage, TAG_POSITION);
            Thread.Sleep(1000);
            Keyboard.PressModifierKeys(ModifierKeys.Control);
        }

        private void StartApplication()
        {
            sessionId = GetLastSessionId();
            Process.Start(MasterComponentLauncherPath);
            Thread.Sleep(2000);
            Process.Start(ProcessorComponentLauncherPath);
            Thread.Sleep(2000);
            Process.Start(BrowserComponentLauncherPath);
            Thread.Sleep(2000);
            window = new UIScraperBrowserWindow();
        }

        private void WaitForResult()
        {
            Thread.Sleep(120000);
        }
    }
}