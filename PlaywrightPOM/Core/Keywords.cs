using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{
    public class Keywords
    {
        public static class CoreBrowser
        {
            public static string Chrome = "Chrome";
            public static string FireFox = "FireFox";
            public static string IE = "IE";
            public static string MicrosoftEdge = "MicrosoftEdge";
            public static string Safari = "Safari";
            public static string Zempad = "Zempad";
            public static string IPad = "IPad";
        }
        public static class CoreKeyboardActions
        {
            public static string BackspaceKey = "{BS}";
            public static string ClearKey = "{CLEAR}";
            public static string TabKey = "{TAB}";
            public static string EnterKey = "~";
            public static string ESCKey = "{ESC}";
            public static string NumLockKey = "{NUMLOCK}";
        }
    }
}
