using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlaywrightPOM
{  
    public class SearchPage : BasePage
    {
        public async Task SearchHotel(string location)
        {
            await page.TypeAsync("#location",location);
            await page.ClickAsync("#Submit");
        }
    }
}
