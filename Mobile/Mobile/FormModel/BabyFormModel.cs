
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Model
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
13/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using Mobile.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
#endregion	  

namespace Mobile.FormModel {
    public class BabyFormModel : BaseFormModel, INotifyPropertyChanged {
        
        public Field Mother { get; set; } = new Field();
        public int SelectedMotherId { get; set; } = 0;
        public Field FirstName { get; set; } = new Field();
        public Field LastName { get; set; } = new Field();
        public Field Dob { get; set; } = new Field();
        public DateTime SelectedDob { get; set; } = Utils.GetCurrentDateTime();
        public Field Sex { get; set; } = new Field();
        public int SelectedSexId { get; set; } = 0;

    }
}
