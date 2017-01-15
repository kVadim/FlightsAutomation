using System.Linq;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace Flights.Actions
{
    public static class ModalWindow
    {

        public static bool checkMessageAndClose(string msg)
        {
            var FlightsCurrentWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
            var ErrorDialog = FlightsCurrentWindow.ModalWindow(SearchCriteria.ByControlType(ControlType.Window));
            var LoginFailed_btn_OK = ErrorDialog.Get<Button>(SearchCriteria.ByControlType(ControlType.Button));
            var ErrorMassage = ErrorDialog.Get<Label>(SearchCriteria.ByClassName("Static"));

            bool isMgsCorrect = (msg == ErrorMassage.Name);
            LoginFailed_btn_OK.Click();

            return isMgsCorrect;

        }

    } 
    //public static class NotificationWindow
    //    {
    //        public static bool checkNotificationMsgAndSubmit(string msg)
    //        {
    //            var FlightsCurrentWindow = Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample"));
    //            var NotificationDialog = FlightsCurrentWindow.ModalWindow(SearchCriteria.ByControlType(ControlType.Window));
    //            var btn_OK = NotificationDialog.Get<Button>(SearchCriteria.ByAutomationId("6"));
    //            var Massage = NotificationDialog.Get<Label>(SearchCriteria.ByClassName("Static"));

    //            bool isMgsCorrect = (msg == Massage.Name);
    //            btn_OK.Click();

    //            return isMgsCorrect;

    //        }

    //    }
}
