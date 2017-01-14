using Flights.Actions;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace Flights.allTests
{
    public class LoginTests: BaseTest
    {
        [Test, Sequential]
        public void loginNegativeCheck(
                                [Values("bla",    "john",   "blabla" )]string name,
                                [Values("blabla", "blabla", "hp"     )]string password,
                                [Values(ErrorMsg.tooShortUsername,  
                                        ErrorMsg.wrongCredentials,
                                        ErrorMsg.wrongCredentials    )]string errorMessage
                                )
        {
            Navigate.login(name, password);

            var FlightsLoginDialog = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var LoginFailedDialog = FlightsLoginDialog.ModalWindow(SearchCriteria.ByControlType(ControlType.Window));
            var LoginFailed_btn_OK = LoginFailedDialog.Get<Button>(SearchCriteria.ByControlType(ControlType.Button));
            var ErrorMassage = LoginFailedDialog.Get<Label>(SearchCriteria.ByClassName("Static"));

            Assert.IsTrue(errorMessage == ErrorMassage.Name);

            Thread.Sleep(500);  //pause to see
            LoginFailed_btn_OK.Click();
            
        }


        [Test]
        public void loginCheck()
        {
            Navigate.login();
            
            string expectedValuePositive = "John Smith";
            var FlightsMainWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var usernameTitle = FlightsMainWindow.Get(SearchCriteria.ByAutomationId("usernameTitle"));

            Assert.IsTrue(expectedValuePositive == usernameTitle.Name);
            
        }


        [Test, Sequential]
        public void login_OKbtnCheck(
                                    [Values("john", ""  )]string name,
                                    [Values("",     "hp")]string password
                                    )
        {
            Assert.IsTrue(!Navigate.login(name, password));

        }
    }
}
