using Flights.Constants;
using Flights.Helpers;

namespace Flights.Actions
{
    public static class ModalWindow
    {

        public static bool checkMessageAndClose(string msg)
        {
            Logger.Log.Info("Error message check");
            wait.waitForObject(() => Element.ErrorMassage);
            bool isMgsCorrect = (msg == Element.ErrorMassage.Name);
            if (!isMgsCorrect)
            {
                Logger.Log.Error("incorrect error message, expected: " + msg + " actual:" + Element.ErrorMassage.Name);
            }
            else
            {
                Logger.Log.Info("Error message is correct");
            }
            Element.ModalWindow_btn_OK.Click();
            return isMgsCorrect;
        }

    } 
}
