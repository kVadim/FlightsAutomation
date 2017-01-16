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
            Button LoginFailed_btn_OK = ErrorDialog.Get<Button>(SearchCriteria.ByControlType(ControlType.Button));
            Label ErrorMassage = ErrorDialog.Get<Label>(SearchCriteria.ByClassName("Static"));

            bool isMgsCorrect = (msg == ErrorMassage.Name);
            LoginFailed_btn_OK.Click();

            return isMgsCorrect;

        }

    } 
}
