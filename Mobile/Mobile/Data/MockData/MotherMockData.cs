#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Test Data
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
10/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Mother;
using System;
using System.Collections.Generic;
#endregion	  

namespace Mobile.Data {
    public class MotherMockData {

        #region Private Variables
        private static readonly Lazy<MotherMockData> LazySingleton = new Lazy<MotherMockData>(CreateSingleton);
        #endregion

        #region Properties
        public static MotherMockData Instance => LazySingleton.Value;

        public List<Mother> LocalData { get; set; } = new List<Mother>();
        #endregion

        #region Constructor
        private MotherMockData() {
            LoadData();
        }
        private static MotherMockData CreateSingleton() {
            return new MotherMockData();
        }
        #endregion

        #region Methods

        private void LoadData() {
            LocalData.Add(new Mother() { MotherId = 1, UserName = "883143261v", Password = "UAT@123", FirstName = "Isuri", LastName = "Senanayake", Nic = "883143261v", Dob = Convert.ToDateTime("1988-02-28"), Phone = "715078963", Address = "45/3, Welegoda Road, Matara", Occupation = "Medical Officer", Email = "anuruddha.rajapaksa@gmail.com", MidwifeId = 1, Latitude = 5.951911166,  Longitude = 80.53499817, Sequence = 1, NextAppointmentDate = Convert.ToDateTime("2022-05-01 9:00 AM") });
            LocalData.Add(new Mother() { MotherId = 2, UserName = "933143261v", Password = "UAT@123", FirstName = "Malki", LastName = "Tharika", Nic = "933143261v", Dob = Convert.ToDateTime("1993-02-28"), Phone = "715078963", Address = "45/3, Welegoda Road, Matara", Occupation = "Teacher", Email = "anuruddha.rajapaksa@gmail.com", MidwifeId = 1, Latitude = 5.952796964,  Longitude = 80.54055598, Sequence = 2, NextAppointmentDate = Convert.ToDateTime("2022-05-01 10:00 AM") });
            LocalData.Add(new Mother() { MotherId = 3, UserName = "953143261v", Password = "UAT@123", FirstName = "Paba", LastName = "Gunarathna", Nic = "953143261v", Dob = Convert.ToDateTime("1995-02-28"), Phone = "715078963", Address = "45/3, Welegoda Road, Matara", Occupation = "Nurse", Email = "anuruddha.rajapaksa@gmail.com", MidwifeId = 1, Latitude = 5.952806562,  Longitude = 80.53452638, Sequence = 3, NextAppointmentDate = Convert.ToDateTime("2022-05-01 11:00 AM") });
            LocalData.Add(new Mother() { MotherId = 4, UserName = "943143261v", Password = "UAT@123", FirstName = "Renuka", LastName = "Kumari", Nic = "943143261v", Dob = Convert.ToDateTime("1994-02-28"), Phone = "715078963", Address = "45/3, Welegoda Road, Matara", Occupation = "Bank Offcier", Email = "anuruddha.rajapaksa@gmail.com", MidwifeId = 1, Latitude = 5.952806562, Longitude = 80.53452638, Sequence = 3, NextAppointmentDate = Convert.ToDateTime("2022-05-02") });
            LocalData.Add(new Mother() { MotherId = 5, UserName = "923143261v", Password = "UAT@123", FirstName = "Kumudu", LastName = "Tharanga", Nic = "913143261v", Dob = Convert.ToDateTime("1991-02-28"), Phone = "715078963", Address = "45/3, Welegoda Road, Matara", Occupation = "Bank Offcier", Email = "anuruddha.rajapaksa@gmail.com", MidwifeId = 1, Latitude = 5.952806562, Longitude = 80.53452638, Sequence = 3, NextAppointmentDate = Convert.ToDateTime("2022-05-06") });
        }
        #endregion

    }
}
