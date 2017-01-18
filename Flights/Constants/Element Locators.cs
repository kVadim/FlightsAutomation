using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace Flights.Constants
{
    public static class Element
    {
        static public Window FlightsMainWindow { get { return Desktop.Instance.Windows().First(w => w.Name.Contains("HPE MyFlight Sample")); } }

        #region SearchOrder Tab
        static public RadioButton radioBtn_OrderNumber { get { return FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNumberRadio")); } }
        static public RadioButton radioBtn_NameOrDate { get { return FlightsMainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("byNameOrDateRadio")); } }
        static public Button btn_SEARCH { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("searchBtn")); } }
        static public Button btn_DeleteOrder { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("")); } }
        static public Label label_OrderDeleted { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("orderDeleted")); } }
        static public TextBox textBox_OrderNumber { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("byNumberWatermark")); } }
        static public ComboBox flightClassCombo { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("flightClassCombo")); } }
        static public ComboBox numOfTicketsCombo { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTicketsCombo")); } }
        static public TextBox passengerName { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("passengerName")); } }
        static public Label flightNumber { get { return FlightsMainWindow.Get<Label>(SearchCriteria.ByAutomationId("flightNumber")); } }
        #endregion 

        #region BookFlight Tab
        static public ComboBox cmb_fromCity { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("fromCity"));} }
        static public ComboBox cmb_toCity { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("toCity"));} }
        static public ComboBox cmb_class { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("Class"));} }
        static public ComboBox cmb_numOfTickets { get { return FlightsMainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("numOfTickets"));} }
        static public TextBox textBox_Date { get { return FlightsMainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PART_TextBox"));} }
        static public Button btn_findFlights { get { return FlightsMainWindow.Get<Button>(SearchCriteria.ByAutomationId("")); } }
        #endregion 
    }
}
