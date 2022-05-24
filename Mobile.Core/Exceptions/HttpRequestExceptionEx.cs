
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Net.Http;
#endregion	 

namespace Mobile.Core.Exceptions {
    public class HttpRequestExceptionEx : HttpRequestException {
        public System.Net.HttpStatusCode HttpCode { get; }
        public HttpRequestExceptionEx(System.Net.HttpStatusCode code) : this(code, null, null) {
        }

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message) : this(code, message, null) {
        }

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message, Exception inner) : base(message,
            inner) {
            HttpCode = code;
        }

    }
}
