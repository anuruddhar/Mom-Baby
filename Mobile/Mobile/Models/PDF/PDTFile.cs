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
08/03/2022         1.0      Anuruddha.Rajapaksha   	  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using SQLite;
#endregion	  

namespace Mobile.Models.PDF {
    [Table("PDF_FILE")]
    public class PDTFile : Base {

        [Column(PDTFileDataColumn.MOTHER_ID)]
        public string MotherId { get; set; } = string.Empty;

        [Column(PDTFileDataColumn.IS_SEND_TO_SERVER)]
        public bool IsSentToServer { get; set; } = false;
    }

    public static class PDTFileDataColumn {
        public const string MOTHER_ID = "MOTHER_ID";
        public const string IS_SEND_TO_SERVER = "IS_SEND_TO_SERVER";
    }
}
