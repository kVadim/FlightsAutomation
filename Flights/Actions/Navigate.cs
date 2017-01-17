using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;

namespace Flights.Actions
{
    public static class Navigate
    {
        public static bool LogedIn = false;
        public static bool login(string name = "john", string password = "hp")
        {
            var FlightsLoginDialog = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            TextBox textBox_Name = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("agentName"));
            TextBox textBox_Password = FlightsLoginDialog.Get<TextBox>(SearchCriteria.ByAutomationId("password"));
            Button btn_OK = FlightsLoginDialog.Get<Button>(SearchCriteria.ByAutomationId("okButton"));

            textBox_Name.SetValue(name);
            textBox_Password.SetValue(password);
            if (btn_OK.Enabled)
            {
                btn_OK.Click();
                LogedIn = true;
            }
            return LogedIn;
        }


        public static void OpenSearchTab()
        {
            if (!LogedIn)
            {
                login();
            }
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var usernameTitle = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("usernameTitle"));
            Tab tabs = FlightsMainWindow.Get<Tab>(SearchCriteria.ByControlType(ControlType.Tab));
            tabs.SelectTabPage("SEARCH ORDER");
        }


        public static void CloseApp()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            FlightsMainWindow.Close();
            LogedIn = false;
        }


        public static void StartApp()
        {
            Process.Start(AppParameters.PATH);
            Thread.Sleep(2300);
        }
    }
}
