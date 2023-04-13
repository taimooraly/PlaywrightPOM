using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightPOM
{ 
    [TestClass]
    public class TestExecutionsTC : ExtentReport
    {
        #region Setup and Cleanup

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            LogReport("TestReport");
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }

        [TestInitialize()]
        public async Task TestInit()
        {
            BasePage.testContext = instance;
            exParentTest = extentReports.CreateTest(TestContext.TestName);
            await BasePage.Initialize("Chrome");
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            BasePage.page.CloseAsync();
        }
        #endregion

        [TestMethod]
        public async Task LoginHotelAdactinl()
        {
            //exChildTest = exParentTest.CreateNode("Login");

            LoginPageActionBased loginPageActionBased = new LoginPageActionBased();
            await loginPageActionBased.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
        }

        [TestMethod]
        public async Task BookingHotel()
        {
            //exChildTest = exParentTest.CreateNode("Login");
            LoginPageActionBased loginPageActionBased = new LoginPageActionBased();
            SearchPageActionBased searchPageActionBased = new SearchPageActionBased();
            SelectHotelActionBased selectHotelActionBased = new SelectHotelActionBased();
            BookHotelActionBased bookHotelActionBased = new BookHotelActionBased();

            await loginPageActionBased.Login("https://adactinhotelapp.com/", "AmirTester", "AmirTester");
            await searchPageActionBased.SearchHotel("Sydney");
            await selectHotelActionBased.SelectHotel();
            await bookHotelActionBased.BookHotel("Huda","Aleem","Karachi","123","123");
        }
    }
}
