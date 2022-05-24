#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Helpers
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
18/02/2022        1.0          Anuruddha.Rajapaksha   	  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Bluetooth;
using System.Collections.ObjectModel;
#endregion	  

namespace Mobile.Bluetooth {
    public interface IBluetoothDevice {
        void Start(string name, int sleepTime, bool readAsCharArray);
        void Cancel();
        ObservableCollection<BluetoothDeviceInfo> PairedDevices();
    }
}
