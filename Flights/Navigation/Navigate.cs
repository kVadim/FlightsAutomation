using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;

namespace Flights.Navigation
{
    public static class Navigate
    {
        public static void login(){

            var FlightsLoginDialog = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_Name = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("agentName"));
            var textBox_Password = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("password"));
            var btn_OK = FlightsLoginDialog.Get<Button>(SearchCriteria.ByAutomationId("okButton"));

            textBox_Name.SetValue("john");
            textBox_Password.SetValue("hp");
            btn_OK.Click();
        }

        public static void OpenSearchTab()
        {
            login();
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var usernameTitle = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("usernameTitle"));
            var tabs = FlightsMainWindow.Get<Tab>(SearchCriteria.ByControlType(ControlType.Tab));
            tabs.SelectTabPage("SEARCH ORDER");
        }

    }
}
