using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace Flights.Actions
{
    public static class SeachOrderTab
    {

        public static void EnableOrderNumberSearch()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var radioBtn_orderNumber = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio"));
            radioBtn_orderNumber.Click();
        }

        public static void EnableNameOrDateSearch()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var radioBtn_NameOrDate = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNameOrDateRadio"));
            radioBtn_NameOrDate.Click();
        }

        public static void Search()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var btn_SEARCH = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn"));
            btn_SEARCH.Click();
        }

        public static bool CheckOrderDetails()
        {
            return true;
        }

        public static void DeleteOrder()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var btn_DeleteOrder = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));
            btn_DeleteOrder.Click();
            Thread.Sleep(1000);
        }

        public static string DeleteOrderNumber()
        {
            Thread.Sleep(500);
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var label_OrderDeleted = FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("orderDeleted"));
            string OrderDeleted = label_OrderDeleted.Name;        
            char[] _splitchar = { ' ' };
            string[] OrderDeletedArrow = OrderDeleted.Split(_splitchar);
            string orderNumber = OrderDeletedArrow[1];
            return orderNumber;
        }

        public static void EnableNameOrDate()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var radioBtn_orderNumber = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio"));
            radioBtn_orderNumber.Click();
        }
        
        public static void SetOrderNumber(string value)
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_orderNumber = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark"));
            textBox_orderNumber.SetValue(value);
            Thread.Sleep(500);
        }

        public static bool isOrderNumberEnabled()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_orderNumber = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark"));
            return textBox_orderNumber.Enabled;
        }

        public static bool isSearchButtonEnabled()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var btn_SEARCH = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn"));
            return btn_SEARCH.Enabled;
        }
        
    }
}
