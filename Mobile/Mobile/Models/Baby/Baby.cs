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
06/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using SQLite;
using System;
#endregion	  

namespace Mobile.Models.Baby {
    [Table("BABY")]
    public class Baby : AuditBase {

        private int _SortOrder = 0;
        private string _image;

        [Column(BabyDataColumn.BABY_ID)]
        public int BabyId { get; set; } = 0;
        [Column(BabyDataColumn.MOTHER_ID)]
        public int MotherId { get; set; } = 0;
        [Column(BabyDataColumn.FIRST_NAME)]
        public string FirstName { get; set; } = string.Empty;
        [Column(BabyDataColumn.LAST_NAME)]
        public string LastName { get; set; } = string.Empty;
        [Ignore]
        public string FullName { get { return $"{FirstName}.{LastName}"; } }

        [Column(BabyDataColumn.DOB)]
        public DateTime Dob { get; set; } = DateTime.Now;
        [Column(BabyDataColumn.SEX)]
        public string Sex { get; set; } = string.Empty;

        [Column(BabyDataColumn.LATITUDE)]
        public double Latitude { get; set; } = 0.0;

        [Column(BabyDataColumn.LONGITUDE)]
        public double Longitude { get; set; } = 0.0;

        [Column(BabyDataColumn.SEQUENCE)]
        public int Sequence { get; set; } = 0;
        [Column(BabyDataColumn.ADDRESS)]
        public string Address { get; set; } = string.Empty;

        [Column(BabyDataColumn.MOTHER_NAME)]
        public string MotherName { get; set; } = string.Empty;

        [Column(BabyDataColumn.NEXT_APPOINTMENT_DATE)]
        public DateTime NextAppointmentDate { get; set; } = DateTime.Now;

        [Column(BabyDataColumn.IS_DELIVERY_ARRIVAL_NOTIFICATION_SENT)]
        public bool IsDeliveryArrivalNotificationSent { get; set; } = false;

        [Column(BabyDataColumn.IS_SEND_DEL_NOTIFICATION_TYPE1)]
        public string IsSendDelNotificationType1 { get; set; } = string.Empty;

        [Column(BabyDataColumn.IS_SEND_DEL_NOTIFICATION_TYPE2)]
        public string IsSendDelNotificationType2 { get; set; } = string.Empty;

        [Column(BabyDataColumn.IS_SEND_DEL_NOTIFICATION_TYPE3)]
        public string IsSendDelNotificationType3 { get; set; } = string.Empty;


        [Ignore]
        public string Image {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        [Ignore]
        public int SortOrder {
            get { return _SortOrder; }
            set { SetProperty(ref _SortOrder, value); }
        }

    }


    public static class BabyDataColumn {
        public const string BABY_ID = "BABY_ID";
        public const string MOTHER_ID = "MOTHER_ID";
        public const string FIRST_NAME = "FIRST_NAME";
        public const string LAST_NAME = "LAST_NAME";
        public const string DOB = "DOB";
        public const string SEX = "SEX";
        public const string LATITUDE = "LATITUDE";
        public const string LONGITUDE = "LONGITUDE";
        public const string SEQUENCE = "SEQUENCE";
        public const string ADDRESS = "ADDRESS";
        public const string MOTHER_NAME = "MOTHER_NAME";
        public const string NEXT_APPOINTMENT_DATE = "NEXT_APPOINTMENT_DATE";
        public const string IS_DELIVERY_ARRIVAL_NOTIFICATION_SENT = "IS_DELIVERY_ARRIVAL_NOTIFICATION_SENT";
        public const string IS_SEND_DEL_NOTIFICATION_TYPE1 = "IS_SEND_DEL_NOTIFICATION_TYPE1";
        public const string IS_SEND_DEL_NOTIFICATION_TYPE2 = "IS_SEND_DEL_NOTIFICATION_TYPE2";
        public const string IS_SEND_DEL_NOTIFICATION_TYPE3 = "IS_SEND_DEL_NOTIFICATION_TYPE3";

    }
}
