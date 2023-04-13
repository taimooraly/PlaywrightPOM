using Microsoft.CodeAnalysis;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace PlaywrightPOM
{
    [TestClass]
    public class AsyncTest
    {
        [TestMethod]
        [TestCategory("Sync")]
        public void SyncExec_TC01()
        {
            SyncExec.Test1();
            SyncExec.Test2();
            SyncExec.Test3();
            SyncExec.Test4();
            Thread.Sleep(1000);
        }

        [TestMethod]
        [TestCategory("Async")]
        public async Task AsyncExec_TC01()
        {
             AsyncExec.Test1();
             AsyncExec.Test2();
             await AsyncExec.Test3();
             AsyncExec.Test4();
             Thread.Sleep(2000);
        }
    }

    public static class AsyncExec
    {
        public static async Task Test1()
        {
            Console.WriteLine("ASYNC Test1 STARTED");
            await Task.Delay(3000);
            Console.WriteLine("ASYNC Test1 COMPLETED");
        }
        public static async Task Test2()
        {
            Console.WriteLine("ASYNC Test2 STARTED");
            await Task.Delay(1000);
            Console.WriteLine("ASYNC Test2 COMPLETED");
        }
        public static async Task Test3()
        {
            Console.WriteLine("ASYNC Test3 STARTED");
            await Task.Delay(1000);
            Console.WriteLine("ASYNC Test3 COMPLETED");
        }
        public static async Task Test4()
        {
            Console.WriteLine("ASYNC Test4 STARTED");
            await Task.Delay(1000);
            Console.WriteLine("ASYNC Test4 COMPLETED");
        }
    }

    public static class SyncExec
    {
        public static void Test1()
        {
            Console.WriteLine("Sync Test1 STARTED");
            Thread.Sleep(3000);
            Console.WriteLine("Sync Test1 COMPLETED");
        }
        public static void Test2()
        {
            Console.WriteLine("Sync Test2 STARTED");
            Thread.Sleep(1000);
            Console.WriteLine("Sync Test2 COMPLETED");
        }
        public static void Test3()
        {
            Console.WriteLine("Sync Test3 STARTED");
            Thread.Sleep(1000);
            Console.WriteLine("Sync Test3 COMPLETED");
        }
        public static void Test4()
        {
            Console.WriteLine("Sync Test4 STARTED");
            Thread.Sleep(1000);
            Console.WriteLine("Sync Test4 COMPLETED");
        }
    }
}