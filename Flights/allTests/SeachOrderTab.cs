using NUnit.Framework;
using Flights.Actions;
using Flights.allTests;

namespace Flights
{
    [TestFixture]
    public class OrderNumberCheck: BaseTest
    {       
        [Test]
        public void searchButtonAvailability()
         {
            Navigate.OpenSearchTab();
            SeachOrderTab.EnableOrderNumberSearch();
            SeachOrderTab.SetOrderNumber("123");
            Assert.IsTrue(SeachOrderTab.isSearchButtonEnabled());
            SeachOrderTab.SetOrderNumber("");
            Assert.IsTrue(!SeachOrderTab.isSearchButtonEnabled());
        }

        [Test]
        public void orderNumberAvailability()
        {
            Navigate.OpenSearchTab();
            SeachOrderTab.EnableOrderNumberSearch();
            Assert.IsTrue(SeachOrderTab.isOrderNumberEnabled());
            SeachOrderTab.EnableNameOrDateSearch();
            Assert.IsTrue(!SeachOrderTab.isOrderNumberEnabled());
        }


        [Test, Sequential]
        public void incorrectOrderNumber(
                                        [Values("Some text",           "3333333",        "-5555"               )]string orderNumber,
                                        [Values(ExpectedMsg.onlyNubmers, ExpectedMsg.notExist, ExpectedMsg.lessThanZero )]string errorMessage
                                        )
        {
            Navigate.OpenSearchTab();
            SeachOrderTab.EnableOrderNumberSearch();
            SeachOrderTab.SetOrderNumber(orderNumber);
            SeachOrderTab.startSearch();

            Assert.IsTrue(ModalWindow.checkMessageAndClose(errorMessage));
        }
    }
}

























//



//  Keyboard.Instance.Enter("text to check");