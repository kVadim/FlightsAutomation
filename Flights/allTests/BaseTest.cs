using NUnit.Framework;
using Flights.Actions;
using System.Threading;
using System.Diagnostics;

namespace Flights.allTests
{
    public class BaseTest
    {
        [SetUp]
        public void RunApplication()
        {
            Navigate.StartApp();
        }

        //[TearDown]
        public void StopApplication()
        {
            Navigate.CloseApp();
            Thread.Sleep(1000);

            var processesToKIll = Process.GetProcessesByName(AppParameters.ProcessName);
            if (processesToKIll.Length > 0)
            {
                foreach (var p in processesToKIll)
                {
                    p.Kill();
                }
            }
        }
    }
}
