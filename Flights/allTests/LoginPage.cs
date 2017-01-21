using Flights.Actions;
using NUnit.Framework;

namespace Flights.allTests
{
    [TestFixture]
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
            bool isNegativeCheck = true;
            Navigate.login(name, password, isNegativeCheck);
            Assert.IsTrue(ModalWindow.checkMessageAndClose(errorMessage));
        }


        [Test]
        public void loginCheck()
        {
            Assert.IsTrue(Navigate.login());
        }


        [Test, Sequential]
        public void OK_btn_AvailabilityCheck(
                                    [Values(AppParam.DefaulName, "")]string name,
                                    [Values("", AppParam.DefaulPass)]string password
                                    )
        {
            Assert.IsTrue(!Navigate.isOKEnabled(name, password));
        }
    }
}



//public static readonly ILog log = LogManager.GetLogger();