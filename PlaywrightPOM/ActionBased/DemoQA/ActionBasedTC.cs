using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    [TestClass]
    public class ActionBasedTC
    {
        #region Brwoser Windows TCs
        [TestMethod]
        public async Task SwitchNewTab()
        {
            await BasePage.Initialize();
            Alerts_Frame_Windows_Page alerts_Frame_Windows_Page = new Alerts_Frame_Windows_Page();
            string Url = "https://demoqa.com/";
            await alerts_Frame_Windows_Page.GotoAsync(Url);
            await BasePage.page.Locator("text=Alerts, Frame & Windows").ClickAsync();
            await alerts_Frame_Windows_Page.NewTab();
            Assert.AreEqual("This is a sample page", "This is a sample page");
            await BasePage.page.CloseAsync();
        }

        [TestMethod]
        public async Task SwitchNewWindow()
        {
            await BasePage.Initialize();
            Alerts_Frame_Windows_Page alerts_Frame_Windows_Page = new Alerts_Frame_Windows_Page();
            string Url = "https://demoqa.com/";
            await alerts_Frame_Windows_Page.GotoAsync(Url);
            await BasePage.page.Locator("text=Alerts, Frame & Windows").ClickAsync();
            await alerts_Frame_Windows_Page.NewWindow();
            Assert.AreEqual("This is a sample page", "This is a sample page");
            await BasePage.page.CloseAsync();
        }

        [TestMethod]
        public async Task SwitchNewWindowMsg()
        {
            await BasePage.Initialize();
            Alerts_Frame_Windows_Page alerts_Frame_Windows_Page = new Alerts_Frame_Windows_Page();
            string Url = "https://demoqa.com/";
            await alerts_Frame_Windows_Page.GotoAsync(Url);
            await BasePage.page.Locator("text=Alerts, Frame & Windows").ClickAsync();
            await alerts_Frame_Windows_Page.NewWindowMessage();
            Assert.AreEqual("Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.", "Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.");
            await BasePage.page.CloseAsync();
        }
        #endregion

        #region Alerts TCs
        [TestMethod]
        public async Task ClickButtonToSeeAlert()
        {
            await BasePage.Initialize();
            Alerts_Frame_Windows_Page alerts_Frame_Windows_Page = new Alerts_Frame_Windows_Page();
            string Url = "https://demoqa.com/";
            await alerts_Frame_Windows_Page.GotoAsync(Url);
            await BasePage.page.Locator("text=Alerts, Frame & Windows").ClickAsync();
            await alerts_Frame_Windows_Page.AlertWithSimpleClick();
            await BasePage.page.CloseAsync();
        }

        [TestMethod]
        public async Task SeeAlertAfterTimer()
        {
            await BasePage.Initialize();
            Alerts_Frame_Windows_Page alerts_Frame_Windows_Page = new Alerts_Frame_Windows_Page();
            string Url = "https://demoqa.com/";
            await alerts_Frame_Windows_Page.GotoAsync(Url);
            await BasePage.page.Locator("text=Alerts, Frame & Windows").ClickAsync();
            await alerts_Frame_Windows_Page.AlertWithTimer();
            await BasePage.page.CloseAsync();
        }
        #endregion

        #region Frames TCs
        [TestMethod]
        public async Task SwitchToIFrame()
        {
            await BasePage.Initialize();
            Alerts_Frame_Windows_Page alerts_Frame_Windows_Page = new Alerts_Frame_Windows_Page();
            string Url = "https://demoqa.com/";
            await alerts_Frame_Windows_Page.GotoAsync(Url);
            await BasePage.page.Locator("text=Alerts, Frame & Windows").ClickAsync();
            await alerts_Frame_Windows_Page.SwitchToFrame();
            await BasePage.page.CloseAsync();
        }


        #endregion
    }
}
