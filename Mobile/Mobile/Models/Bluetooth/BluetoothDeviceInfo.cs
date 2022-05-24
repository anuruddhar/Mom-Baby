#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Setting
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
18/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace

#endregion	  


namespace Mobile.Models.Bluetooth {

    public class BluetoothDeviceInfo {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DeviceName {
            get {
                return $"{Name}";
            }
        }
    }
}
