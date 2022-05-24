
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
using System;
using System.ComponentModel;
#endregion	  

namespace Mobile.FormModel {
    public class MotherFormModel : BaseFormModel, INotifyPropertyChanged {
        public Field FirstName { get; set; } = new Field();
        public Field LastName { get; set; } = new Field();
        public Field Nic { get; set; } = new Field();
        public Field Dob { get; set; } = new Field();
        public DateTime SelectedDob { get; set; } = Utils.GetCurrentDateTime();
        public Field Phone { get; set; } = new Field();
        public Field Email { get; set; } = new Field();
        public Field Address { get; set; } = new Field();
        public Field Occupation { get; set; } = new Field();
        public int MidwifeId { get; set; } = GlobalSetting.Instance.User.MidwifeId;

    }
}
