
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
17/03/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
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

namespace Mobile.Logic {

    public class MotherHelathSyncLogic : ISyncLogic {

        #region Private Variables
        private static readonly Lazy<MotherHelathSyncLogic> LazySingleton =
                 new Lazy<MotherHelathSyncLogic>(CreateSingleton);
        private int _notificationType;
        private int _minutes;
        private AppResult _AppResult = new AppResult();

        public event UpdateEventHandler UpdateUI;
        #endregion

        #region Properties
        public static MotherHelathSyncLogic Instance => LazySingleton.Value;

        public string AnimationFileName { get; set; } = AppConstant.AnimationFile.UPLOADING;
        public string ClientMessage { get; set; } = Message.MSG_INI_004;
        public IPageDialogService IPageDialogService { get; set; }


        #endregion

        #region Constructor
        private MotherHelathSyncLogic() {
        }

        private static MotherHelathSyncLogic CreateSingleton() {
            return new MotherHelathSyncLogic();
        }
        #endregion


        #region Methods
        public async Task<AppResult> Synchronize() {
            _AppResult = new AppResult(false);
            try {
                if (ConnectionDecider.Instance.IsOnline()) {
                    return await Task.Run(() => {
                        Task.Delay(3000);
                        return new AppResult() { Success = true };
                    });
                } else {
                    _AppResult.ResultID = Message.MSG_INI_005;
                }
            } catch (Exception) {
                _AppResult.Success = false;
                if (string.IsNullOrEmpty(_AppResult.ResultID)) {
                    _AppResult.ResultID = Message.MSG_INI_005;
                }
            }
            return _AppResult;
        }
        #endregion

    }
}

