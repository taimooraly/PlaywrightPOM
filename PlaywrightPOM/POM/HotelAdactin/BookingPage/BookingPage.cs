using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlaywrightPOM
{  
    public class BookingPage : BasePage
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

        public async Task BookHotel()
        {
            await fnameTxt.FillAsync("Amir");
            await lnameTxt.FillAsync("Emam");
            await addressTxt.FillAsync("R1-67/1, Demo Area, Demo Town, Karachi");
            await cCNoTxt.FillAsync("12345678987654321");
            await cCTypeDropDown.TypeAsync("VISA");
            await expiryDateDropDown.TypeAsync("June");
            await expiryYearDropDown.TypeAsync("2022");
            await cVVNoTxt.FillAsync("1234");
            await bookNowBtn.ClickAsync();        
        }
    }
}
