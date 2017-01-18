using System.Collections.Generic;
using System.Threading;
using Flights.Constants;

namespace Flights.Actions
{
    public static class SearchOrderTab
    {

        public static void EnableOrderNumberSearch()
        {
            Element.radioBtn_OrderNumber.Click();
        }

        public static void EnableNameOrDateSearch()
        {
            Element.radioBtn_NameOrDate.Click();
        }

        public static void startSearch()
        {
            Element.btn_SEARCH.Click();
        }

        public static void DeleteOrder()
        {
            Element.btn_DeleteOrder.Click();
            Thread.Sleep(1000);
        }

        public static string DeleteOrderNumber()
        {
            Thread.Sleep(500);
            string OrderDeleted = Element.label_OrderDeleted.Name;        
            char[] _splitchar = { ' ' };
            string[] OrderDeletedArrow = OrderDeleted.Split(_splitchar);
            string orderNumber = OrderDeletedArrow[1];
            return orderNumber;
        }

        public static void EnableNameOrDate()
        {
            Element.radioBtn_OrderNumber.Click();
        }
        
        public static void SetOrderNumber(string value)
        {
            Element.textBox_OrderNumber.SetValue(value);
            Thread.Sleep(500);
        }

        public static bool isOrderNumberEnabled()
        {
            return Element.textBox_OrderNumber.Enabled;
        }

        public static bool isSearchButtonEnabled()
        {
            return Element.btn_SEARCH.Enabled;
        }


        public static List<string>  GetOpenedOrderDetails()
        {
            string classRate = Element.flightClassCombo.SelectedItemText;
            string numOfTickets = Element.numOfTicketsCombo.SelectedItemText;
            string passenger = Element.passengerName.Text;
            string number = Element.flightNumber.Text;  

            List<string> actualOrderData = new List<string>();
            actualOrderData.Add(classRate);
            actualOrderData.Add(numOfTickets);
            actualOrderData.Add(passenger);
            actualOrderData.Add(number);

             return actualOrderData;
        }
    }
}
