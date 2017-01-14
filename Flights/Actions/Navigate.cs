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

namespace Flights.Actions
{
    public static class Navigate
    {
        public static bool login(string name = "john", string password = "hp")
        {
            bool OK_btn_isClicked=false;

            var FlightsLoginDialog = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_Name = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("agentName"));
            var textBox_Password = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("password"));
            var btn_OK = FlightsLoginDialog.Get<Button>(SearchCriteria.ByAutomationId("okButton"));

            textBox_Name.SetValue(name);
            textBox_Password.SetValue(password);
            if (btn_OK.Enabled)
            {
                btn_OK.Click();
                OK_btn_isClicked = true;
            }
            return OK_btn_isClicked;
        }


        public static void OpenSearchTab()
        {
            login();
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var usernameTitle = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("usernameTitle"));
            var tabs = FlightsMainWindow.Get<Tab>(SearchCriteria.ByControlType(ControlType.Tab));
            tabs.SelectTabPage("SEARCH ORDER");
        }


        public static void CloseApp()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            FlightsMainWindow.Close();
        }


        public static void StartApp()
        {
            Process.Start(AppParameters.PATH);
            Thread.Sleep(2300);
        }
    }
}
