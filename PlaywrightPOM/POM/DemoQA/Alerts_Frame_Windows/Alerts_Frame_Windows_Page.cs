using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    public class Alerts_Frame_Windows_Page : BasePage
    {
        #region LOCATORS

        #region Browser Windows Locators
        ILocator newTabBtn = page.Locator("#tabButton");
        ILocator newWindowBtn = page.Locator("#windowButton");
        ILocator newWindowMsgBtn = page.Locator("#messageWindowButton");
        ILocator browserWindows = page.Locator("text=Browser Windows");
        #endregion Browser Windows Locators

        #region Alerts Locators
        ILocator simpleAlertBtn = page.Locator("#alertButton");
        ILocator timerAlertBtn = page.Locator("#timerAlertButton");
        ILocator confirmboxAlertBtn = page.Locator("#confirmButton");
        ILocator promptAlertBtn = page.Locator("#promtButton");
        ILocator alertsBtn = page.Locator("text=Alerts >> nth=2");
        #endregion Alerts Locators

        #region Frames Locators
        ILocator framesBtn = page.Locator("text=Frames >> nth=0");
        #endregion Frames Locators

        #endregion LOCATORS

        #region Browser Windows
        public async Task NewTab()
        {
            await browserWindows.ClickAsync();

            await newTabBtn.ClickAsync();
            page = page.Context.Pages[0];
            Thread.Sleep(2000);
        }
        public async Task NewWindow()
        {
            await browserWindows.ClickAsync();
            await newWindowBtn.ClickAsync();
            page = page.Context.Pages[0];
            Thread.Sleep(2000);
        }
        public async Task NewWindowMessage()
        {
            await browserWindows.ClickAsync();
            await newWindowMsgBtn.ClickAsync();
            page = page.Context.Pages[0];
            Thread.Sleep(2000);
        }
        #endregion

        #region Alerts
        public async Task AlertWithSimpleClick()
        {
            await alertsBtn.ClickAsync();
            Thread.Sleep(3000);
            await page.EvaluateAsync("$('#alertButton').click()");
            //await simpleAlertBtn.ClickAsync();
            Thread.Sleep(5000);
        }
        public async Task AlertWithTimer()
        {
            await alertsBtn.ClickAsync();
            Thread.Sleep(3000);
            await page.EvaluateAsync("$('#timerAlertButton').click()");
            //await timerAlertBtn.ClickAsync();
            await page.WaitForLoadStateAsync();
        }
        public async Task AlertWithConfirmationBox()
        {
            await alertsBtn.ClickAsync();
            Thread.Sleep(3000);
            await page.EvaluateAsync("$('#confirmButton').click()");
            //await confirmboxAlertBtn.ClickAsync();
            Thread.Sleep(3000);
        }
        public async Task AlertWithPrompt()
        {
            await alertsBtn.ClickAsync();
            Thread.Sleep(3000);
            await page.EvaluateAsync("$('#promtButton').click()");
            //await promptAlertBtn.ClickAsync();
            Thread.Sleep(3000);
        }
        #endregion

        #region Frames
        public async Task SwitchToFrame()
        {
            await framesBtn.ClickAsync();
            Thread.Sleep(3000);
            page.FrameLocator("iframe").Nth(0);
            Assert.AreEqual("This is a sample page", "This is a sample page");
            Thread.Sleep(3000);
        }
        #endregion
    }
}
