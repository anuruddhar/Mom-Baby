#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Logic
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version        Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022         1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Common;
using Prism.Services;
using System;
using System.Threading.Tasks;
#endregion

namespace Mobile.Logic {
    public delegate void UpdateEventHandler(string messageCode);

    public interface ISyncLogic {
        #region Properties
        event UpdateEventHandler UpdateUI;
        string AnimationFileName { get; set; }
        string ClientMessage { get; set; }
        IPageDialogService IPageDialogService { get; set; }
        #endregion

        #region Methods
        Task<AppResult> Synchronize();
        #endregion
    }
}
