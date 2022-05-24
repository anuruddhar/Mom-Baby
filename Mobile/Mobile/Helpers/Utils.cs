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
using Mobile.Enum;
using Mobile.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
#endregion	  


namespace Mobile.Helpers {
    public static class Utils {

        #region Settings
        public static List<LanguageModel> GetLanguage() {
  
            List<LanguageModel> languageModels = new List<LanguageModel>();
            languageModels.Add(new LanguageModel() { ID = "en", Image = AppConstant.AppImges.IMG_ENGLISH, Description = "English" });
            languageModels.Add(new LanguageModel() { ID = "si", Image = AppConstant.AppImges.IMG_SINHALA, Description = "සිංහල" });
            languageModels.Add(new LanguageModel() { ID = "ta", Image = AppConstant.AppImges.IMG_TAMIL, Description = "தமிழ்" });
           
            return languageModels;
        }
        #endregion

        #region DateTime
        public static DateTime GetCurrentDateTime() {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
        #endregion

    }
}
