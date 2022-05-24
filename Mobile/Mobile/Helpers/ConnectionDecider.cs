#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Helpers
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Enum;
using Xamarin.Essentials;
using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace Mobile.Helpers {
    public class ConnectionDecider
    {
        #region Variables
        private static readonly Lazy<ConnectionDecider> LazySingletonInstance = new Lazy<ConnectionDecider>(() => CreateSingleton());
        public static ConnectionDecider Instance => LazySingletonInstance.Value;
        private IConnectionDecider _iConnectionDecider;
        private ConnectionSelection _connectionSelection;
        #endregion

        #region Contructor
        /// <summary>
        /// The private instance-constructor
        /// </summary>
        private ConnectionDecider() {}
        #endregion

        #region Properties
        /// <summary>
        /// Create the singleton instance.
        /// </summary>
        private static ConnectionDecider CreateSingleton() {
            return new ConnectionDecider();
        }
        #endregion

        #region Methods
              
        public bool IsOnline() {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet) {
                return true;
            }
            return false;
        }

        public async Task<bool> DoProcessing(int availableOptions, IConnectionDecider iConnectionDecider) {
            _iConnectionDecider = iConnectionDecider;
            if (IsOnline()) {
                return await DoOnlineProcessing(availableOptions);
            } else {
                return await DoOfflineProcessing();
            }
        }


        private async Task<bool> DoOnlineProcessing(int availableOptions) {
            try {
                return await _iConnectionDecider.DoOnlineProcessing();
            } catch (WebException) {
                if (availableOptions == 0) {
                    return await TryLater();
                } else {
                   var responce = await Application.Current.MainPage.DisplayActionSheet("Select an action as there is no connection", "Try later", null, "Work Offline");
                    switch (responce) {
                        case "Work Offline":
                            return await DoOfflineProcessing();
                        case "Try later":
                            return await TryLater();
                        default:
                            return await TryLater();
                    }
                }
            } catch (Exception ex) {
                if (ex.Message == "#ERROR_CODE_00004#") { // This is included to catch the exception raised by the Al Net Server for invalid userid/password.
                    // CommonUtility.DisplayErrorMessage(MessageType.Validation, Message.CAP_SERVITRAX_LOGIN, Message.MSG_COM_014);
                } else {
                    // Logger.Instance.Error("Error occured while calling server method!", ex, false);
                }
            }
            return false;
        }

        private async Task<bool> DoOfflineProcessing() {
            try {
                return await _iConnectionDecider.DoOfflineProcessing();
            } catch (Exception) {
               // Logger.Instance.Error("Error occured while calling Offline Function (DoOfflineProcessing())!", ex, false);
                return false;
            }
        }

        private async Task<bool> TryLater() {
            try {
                return await _iConnectionDecider.TryLater();
            } catch (Exception) {
                // Logger.Instance.Error("Error occured while calling Offline Function (TryLater())!", ex, false);
                return false;
            }
        }
        #endregion
    }
}
