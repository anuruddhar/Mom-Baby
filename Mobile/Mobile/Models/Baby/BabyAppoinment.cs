#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Model
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
12/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using SQLite;
#endregion	  

namespace Mobile.Models.Baby {

    [Table("BABY_APPOINTMENT")]
    public class BabyAppoinment : AppointmentBase {
        [Column(BabyAppoinmentDataColumn.BABY_ID)]
        public int BabyId { get; set; } = 0;
        [Column(BabyAppoinmentDataColumn.WEIGHT)]
        public decimal Weight { get; set; } = 0;
        [Column(BabyAppoinmentDataColumn.HEIGHT)]
        public decimal Height { get; set; } = 0;
        [Column(BabyAppoinmentDataColumn.VACCINE)]
        public string Vaccine { get; set; } = string.Empty;

    }

    public static class BabyAppoinmentDataColumn {
        public const string BABY_ID = "BABY_ID";
        public const string WEIGHT = "WEIGHT";
        public const string HEIGHT = "HEIGHT";
        public const string VACCINE = "VACCINE";
    }
}
