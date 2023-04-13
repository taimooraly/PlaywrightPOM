using AventStack.ExtentReports;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PlaywrightPOM
{
    //cd PlaywrightTests
    //dotnet add package Microsoft.Playwright.MSTest
    //dotnet build
    //pwsh bin/Debug/netX/playwright.ps1 install

    public class BasePage
    {
        public static IFrameLocator frameLocator { get; set; }
        public static IPage page { get; set; }
        public static IFrame Frame { get; set; }
        public static IBrowser Browser { get; set; }
        public static IBrowserContext Context { get; set; }
        public static TestContext testContext { get; set; }
        public static ILocatorAssertions Expect(ILocator locator) => Assertions.Expect(locator);
        public static  JObject jObject;
        public static IPageAssertions Expect(IPage page) => Assertions.Expect(page);

        public static string pathWithFileNameExtension;

        public static async Task Initialize()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 50, });
            page = await Browser.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);
        }

        public static async Task Initialize(string executionBrowser)
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 50, Timeout = 80000, });
            Context = await Browser.NewContextAsync(new()
            {
                RecordVideoDir = "videos/",
                RecordVideoSize = new RecordVideoSize() { Width = 1920, Height = 1080 }

            });
            // Start tracing before creating / navigating a page.
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true,
            });

            page = await Context.NewPageAsync();
            page.SetDefaultTimeout(5000);
            await page.SetViewportSizeAsync(1920, 1080);
        }

        public async Task ClickAsync(ILocator locator)
        {
            try
            {
                await locator.ClickAsync();
                Thread.Sleep(3000);
                await TakeScreenshot(Status.Pass, "Click Element");
            }
            catch (Exception ex)
            {
                await TakeScreenshot(Status.Fail, "Click Element: "+ ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }
        public async Task ClickAsync(string frameLocator)
        {
            try
            {
                var FLocator = page.FrameLocator("iframe").Locator(frameLocator);
                await FLocator.ClickAsync();
            }
            catch (Exception ex)
            {
                Assert.Fail("unable to click");
            }
        }

        public async Task FillAsync(ILocator locator, string data)
        {
            try
            {
                await locator.FillAsync(data);
                await TakeScreenshot(Status.Pass, "Enter Text");
            }
            catch (Exception ex)
            {
                await TakeScreenshot(Status.Fail, "Enter Text: " + ex.ToString());
                Assert.Fail(ex.ToString());
            }
        }
        public async Task FillAsync(string frameLocator, string data)
        {
            try
            {
                var FLocator = page.FrameLocator("iframe").Locator(frameLocator);
                await FLocator.FillAsync(data);

            }
            catch (Exception ex)
            {
                Assert.Fail("unable to write");
            }
        }
        public async Task GotoAsync(string url)
        {
            try
            {
                await page.GotoAsync(url);
                await TakeScreenshot(Status.Pass, "Open Url");
            }
            catch (Exception ex)
            {
                await TakeScreenshot(Status.Fail, "Open Url");
                Assert.Fail("unable to open url");
            }
        }
        public static string IsNullOrEmptyThenString(string text)
        {
            text = (text == String.Empty || text == null) ? "N/A" : text;
            return text;
        }
        public async Task<string> GetAttributeAsync(ILocator locator, string attributeName, LocatorClickOptions option = null)
        {
            string actualValue = string.Empty;
            try
            {

                if (locator != null)
                {
                    actualValue = await locator.GetAttributeAsync(attributeName);
                }
            }
            catch (Exception ex)
            {
                string ExceptionMsg = ex.ToString();
            }
            return actualValue;
        }
        public async Task IsDisabledAsync(ILocator locator, LocatorIsDisabledOptions option = null)
        {
            string attState = string.Empty;
            try
            {
                if (attState == "disabled")
                {
                    attState = await locator.GetAttributeAsync("disabled");
                }
            }
            catch (Exception ex)
            {
                string ExceptionMsg = ex.ToString();
            }
        }
        public async Task BrowseFile(ILocator locator, string filePath)
        {
            try
            {
                await locator.SetInputFilesAsync(filePath);
                
            }
            catch (Exception ex)
            {
                string ExceptionMsg = ex.ToString();
                Assert.Fail("unable to upload");
            }
        }
        public async Task TabOutFromElement()
        {
            try
            {
                await page.Keyboard.PressAsync("Tab");
            }
            catch (Exception ex)
            {
                string ExceptionMsg = ex.ToString();
                Assert.Fail("Tab out not performed");
            }
        }
       
        public static async Task TakeScreenshot(Status status, string stepDetail)
        {
            string path = @"C:\TestExecutionReports\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            pathWithFileNameExtension = @path + ".png";
            await page.Locator("body").ScreenshotAsync(new LocatorScreenshotOptions { Path = pathWithFileNameExtension });
            testContext.AddResultFile(pathWithFileNameExtension);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());

            //await page.ScreenshotAsync(new()
            //{
            //    Path = "screenshot.png",
            //    FullPage = true,
            //});
        }

        public static void ReadJson(string filename)
        {
            string myJsonString = File.ReadAllText(@"..\\..\\..\\" + filename);
            jObject = JObject.Parse(myJsonString);
        }


        public static void TakeScreenshot(string text)
        {
            //byte[] content = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            //AllureLifecycle.Instance.AddAttachment(text, "image/png", content);
        }

        public static void Write()
        {

        }
    }
}