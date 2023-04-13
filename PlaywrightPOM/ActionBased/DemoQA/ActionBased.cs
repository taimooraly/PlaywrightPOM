using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    public class ActionBased : BasePage
    {
        #region LOCATORS
        ILocator alertFrameWindow = page.Locator("text=Alerts, Frame & Windows");
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
            await ClickAsync(browserWindows);
            await ClickAsync(newTabBtn);
            page = page.Context.Pages[0];
            Thread.Sleep(2000);
        }
        public async Task NewWindow()
        {

            await ClickAsync(browserWindows);
            await ClickAsync(newWindowBtn);
            page = page.Context.Pages[0];
            Thread.Sleep(2000);
        }
        public async Task NewWindowMessage()
        {
            await ClickAsync(browserWindows);
            await ClickAsync(newWindowMsgBtn);
            page = page.Context.Pages[0];
            Thread.Sleep(2000);
        }
        #endregion

        #region Alerts
        public async Task AlertWithSimpleClick()
        {
            await ClickAsync(alertsBtn);
            Thread.Sleep(3000);
            await ClickAsync(simpleAlertBtn);
            Thread.Sleep(5000);
        }
        public async Task AlertWithTimer()
        {
            await ClickAsync(alertsBtn);
            Thread.Sleep(3000);
            await ClickAsync(timerAlertBtn);
            Thread.Sleep(3000);
        }
        public async Task AlertWithConfirmationBox()
        {
            await ClickAsync(alertsBtn);
            Thread.Sleep(3000);
            await ClickAsync(confirmboxAlertBtn);
            Thread.Sleep(3000);
        }
        public async Task AlertWithPrompt()
        {
            await ClickAsync(alertsBtn);
            Thread.Sleep(3000);
            await ClickAsync(promptAlertBtn);
            Thread.Sleep(3000);
        }
        #endregion

        #region Frames
        public async Task SwitchToFrame()
        {
            await ClickAsync(framesBtn);
            Thread.Sleep(3000);
            page.FrameLocator("iframe").Nth(0);
            Assert.AreEqual("This is a sample page", "This is a sample page");
            Thread.Sleep(3000);
        }
        #endregion
    }
}
