using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    public class PracticeFormPage : BasePage
    {
        #region Studuent Registration Form Locators
        
        ILocator fNameTxt = page.Locator("#firstName");
        ILocator lNameTxt = page.Locator("#lastName");
        ILocator emailTxt = page.Locator("#userEmail");
        ILocator maleRadioBtn = page.Locator("input[value='Male']");
        ILocator femaleRadioBtn = page.Locator("input[id='gender-radio-2']");
        ILocator otherRadioBtn = page.Locator("input[value='Other']");
        ILocator mobileTxt = page.Locator("#userNumber");
        ILocator dOBTxt = page.Locator("#dateOfBirthInput");
        ILocator subjTxt = page.Locator("#subjectsContainer div.subjects-auto-complete__value-container.subjects-auto-complete__value-container--is-multi.css-1hwfws3");
        ILocator sportsHobbyCBox = page.Locator("#hobbies-checkbox-1");
        ILocator readingHobbyCBox = page.Locator("#hobbies-checkbox-2");
        ILocator musicHobbyCBox = page.Locator("#hobbies-checkbox-3");
        ILocator currentAddressTxt = page.Locator("#confirmButton");
        ILocator pracFormBtn = page.Locator("text=Practice Form");
        #endregion 

        public async Task StudentRegisterationForm(string FirstName, string LastName, string Email, string MobileNo, string DOB, string Subjects, string CurrentAddress)
        {
            await pracFormBtn.ClickAsync();

            await fNameTxt.FillAsync(FirstName);
            Thread.Sleep(2000);
            await lNameTxt.FillAsync(LastName);
            Thread.Sleep(2000);
            await emailTxt.FillAsync(Email);
            Thread.Sleep(2000);
            await page.EvaluateAsync("$('#gender-radio-2').click()");         
            Thread.Sleep(2000);
            await mobileTxt.FillAsync(MobileNo);
            Thread.Sleep(2000);
            await dOBTxt.FillAsync(DOB);
            await page.Keyboard.PressAsync("Enter");
            await page.Keyboard.PressAsync("Tab");
            await subjTxt.FillAsync(Subjects);
            Thread.Sleep(2000);
            await readingHobbyCBox.ClickAsync();
            Thread.Sleep(2000);
            
            await currentAddressTxt.FillAsync(CurrentAddress);           
            Thread.Sleep(2000);
        }
    }
}
