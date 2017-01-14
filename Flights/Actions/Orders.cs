using System.Linq;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace Flights.Actions
{
    public static class Orders
    {
        public static string CreateOrder(string fromCity, string toCity)
        {
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
                if (city.Name == fromCity) { city.Click(); }
            }
            Thread.Sleep(1000);  // Pause to see 

            cmb_toCity.Click();
            Thread.Sleep(1000);  // Pause to see 
            foreach (var city in cmb_toCity.Items)
            {
                if (city.Name == toCity) { city.Click(); }
            }


            textBox_Date.Click();
            textBox_Date.SetValue(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL + "A");
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

            var SelectFlightsWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var btn_selectFlight = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("selectFlightBtn"));
            var flights = FlightsMainWindow.Get<ListView>(SearchCriteria.ByAutomationId("flightsDataGrid"));
            var firstFlight = flights.Rows[0];

            firstFlight.Click();
            btn_selectFlight.Click();

            var FlightsDetailsWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_PassengerName = FlightsDetailsWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName"));
            var btn_Order = FlightsDetailsWindow.Get<Button>(SearchCriteria.ByAutomationId("orderBtn"));



            textBox_PassengerName.SetValue("passenger1");
            btn_Order.Click();

            var label_OrderCompleted = FlightsDetailsWindow.Get<Label>(SearchCriteria.ByAutomationId("orderCompleted"));
            string OrderCompleted = label_OrderCompleted.Name;
            char[] _splitchar = { ' ' };
            string[] OrderCompletedArrow = OrderCompleted.Split(_splitchar);
            string orderNumber = OrderCompletedArrow[1];

            var btn_NewSearch = FlightsDetailsWindow.Get<Button>(SearchCriteria.ByAutomationId("newSearchBtn"));
            btn_NewSearch.Click();

            return orderNumber;
           
        }

    }
}
