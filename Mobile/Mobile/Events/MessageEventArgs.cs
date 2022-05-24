#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Truck Tracking
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
#endregion	  


namespace Mobile.Events {
    public class MessageEventArgs : IMessageEventArgs {
        public MessageEventArgs(string user, string message) {
            User = user;
            Message = message;
        }

        public string User { get; }

        public string Message { get; }
    }
}
