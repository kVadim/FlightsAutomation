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
        //  log + sessions + logic
        [Test]
        public void E2E([Values(2)]int iter) //number of orders to be created
        {
            Navigate.OpenBookFlightTab(); 
           
            List<List<string>> createdOrders = new List<List<string>>();

            for (int i = 1; i <= iter; i++)
            {
                string currentPassenger = "passanger" + i.ToString();
                List<string> RandomDataForOrder = Orders.generateOrderData(i);
                
                Orders.CreateOrder(RandomDataForOrder);
                List<string> flightDetails = Orders.SelectRandomFlight(i);

                string actualFromCity = flightDetails[0];
                Assert.IsTrue(RandomDataForOrder[0].Equals(actualFromCity), "incorrect city FROM. Iter: " +
                    i + ", expected: " + RandomDataForOrder[0] + " actual: " + actualFromCity);

                string actualToCity = flightDetails[1];
                Assert.IsTrue(RandomDataForOrder[1].Equals(actualToCity), "incorrect city TO. Iter: " + i);

                string actualDate = flightDetails[2];
                Assert.IsTrue(RandomDataForOrder[2].Equals(actualDate), "incorrect date. Iter: " + i);

                string currentflightNumber = flightDetails[3];
                string currentOrderNumber = Orders.GetActualOrderNumber(currentPassenger);

                RandomDataForOrder.Add(currentPassenger);
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
                List<string> openedOrderDetails = SearchOrderTab.GetOpenedOrderDetails();

                string actualclass = openedOrderDetails[0];
                Assert.IsTrue(createdOrders[i - 1][3].Equals(actualclass), "incorrect class. Iter: " + i);

                string actualnumberOftickets = openedOrderDetails[1];
                Assert.IsTrue(createdOrders[i - 1][4].Equals(actualnumberOftickets), "incorrect number of tickets. Iter: " + i);

                string actualpassenger = openedOrderDetails[2];
                Assert.IsTrue(createdOrders[i - 1][5].Equals(actualpassenger), "incorrect passenger name. Iter: " + i);

                string actualFlightNumber = openedOrderDetails[3];
                Assert.IsTrue(createdOrders[i - 1][6].Equals(actualFlightNumber), "incorrect flight number. Iter: " + i);

                SearchOrderTab.DeleteOrder();

                Assert.IsTrue(ModalWindow.checkMessageAndClose(ExpectedMsg.confirmToDelete), "incorrect delete Error message. Iter: " + i);

                string deletedOrderNumber = SearchOrderTab.DeleteOrderNumber();
                Assert.IsTrue(createdOrders[i - 1][7].Equals(deletedOrderNumber), "incorrect delete order. Iter" + i);
            }
        }
    }
}

























//



//  Keyboard.Instance.Enter("text to check");