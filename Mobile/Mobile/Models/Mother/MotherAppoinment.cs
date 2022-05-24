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
using Mobile.Enum;
using Mobile.Helpers;
using SQLite;
using System;
#endregion	  

namespace Mobile.Models.Mother {

    [Table("MOTHER_APPOINTMENT")]
    public class MotherAppoinment : AppointmentBase {
        [Column(MotherAppoinmentDataColumn.MOTHER_ID)]
        public int MotherId { get; set; } = 0;
        [Column(MotherAppoinmentDataColumn.HEALTH_CONDITION)]
        public string HealthCondition { get; set; } = string.Empty;
        [Column(MotherAppoinmentDataColumn.WEIGHT)]
        public decimal Weight { get; set; } = 0;
        [Column(MotherAppoinmentDataColumn.BLOOOD_PRESSURE)]
        public decimal BloodPressure { get; set; } = 0;
        [Column(MotherAppoinmentDataColumn.GLUCOSE_LEVEL)]
        public decimal GlucouseLevel { get; set; } = 0;
        [Column(MotherAppoinmentDataColumn.VACCINE)]
        public string Vaccine { get; set; } = string.Empty;
    }

    public static class MotherAppoinmentDataColumn {
        public const string MOTHER_ID = "MOTHER_ID";
        public const string HEALTH_CONDITION = "HEALTH_CONDITION";
        public const string WEIGHT = "WEIGHT";
        public const string BLOOOD_PRESSURE = "BLOOOD_PRESSURE";
        public const string GLUCOSE_LEVEL = "GLUCOSE_LEVEL";
        public const string VACCINE = "VACCINE";
    }
}
