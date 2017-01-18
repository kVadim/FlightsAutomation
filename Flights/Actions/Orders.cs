using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using Flights.Constants;

namespace Flights.Actions
{
    public static class Orders
    {
       
        public static List<string> generateOrderData()
        {
            List<string> classRates = new List<string> { "Economy", "Business", "First" };
            List<string> cities = new List<string> { "Denver", "Frankfurt", "London", "Los Angeles", "Paris", "Portland", "San Francisco", "Seattle", "Zurich", "Sydney" };

            Random rnd = new Random();
            string fromCity, toCity;
            while (true)
            {
                fromCity = cities[rnd.Next(cities.Count)];
                toCity = cities[rnd.Next(cities.Count)];    
                if (fromCity != toCity)
                break;          
            }
            DateTime tomorrow = DateTime.Today.AddDays(1);

            string date = tomorrow.AddDays(rnd.Next(30)).ToString("dd'.'MM'.'yyyy");
            string classRate = classRates[rnd.Next(classRates.Count)];
            string numOfTickets = rnd.Next(1, 99).ToString();

            List<string> order = new List<string>();
            order.Add(fromCity);
            order.Add(toCity);
            order.Add(date);
            order.Add(classRate);
            order.Add(numOfTickets);

            return order;
        }

        public static void CreateOrder(List<string> orderData)
        {
            string fromCity = orderData[0]; 
            string toCity = orderData[1]; 
            string date = orderData[2]; 
            string classRate = orderData[3];
            string numOfTickets = orderData[4];


            Element.cmb_fromCity.Click();
            Thread.Sleep(1000);  // Pause to see 
            foreach (var city in Element.cmb_fromCity.Items) 
            {
                if (city.Name == fromCity) { city.Click(); }
            }

            Element.cmb_toCity.Click();
            Thread.Sleep(1000);  // Pause to see 
            foreach (var city in Element.cmb_toCity.Items)
            {
                if (city.Name == toCity) { city.Click(); }
            }

            Element.textBox_Date.SetValue(date);

            Element.cmb_class.Click();
            Thread.Sleep(1000);  // Pause to see
            foreach (var item in Element.cmb_class.Items)
            {
                if (item.Name == classRate) { item.Click(); }
            }

            Element.cmb_numOfTickets.Click();
            Thread.Sleep(1000);  // Pause to see
            foreach (var item in Element.cmb_numOfTickets.Items)
            {
                if (item.Name == numOfTickets) { item.Click(); }
            }

            Element.btn_findFlights.Click();
        }

        public static List<string> SelectRandomFlight()
        {
            var SelectFlightsWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            Label fromCity = SelectFlightsWindow.Get<Label>(SearchCriteria.ByAutomationId("fromCity"));
            Label toCity = SelectFlightsWindow.Get<Label>(SearchCriteria.ByAutomationId("toCity"));
            Button btn_selectFlight = SelectFlightsWindow.Get<Button>(SearchCriteria.ByAutomationId("selectFlightBtn"));
            ListView flights = SelectFlightsWindow.Get<ListView>(SearchCriteria.ByAutomationId("flightsDataGrid"));

            Random rnd = new Random();
            var randomFlight = flights.Rows[rnd.Next(flights.Rows.Count)];           
            randomFlight.Click();

            string from = fromCity.Name.Substring(6, fromCity.Name.Length-6);
            string to = toCity.Name.Substring(4, toCity.Name.Length-4);
            string date = Convert.ToDateTime(randomFlight.Cells[6].Name).ToString("dd.MM.yyyy");
            string fligthNumber = randomFlight.Cells[7].Name;

            List<string> flightData = new List<string>();
            flightData.Add(from);
            flightData.Add(to);
            flightData.Add(date);
            flightData.Add(fligthNumber);

            btn_selectFlight.Click();
            return flightData;
        }

            public static string GetActualOrderNumber(string passenger)
        {
            var FlightsDetailsWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            TextBox textBox_PassengerName = FlightsDetailsWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName"));
            Button btn_Order = FlightsDetailsWindow.Get<Button>(SearchCriteria.ByAutomationId("orderBtn"));

            textBox_PassengerName.SetValue(passenger);  
            btn_Order.Click();

            Thread.Sleep(1500);
            Label label_OrderCompleted = FlightsDetailsWindow.Get<Label>(SearchCriteria.ByAutomationId("orderCompleted"));
            string OrderCompleted = label_OrderCompleted.Name;
            char[] _splitchar = { ' ' };
            string[] OrderCompletedArrow = OrderCompleted.Split(_splitchar);
            string orderNumber = OrderCompletedArrow[1];

            Button btn_NewSearch = FlightsDetailsWindow.Get<Button>(SearchCriteria.ByAutomationId("newSearchBtn"));
            btn_NewSearch.Click();

            return orderNumber;
        }
    }



}


