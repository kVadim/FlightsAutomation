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
using Flights.Navigation;
using TestStack.White.UIItems.ListBoxItems;

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
                               // [Values(ErrorMsg.onlyNubmers,  ErrorMsg.notExist, ErrorMsg.lessThanZero)]string expectedMessage
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
            Navigate.OpenSearchTab();

            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var radioBtn_orderNumber = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio"));
            var btn_SEARCH = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn"));

            radioBtn_orderNumber.Click();
            Assert.IsTrue(!btn_SEARCH.Enabled);
        }

        [Test]
        public void orderNumberAvailability()
        {
            Navigate.OpenSearchTab();

            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_orderNumber = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark"));
            Assert.IsTrue(!textBox_orderNumber.Enabled);
        }


        [Test, Sequential]
        public void incorrectOrderNumber(
                                        [Values("Some text",           "3333333",        "-5555"               )]string orderNumber,
                                        [Values(ErrorMsg.onlyNubmers,  ErrorMsg.notExist, ErrorMsg.lessThanZero)]string expectedMessage
                                        )
        {
            Navigate.OpenSearchTab();

            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var radioBtn_orderNumber = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio"));
            var textBox_orderNumber = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark"));
            var btn_SEARCH = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn"));

            radioBtn_orderNumber.Click();
            textBox_orderNumber.SetValue(orderNumber);
            btn_SEARCH.Click();

            var ErrorDialog = FlightsMainWindow.ModalWindow(SearchCriteria.ByControlType(ControlType.Window));
            var LoginFailed_btn_OK = ErrorDialog.Get<Button>(SearchCriteria.ByControlType(ControlType.Button));
            var ErrorMassage = ErrorDialog.Get<Label>(SearchCriteria.ByClassName("Static"));

            Assert.IsTrue(expectedMessage == ErrorMassage.Name);
            Thread.Sleep(1000);  // Pause to see 
            LoginFailed_btn_OK.Click();
        }


        [Test]
        public void E2E()
        {
            Navigate.login();
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var cmb_fromCity = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("fromCity"));
            var cmb_toCity = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("toCity"));
            var cmb_class = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("Class"));
            var cmb_numOfTickets = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTickets"));
            var textBox_Date = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("datePicker"));
            var btn_findFlights = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));


            cmb_fromCity.Click();         
            foreach (var city in cmb_fromCity.Items)
            {
                if (city.Name == "Frankfurt") { city.Click(); }
            }
            Thread.Sleep(1000);  // Pause to see 

            cmb_toCity.Click();
            Thread.Sleep(1000);  // Pause to see 
            foreach (var city in cmb_toCity.Items)
            {
                if (city.Name == "Sydney") { city.Click(); }
            }
            

            textBox_Date.Click();
            textBox_Date.SetValue(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL+"A");
            textBox_Date.SetValue(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.BACKSPACE);

            cmb_class.Click();
            Thread.Sleep(1000);  // Pause to see
            foreach (var item in cmb_class.Items)
            {
                if (item.Name == "First") { item.Click(); }
            }
            

            cmb_numOfTickets.Click();
            Thread.Sleep(1000);  // Pause to see
            foreach (var item in cmb_numOfTickets.Items)
            {
                if (item.Name == "3") { item.Click(); }
            }
           

            btn_findFlights.Click();
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

    public static class ErrorMsg
    {
        public const string onlyNubmers = "Enter a number.";
        public const string notExist = "Order number does not exist.";
        public const string lessThanZero = "Enter a number greater than 0.";
        
    }
}

























//



//  Keyboard.Instance.Enter("text to check");