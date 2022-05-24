
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
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
#endregion	

namespace Mobile.FormModel {
    public class MotherAppoinmentFormModel : BaseFormModel, INotifyPropertyChanged {
        public Field Mother { get; set; } = new Field();
        public int SelectedMotherId { get; set; } = 0;
        public Field HealthCondition { get; set; } = new Field();
        public Field Weight { get; set; } = new Field();
        public Field BloodPressure { get; set; } = new Field();
        public Field GlucouseLevel { get; set; } = new Field();
        public Field Vaccine { get; set; } = new Field();
        public Field Instruction { get; set; } = new Field();
        public Satisfaction SatisfactionId { get; set; } = Satisfaction.Notavailable;
        public Field SignerName { get; set; } = new Field();
        public byte[] Signature { get; set; } = null;




    }
}
