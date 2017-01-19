using Flights.Constants;

namespace Flights.Actions
{
    public static class ModalWindow
    {

        public static bool checkMessageAndClose(string msg)
        {
            bool isMgsCorrect = (msg == Element.ErrorMassage.Name);
            Element.ModalWindow_btn_OK.Click();
            return isMgsCorrect;
        }

    } 
}
