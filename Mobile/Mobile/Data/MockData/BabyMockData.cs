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
using Mobile.Models.Baby;
using System;
using System.Collections.Generic;
#endregion	  

namespace Mobile.Data {
    public class BabyMockData {
        #region Private Variables
        private static readonly Lazy<BabyMockData> LazySingleton = new Lazy<BabyMockData>(CreateSingleton);
        #endregion

        #region Properties
        public static BabyMockData Instance => LazySingleton.Value;

        public List<Baby> LocalData { get; set; } = new List<Baby>();
        #endregion

        #region Constructor
        private BabyMockData() {
            LoadData();
        }
        private static BabyMockData CreateSingleton() {
            return new BabyMockData();
        }
        #endregion

        #region Methods

        private void LoadData() {
            LocalData.Add(new Baby() { BabyId = 1, MotherId = 1, FirstName = "Nathindu", LastName = "Rajapaksha", Dob = Convert.ToDateTime("2019-04-17"), Latitude = 5.951911166, Longitude = 80.53499817, Sequence = 1, MotherName = "Isuri.Senanayake", NextAppointmentDate = Convert.ToDateTime("2022-05-01 9:00 AM"), Sex = "Male" });
            LocalData.Add(new Baby() { BabyId = 2, MotherId = 1, FirstName = "Thinuli", LastName = "Rajapaksha", Dob = Convert.ToDateTime("2021-05-25"), Latitude = 5.951911166, Longitude = 80.53499817, Sequence = 1, MotherName = "Isuri.Senanayake", NextAppointmentDate = Convert.ToDateTime("2022-05-01 9:00 AM"), Sex = "Female" });
            LocalData.Add(new Baby() { BabyId = 3, MotherId = 2, FirstName = "Dhanushka", LastName = "Rajapaksha", Dob = Convert.ToDateTime("2021-10-06"), Latitude = 5.952796964, Longitude = 80.54055598, Sequence = 2, MotherName = "Malki.Tharika", NextAppointmentDate = Convert.ToDateTime("2022-05-01 10:00 AM"), Sex = "Male" });
            LocalData.Add(new Baby() { BabyId = 4, MotherId = 3, FirstName = "Sanadi", LastName = "Wickramasinghe", Dob = Convert.ToDateTime("2020-10-05"), Latitude = 5.952796964, Longitude = 80.54055598, Sequence = 3, MotherName = "Paba.Gunarathna", NextAppointmentDate = Convert.ToDateTime("2022-05-02"), Sex = "Female" });
            LocalData.Add(new Baby() { BabyId = 5, MotherId = 3, FirstName = "Senudi", LastName = "Wickramasinghe", Dob = Convert.ToDateTime("2021-11-05"), Latitude = 5.952796964, Longitude = 80.54055598, Sequence = 3, MotherName = "Paba.Gunarathna", NextAppointmentDate = Convert.ToDateTime("2022-05-02"), Sex = "Female" });
        }
        #endregion
    }
}
