#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022       	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using SQLite;
using System;
#endregion

namespace Mobile.Models.Common {
    [Table("ERROR_LOG")]
    public class ErrorLog : Base {

        [Column(ErrorLogDataColumn.SOURCE)]
        public string Source { get; set; } = string.Empty;

        [Column(ErrorLogDataColumn.MESSAGE)]
        public string Message { get; set; } = string.Empty;

        [Column(ErrorLogDataColumn.ERROR)]
        public string Error { get; set; } = string.Empty;

        [Column(ErrorLogDataColumn.DATE_TIME)]
        public DateTime DateTime { get; set; } = DateTime.Now;

        //public ErrorLog(string source, string message, string error) {
        //    this.Source = source;
        //    this.Message = message;
        //    this.Error = error;
        //    this.DateTime = DateTime.Now;
        //}

    }

    public static class ErrorLogDataColumn {
        public const string SOURCE = "SOURCE ";
        public const string MESSAGE = "MESSAGE ";
        public const string ERROR = "ERROR ";
        public const string DATE_TIME = "DATE_TIME ";
    }
}
