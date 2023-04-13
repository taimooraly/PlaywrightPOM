using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlaywrightPOM
{  
    public class SelectPage : BasePage
    {
        public async Task SelectHotel()
        {
            await page.ClickAsync("#radiobutton_2");
            await page.ClickAsync("#continue");
        }
    }
}
