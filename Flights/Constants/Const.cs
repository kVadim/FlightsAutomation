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
using Flights.Actions;
using TestStack.White.UIItems.ListBoxItems;

namespace Flights
{
    
    public static class AppParameters
    {
        public const string PATH = "D:\\ADM Automation\\ADM exam task\\ADM exam task GUI\\Flights Application\\FlightsGUI.exe";
     // public const string PATH = "D:\\Flights Application\\FlightsGUI.exe"; 
        public const string ProcessName = "FlightsGUI";
    }

    public static class ExpectedMsg
    {
        //orderNumber errors
        public const string onlyNubmers = "Enter a number.";
        public const string notExist = "Order number does not exist.";
        public const string lessThanZero = "Enter a number greater than 0.";

        //login errors
        public const string wrongCredentials = "Incorrect username or password.\r\nUse: Username=john, Password=HP";
        public const string tooShortUsername = "Username must be at least 4 characters long";

        //notifications
        public const string confirmToDelete = "Are you sure you want to delete this order?";
    }

   
}

























//



//  Keyboard.Instance.Enter("text to check");