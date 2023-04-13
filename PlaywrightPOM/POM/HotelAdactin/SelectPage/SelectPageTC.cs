using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlaywrightPOM
{
    [TestClass]
    public class SelectPageTC
    {              
        [TestMethod]
        public async Task SelectHotel()
        {
            await BasePage.Initialize();

            string Url = "https://adactinhotelapp.com/";

            LoginPage loginPage = new LoginPage();
            SearchPage searchPage = new SearchPage();
            SelectPage selectPage = new SelectPage();           

            await loginPage.Login(Url, "AmirTester", "AmirTester");
            await searchPage.SearchHotel("Sydney");
            await selectPage.SelectHotel();

            await BasePage.page.CloseAsync();
        }

    }
}
