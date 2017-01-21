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

        public static bool login(string name = AppParam.DefaulName, string password = AppParam.DefaulPass, bool isNegativeCheck = false)
        {
            Logger.Log.Debug("Login Page Opened");
            Element.textBox_Name.SetValue(name);
            Element.textBox_Password.SetValue(password);
                try
                {
                    Element.btn_OK.Click();
                    if (!isNegativeCheck)
                    {
                        LogedIn = ("John Smith" == Element.usernameTitle.Name);
                        Logger.Log.Debug("Logen in");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Failed to login", ex);
                }
            
            return LogedIn;
        }

        public static bool isOKEnabled (string name, string password)
        {
            Logger.Log.Debug("Login Page Opened");
            Element.textBox_Name.SetValue(name);
            Element.textBox_Password.SetValue(password);
            if (!Element.btn_OK.Enabled)
            {
                Logger.Log.Info("Button Ok isn't enabled");
                return false;
            }
            else
            {
                Logger.Log.Error("Button Ok enabled despite name/password is empty");
                return false;
            }
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
            Logger.Log.Debug("SEARCH ORDER tab is opened");
            
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
            Logger.Log.Debug("BOOK FLIGHT tab is opened");
        }


        public static void CloseApp()
        {
            Element.FlightsMainWindow.Close();
            LogedIn = false;
            Logger.Log.Debug("Flight Application is closed");
        }


        public static void StartApp()
        {
            Process.Start(AppParam.PATH);
            Thread.Sleep(2500);
            Logger.Log.Debug("Flight Application is opened");
        }
    }
}
