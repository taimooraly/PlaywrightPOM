using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlaywrightPOM
{
    [TestClass]
    public class BookingPageTC
    {        
        [TestMethod]
        public async Task BookHotel()
        {
            await BasePage.Initialize();

            string Url = "https://adactinhotelapp.com/";

            LoginPage loginPage = new LoginPage();
            SearchPage searchPage = new SearchPage();
            SelectPage selectPage = new SelectPage();
            BookingPage bookingPage = new BookingPage();

            await loginPage.Login(Url, "AmirTester", "AmirTester");
            await searchPage.SearchHotel("Sydney");
            await selectPage.SelectHotel();
            await bookingPage.BookHotel();

            await BasePage.page.CloseAsync();
        }
    }
}