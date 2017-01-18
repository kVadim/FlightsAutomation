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

            List<List<string>> createdOrders = new List<List<string>>();
            List<string> createdOrdersNumbers = new List<string>();
            List<string> deletedOrdersNumbers = new List<string>();

            for (int i = 1; i <= iter; i++)
            {
                List<string> RandomDataForOrder = Orders.generateOrderData();
                string currentOrderNumber = Orders.CreateOrder(RandomDataForOrder, "passanger" + i.ToString());
                createdOrdersNumbers.Add(currentOrderNumber);
                createdOrders.Add(RandomDataForOrder);
            }

            Navigate.CloseApp();
            Navigate.StartApp();
           

            for (int i = 1; i <= iter; i++)
            {
                Navigate.OpenSearchTab();
                SeachOrderTab.EnableOrderNumberSearch();
                SeachOrderTab.SetOrderNumber(createdOrdersNumbers[i-1]);
                SeachOrderTab.Search();
                //assert is opened
                //Assert.IsTrue(SeachOrderTab.CheckOrderDetails()); // not implemented
                List<string> currentlyOpenedOrderDetails =  SeachOrderTab.GetOpenedOrderDetails();
                Assert.IsTrue( Orders.compareCreatedAndActualOrders(currentlyOpenedOrderDetails, createdOrders[i - 1], i)); 
                SeachOrderTab.DeleteOrder();
                Assert.IsTrue(ModalWindow.checkMessageAndClose(ExpectedMsg.confirmToDelete), "incorrect Error message");
                string deletedOrderNumber = SeachOrderTab.DeleteOrderNumber();
                deletedOrdersNumbers.Add(deletedOrderNumber);
            }

                Assert.IsTrue(createdOrdersNumbers.SequenceEqual(deletedOrdersNumbers), "not all orders deleted"); 


        }
    }
}

























//



//  Keyboard.Instance.Enter("text to check");