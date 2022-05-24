#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.iOS.Implementations
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
03/07/2018        1.0         Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Bluetooth;
using Mobile.iOS.Implementations;
using Mobile.Models.Bluetooth;
using System.Collections.ObjectModel;
using System.Threading;
#endregion

[assembly: Xamarin.Forms.Dependency(typeof(Bluetooth))]
namespace Mobile.iOS.Implementations  {
    public class Bluetooth : IBluetoothDevice {
        #region Private Variables
        private CancellationTokenSource _ct { get; set; }
        const int RequestResolveError = 1000;
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public Bluetooth() { }
        #endregion

        #region Methods

        #region IBth implementation
        public void Start(string name, int sleepTime = 200, bool readAsCharArray = false) { }

        public void Cancel() {}

        public ObservableCollection<BluetoothDeviceInfo> PairedDevices() {
            return new ObservableCollection<BluetoothDeviceInfo>();
        }
        #endregion

        #endregion
    }
}