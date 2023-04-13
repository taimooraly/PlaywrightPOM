using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.Text.RegularExpressions;
//using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PlaywrightPOM
{
    [TestClass]
    public class PageTestExec : PageTest
    {
        [TestMethod]
        [TestCategory("Login")]
        public async Task TestMethod1()
        {
            await Page.GotoAsync("https://adactinhotelapp.com/");
            await Expect(Page).ToHaveTitleAsync(new Regex("Adactin.com - Hotel Reservation System"));
            await Page.FillAsync("#username", "AmirTester");
            await Page.FillAsync("#password", "AmirTester");
            await Page.ClickAsync("#login");
            await Expect(Page).ToHaveTitleAsync(new Regex("Adactin.com - Search Hotel"));
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task TestMethod2()
        {
            //var context = await browser.NewContextAsync(new()
            //{
            //    RecordVideoDir = "videos/"
            //});

            await Page.GotoAsync("https://adactinhotelapp.com/");
            await Page.FillAsync("#username", "AmirTester");
            await Page.FillAsync("#password", "AmirTester");
            await Page.ClickAsync("#login");
        }

        [TestCategory("Login")]
        [TestMethod]
        public async Task Trace_PageTest()
        {
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            await Page.GotoAsync("https://adactinhotelapp.com/");
            await Page.FillAsync("#username", "AmirImam");
            await Page.FillAsync("#password", "AmirImam");
            await Page.ClickAsync("#login");

            // Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = "trace_pageTest.zip"
            });

            await Context.CloseAsync();
            await Browser.CloseAsync();
        }

        [TestCategory("Login")]
        [TestMethod]
        public async Task Video_PageTest()
        {
            ContextOptions();

            await Page.GotoAsync("https://adactinhotelapp.com/");
            await Page.FillAsync("#username", "AmirTester");
            await Page.FillAsync("#password", "AmirTester");
            await Page.ClickAsync("#login");     
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task SaveState_PageTest()
        {
            await Page.GotoAsync("https://adactinhotelapp.com/");
            await Page.FillAsync("#username", "AmirTester");
            await Page.FillAsync("#password", "AmirTester");
            await Page.ClickAsync("#login");

            // Save storage state into the file.
            await Context.StorageStateAsync(new()
            {
                Path = @"c:\pagetest_state.json"
            });
            await Context.CloseAsync();
            await Browser.CloseAsync();
        }

        [TestMethod]
        [TestCategory("Login")]
        public async Task RetrieveState_PageTest()
        {
            new BrowserNewContextOptions()
            {
                RecordVideoDir = "videos/",
                StorageStatePath = @"c:\pagetest_state.json",
                ViewportSize = new ViewportSize
                {
                    Height = 1080,
                    Width = 1280
                },
                RecordVideoSize = new RecordVideoSize
                {
                    Height = 1080,
                    Width = 1280
                }
            };

            Thread.Sleep(5000);

            // await page.GotoAsync("https://adactinhotelapp.com/SearchHotel.php");
            // await page.TypeAsync("#location", "Sydney");           

            await Page.GotoAsync("https://adactinhotelapp.com/SelectHotel.php");
            await Page.ClickAsync("#continue");
        }

        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                RecordVideoDir = "videos/",
                StorageStatePath = @"c:\state.json",
                ViewportSize = new ViewportSize
                {
                    Height = 1080,
                    Width = 1280
                },
                RecordVideoSize = new RecordVideoSize
                {
                    Height = 1080,
                    Width = 1280
                }
            };
        }

    }
}