using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    [TestClass]
    public class PlaywrightLocatorMethodsTC
    {
        /// <summary>
        /// GetByPlaceHolder
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Demoqa")]
        public async Task GetByPlaceHolder()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://demoqa.com/text-box");
            await BasePage.page.GetByPlaceholder("Current Address").FillAsync("Test");
        }

        /// <summary>
        /// GetByLabel
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Demoqa")]
        public async Task GetByLabel()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://demoqa.com/text-box");
            await BasePage.page.GetByLabel("Permanent Address").FillAsync("Test");            
        }

        /// <summary>
        /// GetByRole
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Demoqa")]
        public async Task GetByRole()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://demoqa.com/text-box");
            await BasePage.page.GetByRole(AriaRole.Button, new()
            {
                NameRegex = new Regex("submit", RegexOptions.IgnoreCase)
            }).ClickAsync();
            
        }

        /// <summary>
        /// GetByTitle
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Demoqa")]
        public async Task GetByTitle()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://demoqa.com/text-box");
            await BasePage.page.GetByTitle("ToolsQA").IsVisibleAsync();
        }

        /// <summary>
        /// Combine methods
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("HotelAdactin")]
        public async Task HotelAdactin_GetByTitleRole()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/Register.php");
            await BasePage.page.GetByTitle("Adactin.com - New User Registration").IsVisibleAsync();
            await BasePage.page.GetByRole(AriaRole.Checkbox).ClickAsync();
            await BasePage.page.GetByRole(AriaRole.Button).First.ClickAsync();
        }

        /// <summary>
        /// BuiltinMethods
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("HotelAdactin")]
        public async Task HotelAdactin_BuiltinMethods()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/index.php");
            await BasePage.page.FillAsync("#username", "AmirTester");
            await BasePage.page.FillAsync("#password", "AmirTester");
            await BasePage.page.GetByRole(AriaRole.Button).Last.ClickAsync();
            Thread.Sleep(2000);
            await BasePage.page.GetByTitle("Adactin.com - Search Hotel").IsVisibleAsync();
            Thread.Sleep(2000);
            await BasePage.page.TypeAsync("#location", "Los Angeles");
            Thread.Sleep(2000);
            await BasePage.page.GetByRole(AriaRole.Button).First.ClickAsync();
            Thread.Sleep(2000);
            await BasePage.page.GetByTitle("Adactin.com - Select Hotel").IsVisibleAsync();
            Thread.Sleep(2000);
            await BasePage.page.Locator("#radiobutton_1").IsEnabledAsync();
            Thread.Sleep(2000);
            await BasePage.page.Locator("#radiobutton_1").IsVisibleAsync();
            Thread.Sleep(1000);
            await BasePage.page.Locator("#radiobutton_1").IsCheckedAsync();
            Thread.Sleep(1000);
            await BasePage.page.ClickAsync("#radiobutton_1");
            Thread.Sleep(1000);
            await BasePage.page.GetByRole(AriaRole.Button).First.ClickAsync();
            Thread.Sleep(1000);
            await BasePage.page.GetByTitle("Adactin.com - Book Hotel").IsVisibleAsync();
            Thread.Sleep(2000);
            await BasePage.page.IsDisabledAsync("#hotel_name_dis");
            Thread.Sleep(2000);
            await BasePage.page.IsEditableAsync("#hotel_name_dis");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// GetByAltText
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("Demoqa")]
        public async Task GetByAltText()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            await BasePage.page.GetByAltText("Hotel Image 3").IsVisibleAsync();
        }

        [TestMethod]
        [TestCategory("Demoqa")]
        public async Task RegisterNewUser_GetByAltText()
        {
            await BasePage.Initialize("Chrome");
            await BasePage.page.GotoAsync("https://adactinhotelapp.com/");
            Thread.Sleep(2000);
            await BasePage.page.GetByAltText("Hotel Image 3").IsVisibleAsync();
            Thread.Sleep(2000);
            await BasePage.page.GetByText("New User Register Here").ClickAsync();
            Thread.Sleep(2000);
            await BasePage.page.GetByAltText("Refresh Captcha").ClickAsync();
        }

    }
}
