using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace Flights.Actions
{
    public static class SeachOrderTab
    {
        #region UI elements
        static Window FlightsMainWindow { get { return Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample")); } }
        static RadioButton radioBtn_orderNumber { get { return FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio")); } }
        static RadioButton radioBtn_nameOrDate { get { return FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNameOrDateRadio")); } }
        static Button btn_SEARCH { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn")); } }
        static Button btn_DeleteOrder { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("")); } }
        static Label label_OrderDeleted { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("orderDeleted")); } }
        static TextBox textBox_orderNumber { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark")); } }
        static ComboBox flightClassCombo { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("flightClassCombo"));} }
        static ComboBox numOfTicketsCombo { get { return  FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTicketsCombo"));} }
        static TextBox passengerName { get { return  FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName"));} }
        static Label flightNumber { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("flightNumber")); } }
        #endregion 

        public static void EnableOrderNumberSearch()
        {
            radioBtn_orderNumber.Click();
        }

        public static void EnableNameOrDateSearch()
        {
            radioBtn_nameOrDate.Click();
        }

        public static void startSearch()
        {
            btn_SEARCH.Click();
        }

        public static void DeleteOrder()
        {
            btn_DeleteOrder.Click();
            Thread.Sleep(1000);
        }

        public static string DeleteOrderNumber()
        {
            Thread.Sleep(500);
            string OrderDeleted = label_OrderDeleted.Name;        
            char[] _splitchar = { ' ' };
            string[] OrderDeletedArrow = OrderDeleted.Split(_splitchar);
            string orderNumber = OrderDeletedArrow[1];
            return orderNumber;
        }

        public static void EnableNameOrDate()
        {
            radioBtn_orderNumber.Click();
        }
        
        public static void SetOrderNumber(string value)
        {
            textBox_orderNumber.SetValue(value);
            Thread.Sleep(500);
        }

        public static bool isOrderNumberEnabled()
        {
            return textBox_orderNumber.Enabled;
        }

        public static bool isSearchButtonEnabled()
        {
            return btn_SEARCH.Enabled;
        }


        public static List<string>  GetOpenedOrderDetails()
        {
            

            string classRate = flightClassCombo.SelectedItemText;
            string numOfTickets = numOfTicketsCombo.SelectedItemText;
            string passenger = passengerName.Text;
            string number = flightNumber.Text;  

             List<string> actualOrderData = new List<string>();
             actualOrderData.Add(classRate);
             actualOrderData.Add(numOfTickets);
             actualOrderData.Add(passenger);
             actualOrderData.Add(number);

             return actualOrderData;

        }
    }
}
