﻿using System;
using System.Collections.Generic;
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
       
        public static List<string> generateOrderData()
        {
            var classRates = new List<string> { "Economy", "Business", "First" };
            var cities = new List<string> { "Denver", "Frankfurt", "London", "Los Angeles", "Paris", "Portland", "San Francisco", "Seattle", "Zurich", "Sydney" };

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

        public static string CreateOrder(List<string> orderData, string passenger)
        {
            string fromCity = orderData[0]; 
            string toCity = orderData[1]; 
            string date = orderData[2]; 
            string classRate = orderData[3];
            string numOfTickets = orderData[4];

            //populateData();
            //selectRandomFlight();


            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var cmb_fromCity = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("fromCity"));
            var cmb_toCity = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("toCity"));
            var cmb_class = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("Class"));
            var cmb_numOfTickets = FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTickets"));
            var textBox_Date = FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PART_TextBox"));
            var btn_findFlights = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));


            cmb_fromCity.Click();
            Thread.Sleep(1000);  // Pause to see 
            foreach (var city in cmb_fromCity.Items) 
            {
                if (city.Name == fromCity) { city.Click(); }
            }

            cmb_toCity.Click();
            Thread.Sleep(1000);  // Pause to see 
            foreach (var city in cmb_toCity.Items)
            {
                if (city.Name == toCity) { city.Click(); }
            }

            textBox_Date.SetValue(date);

            cmb_class.Click();
            Thread.Sleep(1000);  // Pause to see
            foreach (var item in cmb_class.Items)
            {
                if (item.Name == classRate) { item.Click(); }
            }

            cmb_numOfTickets.Click();
            Thread.Sleep(1000);  // Pause to see
            foreach (var item in cmb_numOfTickets.Items)
            {
                if (item.Name == numOfTickets) { item.Click(); }
            }

            btn_findFlights.Click();

            var SelectFlightsWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var btn_selectFlight = FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("selectFlightBtn"));
            var flights = FlightsMainWindow.Get<ListView>(SearchCriteria.ByAutomationId("flightsDataGrid"));
            
             Random rnd = new Random();
             var firstFlight = flights.Rows[rnd.Next(flights.Rows.Count)];  

            firstFlight.Click();
            btn_selectFlight.Click();

            var FlightsDetailsWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var textBox_PassengerName = FlightsDetailsWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName"));
            var btn_Order = FlightsDetailsWindow.Get<Button>(SearchCriteria.ByAutomationId("orderBtn"));



            textBox_PassengerName.SetValue(passenger);  
            btn_Order.Click();

            Thread.Sleep(1500);
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


