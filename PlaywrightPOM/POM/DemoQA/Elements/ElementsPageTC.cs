using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlaywrightPOM
{
    [TestClass]
    public class ElementsPageTC
    {
        [TestMethod]
        public async Task WriteInTextBox()
        {
            await BasePage.Initialize();
            string Url = "https://demoqa.com/";           
            await BasePage.page.GotoAsync(Url);
            ElementsPage elementsPage = new ElementsPage();
            await BasePage.page.Locator("text=Elements").ClickAsync();
            await elementsPage.TextBox("Huda Aleem", "huda.aleem12@gmail.com", "Test1123 area", "Karachi");
            Assert.AreEqual("Name:Huda Aleem", "Name:Huda Aleem");
        }

        [TestMethod]
        public async Task MarkCheckBox()
        {
            await BasePage.Initialize();
            string Url = "https://demoqa.com/";
            await BasePage.page.GotoAsync(Url);
            ElementsPage elementsPage = new ElementsPage();
            await BasePage.page.Locator("text=Elements").ClickAsync();
            await elementsPage.CheckBox();
            Thread.Sleep(3000);
            Assert.AreEqual("Home", "Home");
            await BasePage.page.Locator("button[title='Toggle']").ClickAsync();
            Thread.Sleep(3000);
            await BasePage.page.Locator("span[class='rct-checkbox'] >> nth=3").ClickAsync();
            Thread.Sleep(3000);
            Assert.AreEqual("downloads", "downloads");
            Assert.AreEqual("wordFile", "wordFile");
            Assert.AreEqual("excelFile", "excelFile");
            await BasePage.page.CloseAsync();
        }

        [TestMethod]
        public async Task SelectRadioButton()
        {
            await BasePage.Initialize();
            string Url = "https://demoqa.com/radio-button";
            await BasePage.page.GotoAsync(Url);
            ElementsPage elementsPage = new ElementsPage();
            // await BasePage.page.Locator("text=Elements").ClickAsync();

            //await BasePage.page.CheckAsync("#yesRadio");
            await BasePage.page.EvaluateAsync("$('#yesRadio').click()");
            Thread.Sleep(3000);
            Assert.AreEqual("You have selected Impressive", "You have selected Impressive");            
            Thread.Sleep(3000);
            await BasePage.page.Locator("label[class='custom-control-label disabled']").IsDisabledAsync();
            Thread.Sleep(3000);
            await BasePage.page.CloseAsync();
        }

        [TestMethod]
        public async Task ClickButtons()
        {
            await BasePage.Initialize();
            string Url = "https://demoqa.com/";
            await BasePage.page.GotoAsync(Url);
            ElementsPage elementsPage = new ElementsPage();
            await BasePage.page.Locator("text=Elements").ClickAsync();
            await elementsPage.Button();
            Thread.Sleep(3000);
            Assert.AreEqual("You have done a double click", "You have done a double click");
            await BasePage.page.CloseAsync();
        }
    }
}
