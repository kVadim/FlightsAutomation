using System.Collections.Generic;
using System.Threading;
using Flights.Constants;
using System;

namespace Flights.Actions
{
    public static class SearchOrderTab
    {

        public static void EnableOrderNumberSearch()
        {
            Element.radioBtn_OrderNumber.Click();
            Logger.Log.Debug("Click radiobutton Order_Number");
        }

        public static void EnableNameOrDateSearch()
        {
            Element.radioBtn_NameOrDate.Click();
            Logger.Log.Debug("Click radiobutton Name_Or_Date");
        }

        public static void startSearch()
        {
            Element.btn_SEARCH.Click();
            Logger.Log.Debug("Start search");
        }

        public static void DeleteOrder()
        {
            try 
            {
                Element.btn_DeleteOrder.Click();
                Logger.Log.Info("Oreder is deteted");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Failed to delete", ex);
            }
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
            Logger.Log.Debug("Try search: Order Number - " + value);
        }

        public static bool isOrderNumberEnabled(bool expectedState)
        {
            bool actuaState = Element.textBox_OrderNumber.Enabled;
            if (actuaState && expectedState)
            {
                Logger.Log.Info("TextBox OrderNumber is Enabled WHEN radionbutton is checked");
            }
            else if (actuaState && !expectedState)
            {
                Logger.Log.Error("TextBox OrderNumber is not Disabled");
            }

            else if (!actuaState && !expectedState)
            {
                Logger.Log.Info("TextBox OrderNumber is Disabled WHEN radionbutton is unchecked");
            }

            else if (!actuaState && expectedState)
            {
                Logger.Log.Error("TextBox OrderNumber is  not Enabled");

            }
            return Element.textBox_OrderNumber.Enabled;
        }

        public static bool isSearchButtonEnabled(bool expectedState)
        {
            bool actuaState = Element.btn_SEARCH.Enabled;
            if (actuaState && expectedState)
            {
                 Logger.Log.Info("SearchButton is Enabled WHEN OrderNumber is not empty");           
            }
            else if (actuaState && !expectedState)
            {
                Logger.Log.Error("SearchButton is not Disabled");
            }

            else if (!actuaState && !expectedState)
            {
                Logger.Log.Info("SearchButton is Disabled WHEN OrderNumber is empty");
            }

            else if (!actuaState && expectedState)
            {
                Logger.Log.Error("SearchButton is  not Enabled");

            }

            return actuaState;
        }


        public static List<string>  GetOpenedOrderDetails(int i)
        {
            string classRate = Element.flightClassCombo.SelectedItemText;
            string numOfTickets = Element.numOfTicketsCombo.SelectedItemText;
            string passenger = Element.passengerName.Text;
            string number = Element.flightNumber.Text;  

            List<string> actualOrderData = new List<string>();
            actualOrderData.Add(passenger);
            actualOrderData.Add(number);
            actualOrderData.Add(classRate);
            actualOrderData.Add(numOfTickets);

            Logger.Log.Info("ITTERATION: " + i);
            Logger.Log.Info("Opened Order Passenger    : " + actualOrderData[0]);
            Logger.Log.Info("Opened Order Flight Number: " + actualOrderData[1]);
            Logger.Log.Info("Opened Order Order Class  : " + actualOrderData[2]);
            Logger.Log.Info("Opened Order № of Tickets : " + actualOrderData[3]);

            return actualOrderData;
        }
    }
}
