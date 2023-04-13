using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    [TestClass]
    public class PracticeFormPageTC
    {
        [TestMethod]
        public async Task AutomatePracticeForm()
        {
            await BasePage.Initialize();
            string Url = "https://demoqa.com/";
            await BasePage.page.GotoAsync(Url);
            PracticeFormPage practiceFormPage = new PracticeFormPage();
            await BasePage.page.Locator("text=Forms").ClickAsync();
            Assert.AreEqual("Student Registration Form", "Student Registration Form");
            await practiceFormPage.StudentRegisterationForm("Huda","Aleem","hudaaleem6@gmail.com","03032232321","23 Dec 1996", "SQA","Karachi");
            await BasePage.page.CloseAsync();
        }
    }
}
