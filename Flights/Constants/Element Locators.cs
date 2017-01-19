using System.Linq;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowItems;

namespace Flights.Constants
{
    public static class Element
    {
        static public Window FlightsMainWindow { get { return Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample")); } }
        static public Tab tabs { get { return FlightsMainWindow.Get<Tab>(SearchCriteria.ByControlType(ControlType.Tab)); } }

        #region Login page
        static public TextBox textBox_Name { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("agentName")); } }
        static public TextBox textBox_Password { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("password")); } }
        static public Button btn_OK { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("okButton")); } }
        #endregion

        #region BookFlight Tab
        static public ComboBox cmb_fromCity { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("fromCity")); } }
        static public ComboBox cmb_toCity { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("toCity")); } }
        static public TextBox textBox_Date { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PART_TextBox")); } }
        static public ComboBox cmb_class { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("Class")); } }
        static public ComboBox cmb_numOfTickets { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTickets")); } }

        static public Button btn_findFlights { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("")); } }
        #endregion 

        #region SearchOrder Tab
        static public RadioButton radioBtn_OrderNumber { get { return FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio")); } }
        static public RadioButton radioBtn_NameOrDate { get { return FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNameOrDateRadio")); } }
        static public Button btn_SEARCH { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn")); } }
        static public TextBox textBox_OrderNumber { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark")); } }
        #endregion 

        #region Order Details window
        static public Button btn_DeleteOrder { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("")); } }
        static public Label label_OrderDeleted { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("orderDeleted")); } }
        static public ComboBox flightClassCombo { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("flightClassCombo")); } }
        static public ComboBox numOfTicketsCombo { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTicketsCombo")); } }
        static public TextBox passengerName { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName")); } }
        static public Label flightNumber { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("flightNumber")); } }
        #endregion 

        #region Select Flight
        static public Label fromCity { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("fromCity"));} }
        static public Label toCity { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("toCity"));} }
        static public Button btn_selectFlight { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("selectFlightBtn")); } }
        #endregion
        
        #region Flight Details
        static public TextBox textBox_PassengerName { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName")); } }
        static public Label label_OrderCompleted { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("orderCompleted"));; } }
        static public Button btn_Order { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("orderBtn")); } }
        static public Button btn_NewSearch { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("newSearchBtn")); } }
        #endregion

        #region Modal Windows
        static public Window ErrorDialog { get { return FlightsMainWindow.ModalWindow(SearchCriteria.ByControlType(ControlType.Window)); } }
        static public Button ModalWindow_btn_OK { get { return ErrorDialog.Get<Button>(SearchCriteria.ByControlType(ControlType.Button)); } }
        static public Label ErrorMassage { get { return ErrorDialog.Get<Label>(SearchCriteria.ByClassName("Static")); } }
        #endregion
    }
}
