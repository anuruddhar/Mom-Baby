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
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using SQLite;
#endregion	  

namespace Mobile.Models.Common {
    [Table("USER_SETTING")]
    public class UserSetting : Base {
        [Column(UserSettingColumn.USER_ID)]
        public string UserId { get; set; } = string.Empty;

        [Column(UserSettingColumn.KEY)]
        public string Key { get; set; } = string.Empty;

        [Column(UserSettingColumn.VALUES)]
        public string Values { get; set; } = string.Empty;
    }

    public static class UserSettingColumn {
        public const string USER_ID = "USER_ID";
        public const string KEY = "KEY";
        public const string VALUES = "VALUES";
    }
}
