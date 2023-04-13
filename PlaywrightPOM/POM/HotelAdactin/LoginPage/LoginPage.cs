using Microsoft.Playwright;
using System.Security.Cryptography.X509Certificates;

namespace PlaywrightPOM
{
    public class LoginPage : BasePage
    {
        public ILocator usernameTxt = page.Locator("#username");
        public string usernameTxt_string = "#username"; 


        public async Task Login(string url, string username, string pass)
        {
            await usernameTxt.FillAsync(username);

            await page.GotoAsync(url);
            await page.FillAsync("#username", username);
            await page.FillAsync("#password", pass);
            await page.ClickAsync("#login");
        }
    }
}