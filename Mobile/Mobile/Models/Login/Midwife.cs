#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Core
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using SQLite;
using System;
using System.Collections.Generic;
#endregion

namespace Mobile.Models.Login {

    [Table("MIDWIFE")]
    public class Midwife : Base {

        [Column(MidwifeDataColumn.MIDWIFE_ID)]
        public int MidwifeId { get; set; } = 0;

        [Column(MidwifeDataColumn.USER_NAME)]
        public string UserName { get; set; } = string.Empty;

        [Column(MidwifeDataColumn.PWD)]
        public string Password { get; set; } = string.Empty;

        public string Name { get { return $"{FirstName}.{LastName}"; } }

        [Column(MidwifeDataColumn.FIRST_NAME)]
        public string FirstName { get; set; } = string.Empty;

        [Column(MidwifeDataColumn.LAST_NAME)]
        public string LastName { get; set; } = string.Empty;

        public string Nic = string.Empty;

        [Column(MidwifeDataColumn.EMAIL)]
        public string Email { get; set; } = string.Empty;

        [Column(MidwifeDataColumn.PHONE)]
        public string Phone { get; set; } = string.Empty;

        [Column(MidwifeDataColumn.LAST_LOGIN_TIME)]
        public DateTime LastLoginTime { get; set; } = DateTime.Now;

        [Column(MidwifeDataColumn.LANGUAGE)]
        public string Language { get; set; } = "en-US";

        [Ignore]
        public string Token { get; set; } = string.Empty;

        [Ignore]
        public List<UserFunction> FunctionList { get; set; } = new List<UserFunction>();

        [Column(MidwifeDataColumn.LATITUDE)]
        public double Latitude { get; set; } = 0.0;

        [Column(MidwifeDataColumn.LONGITUDE)]
        public double Longitude { get; set; } = 0.0;


    }

    public static class MidwifeDataColumn {
        public const string MIDWIFE_ID = "MIDWIFE_ID";
        public const string USER_NAME = "USER_NAME";
        public const string PWD = "PWD";
        public const string FIRST_NAME = "FIRST_NAME";
        public const string LAST_NAME = "LAST_NAME";
        public const string EMAIL = "EMAIL";
        public const string PHONE = "PHONE";
        public const string LOCATION_ID = "LOCATION_ID";
        public const string LANGUAGE = "LANGUAGE";
        public const string LAST_LOGIN_TIME = "LAST_LOGIN_TIME";
        public const string LATITUDE = "LATITUDE";
        public const string LONGITUDE = "LONGITUDE";
    }
}
