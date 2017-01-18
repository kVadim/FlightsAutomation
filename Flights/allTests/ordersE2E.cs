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
        // validation + log + sessions
        [Test]
        public void E2E([Values(2)]int iter) //number of orders to be created
        {
            Navigate.login(); //to some tab

            List<string> createdOrders = new List<string>();
            List<string> deletedOrders = new List<string>();

            for (int i = 1; i <= iter; i++)
            {
                List<string> RandomDataForOrder = Orders.generateOrderData();
                string currentOrderNumber = Orders.CreateOrder(RandomDataForOrder, "passanger" + i.ToString());
                createdOrders.Add(currentOrderNumber);
            }

            Navigate.CloseApp();
            Navigate.StartApp();
           

            for (int i = 1; i <= iter; i++)
            {
                Navigate.OpenSearchTab();
                SeachOrderTab.EnableOrderNumberSearch();
                SeachOrderTab.SetOrderNumber(createdOrders[i-1]);
                SeachOrderTab.Search();
                //assert is opened
                //Assert.IsTrue(SeachOrderTab.CheckOrderDetails()); // not implemented
                SeachOrderTab.DeleteOrder();
                Assert.IsTrue(ModalWindow.checkMessageAndClose(ExpectedMsg.confirmToDelete), "incorrect Error message");
                string deletedOrderNumber = SeachOrderTab.DeleteOrderNumber();
                deletedOrders.Add(deletedOrderNumber);
            }

                Assert.IsTrue(createdOrders.SequenceEqual(deletedOrders), "not all orders deleted"); 


        }
    }
}

























//



//  Keyboard.Instance.Enter("text to check");