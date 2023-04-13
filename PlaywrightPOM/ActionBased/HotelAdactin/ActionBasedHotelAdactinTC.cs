using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM 
{ 
    [TestClass]
    public class ActionBasedHotelAdactinTC
    {
        [TestMethod]
        public async Task LoginHotelAdactin()
        {
            await BasePage.Initialize();
            LoginPageActionBased loginPageActionBased = new LoginPageActionBased();
            await loginPageActionBased.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
        }

        [TestMethod]
        public async Task SearchHotel()
        {
            await BasePage.Initialize();
            LoginPageActionBased loginPageActionBased = new LoginPageActionBased();
            SearchPageActionBased SearchPageActionBased = new SearchPageActionBased();
            await loginPageActionBased.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
            await SearchPageActionBased.SearchHotel("Sydney");
            await BasePage.page.CloseAsync();
        }

        [TestMethod]
        public async Task SelectHotel()
        {
            await BasePage.Initialize();
            LoginPageActionBased loginPageActionBased = new LoginPageActionBased();
            SearchPageActionBased SearchPageActionBased = new SearchPageActionBased();
            SelectHotelActionBased selectHotelActionBased = new SelectHotelActionBased();
            await loginPageActionBased.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
            await SearchPageActionBased.SearchHotel("Sydney");
            await selectHotelActionBased.SelectHotel();
            await BasePage.page.CloseAsync();
        }

        [TestMethod]
        public async Task BookHotel()
        {
            await BasePage.Initialize();
            LoginPageActionBased loginPageActionBased = new LoginPageActionBased();
            SearchPageActionBased SearchPageActionBased = new SearchPageActionBased();
            SelectHotelActionBased selectHotelActionBased = new SelectHotelActionBased();
            BookHotelActionBased bookHotelActionBased = new BookHotelActionBased();
            await loginPageActionBased.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
            await SearchPageActionBased.SearchHotel("Sydney");
            await selectHotelActionBased.SelectHotel();
            await bookHotelActionBased.BookHotel("Huda","Aleem","Karachi","123456789101112","0621");
            await BasePage.page.CloseAsync();
        }
    }
}
