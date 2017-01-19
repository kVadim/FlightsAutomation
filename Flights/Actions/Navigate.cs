using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using Flights.Constants;

namespace Flights.Actions
{
    public static class Navigate
    {
        public static bool LogedIn = false;
        public static bool login(string name = "john", string password = "hp")
        {
            Element.textBox_Name.SetValue(name);
            Element.textBox_Password.SetValue(password);
            if (Element.btn_OK.Enabled)
            {
                Element.btn_OK.Click();
                LogedIn = true;
            }

            Logger.Log.Info("Logen in");
            return LogedIn;
        }


        public static void OpenSearchTab()
        {
            if (!LogedIn)
            {
                login();
            }

            if (!Element.tabs.Pages[1].IsSelected)
            {
                Element.tabs.SelectTabPage("SEARCH ORDER");
            }
            bool isOpened = Element.tabs.Pages[1].Enabled;
            Assert.IsTrue(isOpened, "failed to open SEARCH ORDER tab");
            Logger.Log.Info("SEARCH ORDER tab is opened");
            
        }

        public static void OpenBookFlightTab()
        {
            if (!LogedIn)
            {
                login();
            }

            if (!Element.tabs.Pages[0].IsSelected)
            {
                Element.tabs.SelectTabPage("BOOK FLIGHT");
            }
            bool isOpened = Element.tabs.Pages[0].Enabled;

            Assert.IsTrue(isOpened, "failed to open BOOK FLIGHT");
            Logger.Log.Info("BOOK FLIGHT tab is opened");
        }


        public static void CloseApp()
        {
            Element.FlightsMainWindow.Close();
            LogedIn = false;
            Logger.Log.Info("Application is closed");
        }


        public static void StartApp()
        {
            Process.Start(AppParameters.PATH);
            Thread.Sleep(2500);
            Logger.Log.Info("Login Page Opened");
        }
    }
}
