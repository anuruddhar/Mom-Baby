
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
    public class Field : INotifyPropertyChanged {
        public string StringVal { get; set; } = string.Empty;
        public decimal DecimalVal { get; set; } = 0;
        public DateTime DateTimeVal { get; set; } = DateTime.Now;

        public bool IsNotValid { get; set; } = false;
        public string NotValidMessageError { get; set; }

        public bool Enabled { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
