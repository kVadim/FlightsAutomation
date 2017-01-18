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
            SearchOrderTab.EnableOrderNumberSearch();
            SearchOrderTab.SetOrderNumber("123");
            Assert.IsTrue(SearchOrderTab.isSearchButtonEnabled());
            SearchOrderTab.SetOrderNumber("");
            Assert.IsTrue(!SearchOrderTab.isSearchButtonEnabled());
        }

        [Test]
        public void orderNumberAvailability()
        {
            Navigate.OpenSearchTab();
            SearchOrderTab.EnableOrderNumberSearch();
            Assert.IsTrue(SearchOrderTab.isOrderNumberEnabled());
            SearchOrderTab.EnableNameOrDateSearch();
            Assert.IsTrue(!SearchOrderTab.isOrderNumberEnabled());
        }


        [Test, Sequential]
        public void incorrectOrderNumber(
                                        [Values("Some text",           "3333333",        "-5555"               )]string orderNumber,
                                        [Values(ExpectedMsg.onlyNubmers, ExpectedMsg.notExist, ExpectedMsg.lessThanZero )]string errorMessage
                                        )
        {
            Navigate.OpenSearchTab();
            SearchOrderTab.EnableOrderNumberSearch();
            SearchOrderTab.SetOrderNumber(orderNumber);
            SearchOrderTab.startSearch();

            Assert.IsTrue(ModalWindow.checkMessageAndClose(errorMessage));
        }
    }
}

























//



//  Keyboard.Instance.Enter("text to check");