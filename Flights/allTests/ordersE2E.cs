using NUnit.Framework;
using System.Linq;
using Flights.Actions;
using Flights.allTests;
using System.Collections.Generic;
using System;

namespace Flights
{
    [TestFixture]
    public class End2End: BaseTest
    {       
        [Test]
        public void E2E([Values(1)]int iter) //number of orders to be created
        {
            Navigate.OpenBookFlightTab(); 
            List<List<string>> createdOrders = new List<List<string>>();
            string expected;
            string actual;

            for (int i = 1; i <= iter; i++)
            {
                List<string> RandomDataForOrder = Orders.generateOrderData(i);
                
                Orders.CreateOrder(RandomDataForOrder);
                List<string> flightDetails = Orders.SelectRandomFlight(i);

                expected = RandomDataForOrder[1];
                actual = flightDetails[1];
                bool FromCity = Orders.isEqual(expected, actual, "Genetated CityFROM", "Flight CityFROM");
                Assert.IsTrue(FromCity);

                expected = RandomDataForOrder[2];
                actual = flightDetails[2];
                bool ToCity = Orders.isEqual(expected, actual, "Genetated  City TO", "Flight  City TO");
                Assert.IsTrue(ToCity);

                expected = RandomDataForOrder[3];
                actual = flightDetails[3];
                bool Date = Orders.isEqual(expected, actual, "Genetated Date", "Flight Date");
                Assert.IsTrue(Date);


                string currentflightNumber = flightDetails[0];
                string currentOrderNumber = Orders.GetActualOrderNumber(RandomDataForOrder[0]);

                RandomDataForOrder.Add(currentflightNumber);
                RandomDataForOrder.Add(currentOrderNumber);
                createdOrders.Add(RandomDataForOrder);
            }

            Navigate.CloseApp();
            Navigate.StartApp();
           
            for (int i = 1; i <= iter; i++)
            {
                Navigate.OpenSearchTab();
                SearchOrderTab.EnableOrderNumberSearch();
                SearchOrderTab.SetOrderNumber(createdOrders[i - 1][7]);
                SearchOrderTab.startSearch();
                List<string> openedOrderDetails = SearchOrderTab.GetOpenedOrderDetails(i);

                expected = createdOrders[i - 1][0];
                actual = openedOrderDetails[0];
                bool Passenger = Orders.isEqual(expected, actual,"Genetated Passenger", "Current Order Passenger");
                Assert.IsTrue(Passenger);

                expected = createdOrders[i - 1][6];
                actual = openedOrderDetails[1];
                bool FlightNumber = Orders.isEqual(expected, actual, "Genetated FlightNumber", "Current Order FlightNumber");
                Assert.IsTrue(FlightNumber);

                expected = createdOrders[i - 1][4];
                actual = openedOrderDetails[2];
                bool Class = Orders.isEqual(expected, actual, "Genetated Class", "Current Order Class" );
                Assert.IsTrue(Class);

                expected = createdOrders[i - 1][5];
                actual = openedOrderDetails[3];
                bool Tickets = Orders.isEqual(expected, actual, "Genetated Number of Tickets", "Current Order Number of Tickets");
                Assert.IsTrue(Tickets);


                SearchOrderTab.DeleteOrder();

                Assert.IsTrue(ModalWindow.checkMessageAndClose(ExpectedMsg.confirmToDelete));

                string deletedOrderNumber = SearchOrderTab.DeleteOrderNumber();

                expected = createdOrders[i - 1][7];
                actual = deletedOrderNumber;
                bool OrderNumber = Orders.isEqual(expected, actual, "Curent OrderNumber", "Deleted OrderNumber");
                Assert.IsTrue(OrderNumber);
             
            }
        }
    }
}

