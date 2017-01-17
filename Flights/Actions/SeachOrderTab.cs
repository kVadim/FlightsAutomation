using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace Flights.Actions
{
    public static class SeachOrderTab
    {

        public static void EnableOrderNumberSearch()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            RadioButton radioBtn_orderNumber = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio"));
            radioBtn_orderNumber.Click();
        }

        public static void EnableNameOrDateSearch()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            RadioButton radioBtn_NameOrDate = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNameOrDateRadio"));
            radioBtn_NameOrDate.Click();
        }

        public static void Search()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            Button btn_SEARCH = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn"));
            btn_SEARCH.Click();
        }

        public static bool CheckOrderDetails()
        {
            return true;
        }

        public static void DeleteOrder()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            Button btn_DeleteOrder = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));
            btn_DeleteOrder.Click();
            Thread.Sleep(1000);
        }

        public static string DeleteOrderNumber()
        {
            Thread.Sleep(500);
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            Label label_OrderDeleted = FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("orderDeleted"));
            string OrderDeleted = label_OrderDeleted.Name;        
            char[] _splitchar = { ' ' };
            string[] OrderDeletedArrow = OrderDeleted.Split(_splitchar);
            string orderNumber = OrderDeletedArrow[1];
            return orderNumber;
        }

        public static void EnableNameOrDate()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            RadioButton radioBtn_orderNumber = FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio"));
            radioBtn_orderNumber.Click();
        }
        
        public static void SetOrderNumber(string value)
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            TextBox textBox_orderNumber = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark"));
            textBox_orderNumber.SetValue(value);
            Thread.Sleep(500);
        }

        public static bool isOrderNumberEnabled()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            TextBox textBox_orderNumber = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark"));
            return textBox_orderNumber.Enabled;
        }

        public static bool isSearchButtonEnabled()
        {
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            Button btn_SEARCH = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn"));
            return btn_SEARCH.Enabled;
        }


        public static List<string>  GetOpenedOrderDetails()
        {

            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            Label fromCityActual = FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("departureInitials"));
            Label toCityActual = FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("arrivalInitials"));
            Label departureDate = FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("departureDate"));
            ComboBox flightClassCombo = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("flightClassCombo"));
            ComboBox numOfTicketsCombo = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTicketsCombo"));
            TextBox passengerName = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName"));

            string fromCity = fromCityActual.Name;
            string toCity =  toCityActual.Name;
            string date = departureDate.Name;
            string classRate = flightClassCombo.SelectedItemText;
            string numOfTickets = numOfTicketsCombo.SelectedItemText;
            string passenger = passengerName.Text;  

             List<string> actualOrderData = new List<string>();
             actualOrderData.Add(fromCity);
             actualOrderData.Add(toCity);
             actualOrderData.Add(date);
             actualOrderData.Add(classRate);
             actualOrderData.Add(numOfTickets);
             actualOrderData.Add(passenger);

             return actualOrderData;

        }
    }
}
