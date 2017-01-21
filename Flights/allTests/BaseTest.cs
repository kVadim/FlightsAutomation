using NUnit.Framework;
using Flights.Actions;
using System.Threading;
using System.Diagnostics;
using NUnit.Framework.Interfaces;

namespace Flights.allTests
{
    public class BaseTest
    {
        string testName { get { return NUnit.Framework.TestContext.CurrentContext.Test.Name; } }

        [SetUp]
        public void RunBeforeAnyTests()
        {
            Logger.InitLogger();
            Logger.Log.Info("Test Started: " + testName);
            Navigate.StartApp();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                Logger.Log.Info("Test Failed");
            }
            else
            {
                Logger.Log.Info("Test PASSED");
            }
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
            Logger.Log.Info("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }
}
