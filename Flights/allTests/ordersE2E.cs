using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Flights.Actions;
using Flights.allTests;

namespace Flights
{
    [TestFixture]
    public class End2End: BaseTest
    {       

        [Test]
        public void E2E()
        {
            //Random rnd = new Random();
            //string[] Cities = new string[] { "Denver", "Frankfurt", "London", "Los Angeles", "Portland" "Paris", "Sydney" };

            //for (int i = 1; 1 < 4; i++ )
            //{
            //    int randomItem1 = rnd.Next(0, Cities.Length - 1);
            //    int randomItem2 = rnd.Next(0, Cities.Length - 1);
            //    string orderNumber1 = Orders.CreateOrder(Cities[randomItem1], Cities[randomItem2]);
            //}



            Navigate.login();
            string orderNumber1 = Orders.CreateOrder("Frankfurt", "Sydney");
            //string orderNumber2 = Orders.CreateOrder("London", "Paris");
            //string orderNumber3 = Orders.CreateOrder("Portland", "Denver");
            //Console.WriteLine(orderNumber1, orderNumber2, orderNumber3);

            Navigate.CloseApp();
            Navigate.StartApp();
            Navigate.OpenSearchTab();
            SeachOrderTab.EnableOrderNumberSearch();
            SeachOrderTab.SetOrderNumber("95");
            SeachOrderTab.Search();
            //assert is opened
            Assert.IsTrue(SeachOrderTab.CheckOrderDetails());
            SeachOrderTab.DeleteOrder();
            Assert.IsTrue(ModalWindow.checkMessageAndClose(ExpectedMsg.confirmToDelete));
            string deletedOrderNumber = SeachOrderTab.DeleteOrderNumber();
        }
    }
}

























//



//  Keyboard.Instance.Enter("text to check");