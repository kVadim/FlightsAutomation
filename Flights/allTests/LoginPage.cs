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
                                [Values(ExpectedMsg.tooShortUsername,  
                                        ExpectedMsg.wrongCredentials,
                                        ExpectedMsg.wrongCredentials    )]string errorMessage
                                )
        {
            Navigate.login(name, password);
            Assert.IsTrue(ModalWindow.checkMessageAndClose(errorMessage), "incorrect Error message");
        }


        [Test]
        public void loginCheck()
        {
            bool loggedIN = Navigate.login();
            Assert.IsTrue(loggedIN, "failed to login");
            
        }


        [Test, Sequential]
        public void login_OKbtnCheck(
                                    [Values("john", ""  )]string name,
                                    [Values("",     "hp")]string password
                                    )
        {
            Assert.IsTrue(!Navigate.login(name, password), "button OK isn't disbled");

        }
    }
}
