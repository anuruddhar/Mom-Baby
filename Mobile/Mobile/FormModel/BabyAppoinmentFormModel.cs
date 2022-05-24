
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
using System.ComponentModel;
#endregion	  


namespace Mobile.FormModel {
    public class BabyAppoinmentFormModel : BaseFormModel, INotifyPropertyChanged {

        public Field Baby { get; set; } = new Field();
        public int SelectedBabyId { get; set; } = 0;
        public Field Weight { get; set; } = new Field();
        public Field Height { get; set; } = new Field();
        public Field Vaccine { get; set; } = new Field();
        public Field Instruction { get; set; } = new Field();
        public Satisfaction SatisfactionId { get; set; } = Satisfaction.Notavailable;
        public Field SignerName { get; set; } = new Field();
        public byte[] Signature { get; set; } = null;

    }
}
