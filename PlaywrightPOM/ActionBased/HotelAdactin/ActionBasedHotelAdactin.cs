using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    public class LoginPageActionBased : BasePage
    {
        #region LoginPage Locators
        ILocator userNameTxt = page.Locator("#username");
        ILocator passwordTxt = page.Locator("#password");
        ILocator loginBtn = page.Locator("#login");
        #endregion

        public async Task Login(string url, string username, string pass)
        {
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login website");
            await GotoAsync(url);
            await FillAsync(userNameTxt, username);
            await FillAsync(passwordTxt, pass);
            await ClickAsync(loginBtn);
        }
    }

    public class SearchPageActionBased : BasePage
    {
        #region SearchPage Locators
        ILocator locationTxt = page.Locator("#location");
        ILocator searchBtn = page.Locator("#Submit");
        #endregion
        public async Task SearchHotel(string location)
        {
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Search Hotel");
            await page.TypeAsync("#location", location);
            await ClickAsync(searchBtn);
        }
    }

    public class SelectHotelActionBased : BasePage
    {
        #region SelectPage Locators
        ILocator continueBtn = page.Locator("#continue");
        ILocator radBtn2 = page.Locator("#radiobutton_2");
        #endregion
        public async Task SelectHotel()
        {
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Select Hotel");
            await ClickAsync(radBtn2);
            await ClickAsync(continueBtn);
        }
    }

    public class BookHotelActionBased : BasePage
    {
        #region BookHotelPage Locators
        ILocator fnameTxt = page.Locator("#first_name");
        ILocator lnameTxt = page.Locator("#last_name");
        ILocator addressTxt = page.Locator("#address");
        ILocator cCNoTxt = page.Locator("#cc_num");
        ILocator cCTypeDropDown = page.Locator("#cc_type");
        ILocator expiryDateDropDown = page.Locator("#cc_exp_month");
        ILocator expiryYearDropDown = page.Locator("#cc_exp_year");
        ILocator cVVNoTxt = page.Locator("#cc_cvv");
        ILocator bookNowBtn = page.Locator("#book_now");
        ILocator cancelBtn = page.Locator("#cancel");
        ILocator orderNoTxt = page.Locator("#order_no");
        #endregion BookHotelPage Locators
        public async Task BookHotel(string Firstname, string Lastname, string address, string CCNo, string CvvNo)
        {
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Book Hotel");
            await FillAsync(fnameTxt, Firstname);
            await FillAsync(lnameTxt, Lastname);
            await FillAsync(addressTxt, address);
            await FillAsync(cCNoTxt, CCNo);
            await cCTypeDropDown.TypeAsync("VISA");
            await expiryDateDropDown.TypeAsync("June");
            await expiryYearDropDown.TypeAsync("2022");
            await FillAsync(cVVNoTxt, CvvNo);
            await ClickAsync(bookNowBtn);
        }
    }
}






   
        
    

