using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Flights.Actions;
using Flights.allTests;
using System.Collections.Generic;

namespace Flights
{
    [TestFixture]
    public class End2End: BaseTest
    {       

        [Test]
        public void E2E([Values(3)]int iter) //number of orders to be created
        {
            Navigate.login(); //to some tab

            List<string> createdOrders = new List<string>();
            List<string> deletedOrders = new List<string>();

            for (int i = 1; i <= iter; i++)
            {
                Dictionary<string, string> RandomDataForOrder = Orders.generateOrderData();
                string currentOrderNumber = Orders.CreateOrder(RandomDataForOrder);
                createdOrders.Add(currentOrderNumber);
            }

            Navigate.CloseApp();
            Navigate.StartApp();
            Navigate.OpenSearchTab();
            SeachOrderTab.EnableOrderNumberSearch();

            for (int i = 1; i < iter; i++)
            {
                SeachOrderTab.SetOrderNumber(createdOrders[i-1]);
                SeachOrderTab.Search();
                //assert is opened
                Assert.IsTrue(SeachOrderTab.CheckOrderDetails());
                SeachOrderTab.DeleteOrder();
                Assert.IsTrue(ModalWindow.checkMessageAndClose(ExpectedMsg.confirmToDelete));
                string deletedOrderNumber = SeachOrderTab.DeleteOrderNumber();
                deletedOrders.Add(deletedOrderNumber);
            }

            Assert.IsTrue(createdOrders == deletedOrders);


        }
    }
}

























//



//  Keyboard.Instance.Enter("text to check");