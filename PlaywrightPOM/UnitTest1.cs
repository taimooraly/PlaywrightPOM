using Microsoft.CodeAnalysis;
using Microsoft.Playwright;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace PlaywrightPOM
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        public const string DataSourceXML = "Microsoft.VisualStudio.TestTools.DataSource.XML";
        public const string DataSourceCSV = "Microsoft.VisualStudio.TestTools.DataSource.CSV";

        [TestMethod]
        [TestCategory("Login")]   
        public async Task TestMethod1()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, Channel = "chrome" });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.FillAsync("#username", "AmirImam");
            await page.FillAsync("#password", "AmirImam");
            await page.ClickAsync("#login");

        }

        [TestMethod]
        [TestCategory("Login"), TestCategory("WebKit")]
        public async Task WebKit_Browser()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.FillAsync("#username", "AmirTester");
            await page.FillAsync("#password", "AmirTester");
            await page.ClickAsync("#login");
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task TestMethod_SaveState()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

            var context = await browser.NewContextAsync(); 
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.FillAsync("#username", "AmirImam");
            await page.FillAsync("#password", "AmirImam");
            await page.ClickAsync("#login");
            
            // Save storage state into the file.
            await context.StorageStateAsync(new()
            {
                Path = @"c:\state.json"
            });
            await context.CloseAsync();
            await browser.CloseAsync();
        }


        [TestMethod]
        [TestCategory("Login")]
        public async Task TestMethod_SaveVideo()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

            var context = await browser.NewContextAsync(new()
            {
                RecordVideoDir = "videos/"
            });

            var page = await context.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);

            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.FillAsync("#username", "AmirTester");
            await page.FillAsync("#password", "AmirTester");
            await page.ClickAsync("#login");
            
            await context.CloseAsync();
            await browser.CloseAsync();
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task TestMethod_Trace()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

            var context = await browser.NewContextAsync(new()
            {
                RecordVideoDir = "videos/"
            });

            // Start tracing before creating / navigating a page.
            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            var page = await context.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);

            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.FillAsync("#username", "AmirTester");
            await page.FillAsync("#password", "AmirTester");
            await page.ClickAsync("#login");

            // Stop tracing and export it into a zip archive.
            await context.Tracing.StopAsync(new()
            {
                Path = "trace.zip"
            });

            await context.CloseAsync();
            await browser.CloseAsync();
        }



        [TestMethod]
        [TestCategory("Login")]
       public async Task TestMethod_RetrieveState()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

            //  Create a new context with the saved storage state.
            var context = await browser.NewContextAsync(new()
            {
                StorageStatePath = @"c:\state.json",
               
            });
            
            var page = await context.NewPageAsync();
            
            Thread.Sleep(5000);

           // await page.GotoAsync("https://adactinhotelapp.com/SearchHotel.php");
           // await page.TypeAsync("#location", "Sydney");           

            await page.GotoAsync("https://adactinhotelapp.com/SelectHotel.php");
            await page.ClickAsync("#continue");
        }


        [TestMethod]
        [TestCategory("Login")]
        public async Task Test1()
        {
            //var playwright = await Playwright.CreateAsync();

            //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            //{ Headless = false, SlowMo = 1, });

            ////  Create a new context with the saved storage state.
            //var context = await browser.NewContextAsync();
            //var page = await context.NewPageAsync();

           
         

            //await page.CloseAsync();
            //await context.CloseAsync();
            //await browser.CloseAsync();

        }

        [TestMethod]
        [TestCategory("Login")]
        [DataRow("AmirTester","AmirTester")]
        [DataRow("invalid", "invalid")]
        [DataRow("huda", "huda123")]
        public async Task TestMethod3_DataRow(string user, string pass)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.FillAsync("#username", user);
            await page.FillAsync("#password", pass);
            await page.ClickAsync("#login");

            string ss_path = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            await page.ScreenshotAsync(new() { Path = ss_path+".png" });
            await page.CloseAsync();
        }

        /// <summary>
        /// IsEnabledAsync - check if the login button is enabled. 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Login")]
        public async Task LoginButtonEnabled()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            await BasePage.page.IsEnabledAsync("#login");
            Thread.Sleep(3000);
            await BasePage.page.ClickAsync("#login");
            Assert.AreEqual("Enter Username", "Enter Username");
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            await BasePage.page.ClickAsync("#login");
        }

        /// <summary>
        /// GetByLabel - TypeAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Login")]
        public async Task EnterTextUsingTypeAsync()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            var element1 = BasePage.page.GetByText("#username: visible");
            await element1.TypeAsync("AmirTester");
            await element1.PressAsync("Enter");
            Assert.AreEqual("Enter Password", "Enter Password");
            var element2 = BasePage.page.GetByText("#password");
            await element2.TypeAsync("AmirTester");
            await element2.PressAsync("Enter");
            Thread.Sleep(3000);
        }
        
        /// <summary>
        /// TitleAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Login")]
        public async Task AssertTitleAfterLogin()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            Thread.Sleep(3000);
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            await BasePage.page.ClickAsync("#login");
            Console.WriteLine(await BasePage.page.TitleAsync());
        }

        /// <summary>
        /// TitleAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Login")]
        public async Task CheckRadioButton()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            Thread.Sleep(3000);
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            await BasePage.page.ClickAsync("#login");
            Console.WriteLine(await BasePage.page.TitleAsync());
            await BasePage.page.TypeAsync("#location", "Paris");
            await BasePage.page.ClickAsync("#Submit");
            await BasePage.page.IsCheckedAsync("#radiobutton_2");
            Thread.Sleep(3000);
            await BasePage.page.ClickAsync("#continue");
            Thread.Sleep(3000);
            //await BasePage.page.Expect(BasePage.page.GetByText("Welcome, John!")).ToBeVisibleAsync();
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task PlaceHolder()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://demoqa.com/text-box");
            await BasePage.page.GetByPlaceholder("Current Address").FillAsync("Test");
        }  
    }
}