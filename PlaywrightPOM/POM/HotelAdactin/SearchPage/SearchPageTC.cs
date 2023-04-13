using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlaywrightPOM
{
    [TestClass]
    public class SearchPageTC
    {       
        [TestMethod]
        public async Task SearchHotel()
        {
            await BasePage.Initialize();

            LoginPage loginPage = new LoginPage();
            SearchPage searchPage = new SearchPage();

            await loginPage.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
            await searchPage.SearchHotel("Sydney");

            await BasePage.page.CloseAsync();

        }
    }
}
