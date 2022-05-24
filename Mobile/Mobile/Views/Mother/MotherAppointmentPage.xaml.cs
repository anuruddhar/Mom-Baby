#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version        Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
16/03/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Views.Base;
#endregion


namespace Mobile.Views {
    public partial class MotherAppointmentPage : CustomContentPage {
        public MotherAppointmentPage() {
            try {
                InitializeComponent();
            } catch (System.Exception ex) {
                throw ex;
            }
        }
    }
}
