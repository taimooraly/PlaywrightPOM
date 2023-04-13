using Microsoft.Playwright;

namespace PlaywrightPOM
{
    [TestClass]
    public class LoginTC
    {
        [TestMethod]
        public async Task Login()
        {
            var playwright = await Playwright.CreateAsync();
            
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 1, });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://adactinhotelapp.com/");
            await page.FillAsync("#username", "AmirTester");
            await page.FillAsync("#password", "AmirTester");
            await page.ClickAsync("#login");
        }






        [TestMethod]
        public async Task LoginPositive()
        {
            LoginPage loginPage = new LoginPage();

            await BasePage.Initialize();
            await loginPage.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
        }

        [TestMethod]
        public async Task LoginNegative()
        {
            LoginPage loginPage = new LoginPage();

            await BasePage.Initialize("a");
            await loginPage.Login("https://adactinhotelapp.com/", "Amir1Tester", "AmirTester");
        }
    }
}