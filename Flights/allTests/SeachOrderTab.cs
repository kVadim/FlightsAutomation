using NUnit.Framework;
using Flights.Actions;
using Flights.allTests;

namespace Flights
{
    [TestFixture]
    public class OrderNumberCheck: BaseTest
    {
        [Test]
        public void searchButton_AvailabilityCheck()
         {
            Navigate.OpenSearchTab();
            SearchOrderTab.EnableOrderNumberSearch();
            SearchOrderTab.SetOrderNumber("123");
            Assert.IsTrue(SearchOrderTab.isSearchButtonEnabled(true));
            SearchOrderTab.SetOrderNumber("");
            Assert.IsTrue(!SearchOrderTab.isSearchButtonEnabled(false));
        }

        [Test]
        public void orderNumber_AvailabilityCheck()
        {
            Navigate.OpenSearchTab();
            SearchOrderTab.EnableOrderNumberSearch();
            Assert.IsTrue(SearchOrderTab.isOrderNumberEnabled(true));
            SearchOrderTab.EnableNameOrDateSearch();
            Assert.IsTrue(!SearchOrderTab.isOrderNumberEnabled(false));
        }


        [Test, Sequential]
        public void incorrect_OrderNumber(
                                        [Values("TextVaule", "3333333","-5555")]string orderNumber,
                                        [Values(ExpectedMsg.onlyNubmers, 
                                                ExpectedMsg.notExist, 
                                                ExpectedMsg.lessThanZero )]string errorMessage
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