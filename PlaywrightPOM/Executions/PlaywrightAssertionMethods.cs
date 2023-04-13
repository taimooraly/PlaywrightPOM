using Microsoft.Extensions.Options;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PlaywrightPOM
{
    [TestClass]
    public class PlaywrightAssertionMethods
    {
        /// <summary>
        /// ToHaveTextAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("HotelAdactin")]
        public async Task ToHaveTextAsync()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            await BasePage.page.GetByAltText("Hotel Image 3").IsVisibleAsync();
            Thread.Sleep(2000);
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            //wait Assertions.Expect(BasePage.page.Locator(".login_button")).ToHaveTextAsync("Login");
            Thread.Sleep(2000);
            await BasePage.page.GetByRole(AriaRole.Button).ClickAsync();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// ToBeEditableAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("HotelAdactin")]
        public async Task ToBeEditableAsync()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            await Assertions.Expect(BasePage.page.Locator("#username")).ToBeEditableAsync();
            await Assertions.Expect(BasePage.page.Locator("#password")).ToBeEditableAsync();
            Thread.Sleep(2000);
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            await Assertions.Expect(BasePage.page.Locator(".login_button")).ToHaveTextAsync("Login");
            Thread.Sleep(2000);
            await BasePage.page.GetByRole(AriaRole.Button).ClickAsync();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// ToBeEmptyAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("HotelAdactin")]
        public async Task ToBeEmptyAsync()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            await Assertions.Expect(BasePage.page.Locator("#username")).ToBeEmptyAsync();
            await Assertions.Expect(BasePage.page.Locator("#password")).ToBeEmptyAsync();
            Thread.Sleep(2000);
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            await Assertions.Expect(BasePage.page.Locator(".login_button")).ToHaveTextAsync("Login");
            Thread.Sleep(2000);
            await BasePage.page.GetByRole(AriaRole.Button).ClickAsync();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// ToBeEnabledAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("HotelAdactin")]
        public async Task ToBeEnabledAsync()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            await Assertions.Expect(BasePage.page.Locator("#username")).ToBeEnabledAsync();
            await Assertions.Expect(BasePage.page.Locator("#password")).ToBeEnabledAsync();
            await Assertions.Expect(BasePage.page.Locator(".login_button")).ToBeEnabledAsync();
            Thread.Sleep(2000);
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            Thread.Sleep(2000);
            await BasePage.page.GetByRole(AriaRole.Button).ClickAsync();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// ToContainTextAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("HotelAdactin")]
        public async Task ToContainTextAsync()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            await Assertions.Expect(BasePage.page.Locator("#username")).ToBeEnabledAsync();
            await Assertions.Expect(BasePage.page.Locator("#password")).ToBeEnabledAsync();
            await Assertions.Expect(BasePage.page.Locator(".login_button")).ToBeEnabledAsync();
            Thread.Sleep(2000);
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            Thread.Sleep(2000);
            await BasePage.page.GetByRole(AriaRole.Button).ClickAsync();
            await Assertions.Expect(BasePage.page.Locator("#location")).ToContainTextAsync("- Select Location -");
            Thread.Sleep(2000);
            await BasePage.page.GetByRole(AriaRole.Button).First.ClickAsync();
            // Stop tracing and export it into a zip archive.
            await BasePage.Context.Tracing.StopAsync(new()
            {
                Path = "trace.zip"
            });
        }

    }
}
