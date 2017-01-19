using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Flights.Constants;

namespace Flights.Actions
{
    public static class Orders
    {
        public static List<string> generateOrderData(int i)
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

            Logger.Log.Info("ITTERATION: "+ i);
            Logger.Log.Info("Generated Order City From: " + fromCity);
            Logger.Log.Info("Generated Order City To  : " + toCity);
            Logger.Log.Info("Generated Order Date     : " + date);
            Logger.Log.Info("Generated Order Class    : " + classRate);
            Logger.Log.Info("Generated Order №Tickets : " + numOfTickets);

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
            Thread.Sleep(1200);  // Pause to see 
            foreach (var city in Element.cmb_fromCity.Items) 
            {
                if (city.Name == fromCity) { city.Click(); }
            }

            Element.cmb_toCity.Click();
            Thread.Sleep(1200);  // Pause to see 
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
            Logger.Log.Info("Order created");
        }

        public static List<string> SelectRandomFlight(int i)
        {
            ListView flights = Element.FlightsMainWindow.Get<ListView>(SearchCriteria.ByAutomationId("flightsDataGrid"));
            Random rnd = new Random();
            var randomFlight = flights.Rows[rnd.Next(flights.Rows.Count)];           
            randomFlight.Click();

            string from = Element.fromCity.Name.Substring(6, Element.fromCity.Name.Length - 6);
            string to = Element.toCity.Name.Substring(4, Element.toCity.Name.Length - 4);
            string date = Convert.ToDateTime(randomFlight.Cells[6].Name).ToString("dd.MM.yyyy");
            string fligthNumber = randomFlight.Cells[7].Name;

            List<string> flightData = new List<string>();
            flightData.Add(from);
            flightData.Add(to);
            flightData.Add(date);
            flightData.Add(fligthNumber);

            Element.btn_selectFlight.Click();

            Logger.Log.Info("Random Flight for is selected");
            Logger.Log.Info("Selected Flight number   : " + fligthNumber);
            Logger.Log.Info("Selected Flight city From: " + from);
            Logger.Log.Info("Selected Flight city To  : " + to);
            Logger.Log.Info("Selected Flight city date: " + date);

            return flightData;
        }

        public static string GetActualOrderNumber(string passenger)
        {
            Element.textBox_PassengerName.SetValue(passenger);
            Element.btn_Order.Click();
            Thread.Sleep(1500);

            string OrderCompleted = Element.label_OrderCompleted.Name;
            char[] _splitchar = { ' ' };
            string[] OrderCompletedArrow = OrderCompleted.Split(_splitchar);
            string orderNumber = OrderCompletedArrow[1];

            Element.btn_NewSearch.Click();
            Logger.Log.Info("Created Order Passenger : " + passenger);
            Logger.Log.Info("Created Order Number    : " + orderNumber);

            return orderNumber;
        }
    }



}


