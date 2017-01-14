using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowItems;

namespace Flights
{
    [TestFixture]
    public class Tests
    {
        [Test, Sequential]        
        public void loginCheck(
                                [Values("blabla", "john",   "blabla", "john")]string name,
                                [Values("blabla", "blabla", "hp",     "hp"  )]string password,
                                [Values(false,     false,    false,    true )]bool   positiveTest
                                )
        {
            string expectedValueNegative = "Login Failed";
            string expectedValuePositive = "John Smith";
            var FlightsLoginDialog = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_Name = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("agentName"));
            var textBox_Password = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("password"));
            var btn_OK = FlightsLoginDialog.Get<Button>(SearchCriteria.ByAutomationId("okButton"));

            textBox_Name.SetValue(name);
            textBox_Password.SetValue(password);
            btn_OK.Click();

            if (positiveTest)
            {
                var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
                var usernameTitle = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("usernameTitle"));

                Assert.IsTrue(expectedValuePositive == usernameTitle.Name); 
            }
            else
            {
                var LoginFailedDialog = FlightsLoginDialog.ModalWindow(SearchCriteria.ByControlType(ControlType.Window));
                var LoginFailed_btn_OK = LoginFailedDialog.Get<Button>(SearchCriteria.ByControlType(ControlType.Button));

                Assert.IsTrue(expectedValueNegative == LoginFailedDialog.Name);

                Thread.Sleep(1000);
                LoginFailed_btn_OK.Click();
            }
       }

        [Test]
        public void searchButtonAvailability()
        {
            string expectedValuePositive = "John Smith";
            var FlightsLoginDialog = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_Name = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("agentName"));
            var textBox_Password = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("password"));
            var btn_OK = FlightsLoginDialog.Get<Button>(SearchCriteria.ByAutomationId("okButton"));

            textBox_Name.SetValue("john");
            textBox_Password.SetValue("hp");
            btn_OK.Click();

            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var usernameTitle = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("usernameTitle"));

            Assert.IsTrue(expectedValuePositive == usernameTitle.Name);

            var tabs = FlightsMainWindow.Get<Tab>(SearchCriteria.ByControlType(ControlType.Tab));
            tabs.SelectTabPage("SEARCH ORDER");

            var radioBtn_orderNumber = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio"));
            radioBtn_orderNumber.Click();

            var btn_SEARCH = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn"));
            Assert.IsTrue(!btn_SEARCH.Enabled);
        }

        [Test]
        public void orderNumberAvailability()
        {
            string expectedValuePositive = "John Smith";
            var FlightsLoginDialog = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_Name = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("agentName"));
            var textBox_Password = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("password"));
            var btn_OK = FlightsLoginDialog.Get<Button>(SearchCriteria.ByAutomationId("okButton"));

            textBox_Name.SetValue("john");
            textBox_Password.SetValue("hp");
            btn_OK.Click();

            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var usernameTitle = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("usernameTitle"));

            Assert.IsTrue(expectedValuePositive == usernameTitle.Name);

            var tabs = FlightsMainWindow.Get<Tab>(SearchCriteria.ByControlType(ControlType.Tab));
            tabs.SelectTabPage("SEARCH ORDER");

            var textBox_orderNumber = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark"));
            Assert.IsTrue(!textBox_orderNumber.Enabled);
        }
   



        [SetUp]
        public void RunApplication()
        {
            Process.Start(Flights.PATH);
            Thread.Sleep(2500);
        }

        //[TearDown]
        public void StopApplication()
        {
            Thread.Sleep(1000);
            var processesToKIll = Process.GetProcessesByName(Flights.ProcessName);
            foreach (var p in processesToKIll){
                p.Kill();
            }
            
        }
    }


    public static class Flights
    {
        public const string PATH = "D:\\ADM Automation\\ADM exam task\\ADM exam task GUI\\Flights Application\\FlightsGUI.exe";
        public const string ProcessName = "FlightsGUI";

    }
}

























//



//  Keyboard.Instance.Enter("text to check");