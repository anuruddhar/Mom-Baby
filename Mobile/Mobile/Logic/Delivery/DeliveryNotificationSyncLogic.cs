#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Logic
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version        Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
06/03/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Helpers;
using Mobile.Logic;
using Mobile.Models.Common;
using Prism.Services;
#endregion


namespace GTS.Mobile.Logic.Delivery {
    public class DeliveryNotificationSyncLogic : ISyncLogic {

        #region Private Variables
        private static readonly Lazy<DeliveryNotificationSyncLogic> LazySingleton =
                 new Lazy<DeliveryNotificationSyncLogic>(CreateSingleton);
        private int _notificationType;
        private int _minutes;
        private AppResult _AppResult = new AppResult();

        public event UpdateEventHandler UpdateUI;
        #endregion

        #region Properties
        public static DeliveryNotificationSyncLogic Instance => LazySingleton.Value;

        public string AnimationFileName { get; set; } = AppConstant.AnimationFile.UPLOADING;
        public string ClientMessage { get; set; }
        public IPageDialogService IPageDialogService { get; set; }


        public int NotificationType {
            get {
                return _notificationType;
            }
            set {
                _notificationType = value;
                switch (_notificationType) {
                    case 1:
                        ClientMessage = Message.MSG_DEL_158;
                        break;
                    case 2:
                        ClientMessage = Message.MSG_DEL_159;
                        break;
                    case 3:
                        ClientMessage = Message.MSG_DEL_160;
                        break;
                    default:
                        ClientMessage = Message.MSG_DEL_158;
                        break;
                }
            }
        }


        public int Minutes {
            set {
                _minutes = value;
            }
        }

        #endregion

        #region Constructor
        private DeliveryNotificationSyncLogic() {
        }

        private static DeliveryNotificationSyncLogic CreateSingleton() {
            return new DeliveryNotificationSyncLogic();
        }
        #endregion


        #region Methods
        public async Task<AppResult> Synchronize() {
            _AppResult = new AppResult();
            _AppResult.Success = true;
            try {
                switch (_notificationType) {
                    case 1:
                        _AppResult = await SendTripStartNotification();
                        break;
                    case 2:
                        _AppResult = await SendDeliveryArraivingtNotification();
                        break;
                    case 3:
                        _AppResult = await SendDeliveryCompletedNotification();
                        break;
                    default:
                        break;
                }
            } catch (Exception) {
                _AppResult.Success = false;
                if (string.IsNullOrEmpty(_AppResult.ResultID)) {
                    _AppResult.ResultID = Message.SVR_DEL_018;
                }
            }
            return _AppResult;
        }

        public async Task<AppResult> SendTripStartNotification() {
            return await Task.Run(() => {
                Task.Delay(2000);
                return new AppResult() { Success = true };
            });
        }

        public async Task<AppResult> SendDeliveryArraivingtNotification() {
            return await Task.Run(() => {
                Task.Delay(2000);
                return new AppResult() { Success = true };
            });
        }

        public async Task<AppResult> SendDeliveryCompletedNotification() {
            return await Task.Run(() => {
                Task.Delay(2000);
                return new AppResult() { Success = true };
            });
        }



        #endregion


    }
}
