using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    public class ElementsPage : BasePage
    {
        #region LOCATORS

        #region TextBox Locators
        ILocator fullnameTxt = page.Locator("#userName");
        ILocator emailTxt = page.Locator("#userEmail");
        ILocator currentAddressTxt = page.Locator("#currentAddress");
        ILocator permanentAddressTxt = page.Locator("#permanentAddress");
        ILocator submitBtn = page.Locator("#submit");
        ILocator TextBoxBtn = page.Locator("text=Text Box");        
        #endregion TextBox Locators

        #region CheckBox Locators
        ILocator MainToggleArrow = page.Locator("button[title='Toggle']");
        ILocator expandAllIcon = page.Locator("button[title='Expand all']");
        ILocator collapseAllIcon = page.Locator("button[title='Collapse all']");
        ILocator CheckBoxBtn = page.Locator("text=Check Box");
        #endregion CheckBox Locators

        #region RadioButton Locators
        ILocator radioBtn = page.Locator("text=Radio Button");
        ILocator yesRadioBtn = page.GetByLabel("Yes");
        ILocator impressiveRadioBtn = page.Locator("input[id='impressiveRadio']");
        ILocator noRadioBtn = page.Locator("input[id='noRadio']");
        #endregion RadioButton Locators

        #region Button Locators
        ILocator Buttons = page.Locator("text=Buttons");
        ILocator clickMeBtn = page.Locator("text=Click Me >> nth=0");
        ILocator doubleClickMeBtn = page.Locator("text=Double Click Me");
        ILocator rightClickMeBtn = page.Locator("text=Right Click Me");
        #endregion Button Locators
        #endregion LOCATORS

    
        public async Task TextBox(string user,string email, string currentAddress, string permanentAddress)
        {
            await TextBoxBtn.ClickAsync();
            
            await fullnameTxt.FillAsync(user);
            await emailTxt.FillAsync(email);
            await currentAddressTxt.FillAsync(currentAddress);
            await permanentAddressTxt.FillAsync(permanentAddress);
            await submitBtn.ClickAsync();
        }
        public async Task CheckBox()
        {
            await CheckBoxBtn.ClickAsync();
            await expandAllIcon.ClickAsync();
            await collapseAllIcon.ClickAsync();
        }
        
        public async Task Button()
        {
            await Buttons.ClickAsync();
            Thread.Sleep(3000);
            await doubleClickMeBtn.DblClickAsync();
        }
      
    }
}
