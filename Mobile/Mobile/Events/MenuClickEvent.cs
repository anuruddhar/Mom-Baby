#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022         1.0         Anuruddha.Rajapaksha   	  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Common;
using Prism.Events;
#endregion	


namespace Mobile.Events {
    public class MenuClickEvent : PubSubEvent<AppMenuItem> {
    }
}
