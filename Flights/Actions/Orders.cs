using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Flights.Constants;
using Flights.Helpers;
using System.Globalization;

namespace Flights.Actions
{
    public static class Orders
    {
        public static List<string> generateOrderData(int i)
        {
            List<string> classRates = new List<string> { "Economy", "Business", "First" };
            List<string> cities = new List<string> { "Denver", "Frankfurt", "London", "Los Angeles", "Paris", "Portland", "San Francisco", "Seattle", "Zurich", "Sydney" };

            string currentPassenger = "passanger" + i.ToString();
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
            string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            string date = tomorrow.AddDays(rnd.Next(30)).ToString(sysFormat);
            string classRate = classRates[rnd.Next(classRates.Count)];
            string numOfTickets = rnd.Next(1, 99).ToString();

            List<string> order = new List<string>();
            order.Add(currentPassenger);
            order.Add(fromCity);
            order.Add(toCity);
            order.Add(date);
            order.Add(classRate);
            order.Add(numOfTickets);

            Logger.Log.Info("ITTERATION: "+ i);
            Logger.Log.Debug("Generated Passenger      : " + order[0]);
            Logger.Log.Debug("Generated Order City From: " + order[1]);
            Logger.Log.Debug("Generated Order City To  : " + order[2]);
            Logger.Log.Debug("Generated Order Date     : " + order[3]);
            Logger.Log.Debug("Generated Order Class    : " + order[4]);
            Logger.Log.Debug("Generated Order №Tickets : " + order[5]);

            return order;
        }

        public static void CreateOrder(List<string> orderData)
        {
            string fromCity = orderData[1]; 
            string toCity = orderData[2]; 
            string date = orderData[3]; 
            string classRate = orderData[4];
            string numOfTickets = orderData[5];


            Element.cmb_fromCity.Click();                    
            foreach (var city in Element.cmb_fromCity.Items) 
            {
                if (city.Name == fromCity) { city.Select(); }
            }

            Element.cmb_toCity.Click();
            foreach (var city in Element.cmb_toCity.Items)
            {
                if (city.Name == toCity) { city.Select(); }
            }

            Element.textBox_Date.SetValue(date);

            Element.cmb_class.Click();
            foreach (var item in Element.cmb_class.Items)
            {
                if (item.Name == classRate) { item.Select();}
            }

            Element.cmb_numOfTickets.Click();
            foreach (var item in Element.cmb_numOfTickets.Items)
            {
                if (item.Name == numOfTickets) { item.Select();}
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
            string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            string from = Element.fromCity.Name.Substring(6, Element.fromCity.Name.Length - 6);
            string to = Element.toCity.Name.Substring(4, Element.toCity.Name.Length - 4);
            string date = Convert.ToDateTime(randomFlight.Cells[6].Name).ToString(sysFormat);
            string fligthNumber = randomFlight.Cells[7].Name;

            List<string> flightData = new List<string>();
            flightData.Add(fligthNumber);
            flightData.Add(from);
            flightData.Add(to);
            flightData.Add(date);
            

            Element.btn_selectFlight.Click();

            Logger.Log.Info("Random Flight is selected");
            Logger.Log.Debug("Selected Random Flight number   : " + fligthNumber);
            Logger.Log.Debug("Selected Random Flight city From: " + from);
            Logger.Log.Debug("Selected Random Flight city To  : " + to);
            Logger.Log.Debug("Selected Random Flight city date: " + date);

            return flightData;
        }

        public static string GetActualOrderNumber(string passenger)
        {
            Element.textBox_PassengerName.SetValue(passenger);
            Element.btn_Order.Click();
            wait.waitForObject(() => Element.label_OrderCompleted);
            string OrderCompleted = Element.label_OrderCompleted.Name;
            char[] _splitchar = { ' ' };
            string[] OrderCompletedArrow = OrderCompleted.Split(_splitchar);
            string orderNumber = OrderCompletedArrow[1];

            Element.btn_NewSearch.Click();
            Logger.Log.Info("Created Order Number    : " + orderNumber);

            return orderNumber;
        }

        public static bool isEqual(string expected, string actual, string nameExpected, string nameActual)
        {
            bool currentCheck = expected.Equals(actual);
            if (currentCheck)
            {
                Logger.Log.Info(nameExpected + " = " + nameActual + ": " + expected + "/" + actual);
            }
            else
            {
                Logger.Log.Error(nameExpected + " != " + nameActual + ": " + expected + "/" + actual);
            }

            return currentCheck;
        }
    }



}


