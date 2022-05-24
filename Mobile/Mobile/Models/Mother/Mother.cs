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
using SQLite;
using System;
#endregion	  

namespace Mobile.Models.Mother {
    [Table("MOTHER")]
    public class Mother : AuditBase {


        private int _SortOrder = 0;
        private string _image;

        [Column(MotherDataColumn.MOTHER_ID)]
        public int MotherId { get; set; } = 0;
        [Column(MotherDataColumn.USER_NAME)]
        public string UserName { get; set; } = string.Empty;
        [Column(MotherDataColumn.PASSWORD)]
        public string Password { get; set; } = string.Empty;
        [Column(MotherDataColumn.FIRST_NAME)]
        public string FirstName { get; set; } = string.Empty;
        [Column(MotherDataColumn.LAST_NAME)]
        public string LastName { get; set; } = string.Empty;
        [Ignore]
        public string FullName { get { return $"{FirstName}.{LastName}"; } }
        [Column(MotherDataColumn.NIC)]
        public string Nic { get; set; } = string.Empty;
        [Column(MotherDataColumn.DOB)] 
        public DateTime Dob { get; set; } = DateTime.Now;
        [Column(MotherDataColumn.PHONE)] 
        public string Phone { get; set; } = string.Empty;
        [Column(MotherDataColumn.ADDRESS)] 
        public string Address { get; set; } = string.Empty;
        [Column(MotherDataColumn.OCCUPATION)] 
        public string Occupation { get; set; } = string.Empty;
        [Column(MotherDataColumn.EMAIL)] 
        public string Email { get; set; } = string.Empty;
        [Column(MotherDataColumn.MIDWIFE_ID)]
        public int MidwifeId { get; set; } = 0;
        [Column(MotherDataColumn.LATITUDE)]
        public double Latitude { get; set; } = 0.0;

        [Column(MotherDataColumn.LONGITUDE)]
        public double Longitude { get; set; } = 0.0;

        [Column(MotherDataColumn.SEQUENCE)]
        public int Sequence { get; set; } = 0;

        [Column(MotherDataColumn.NEXT_APPOINTMENT_DATE)]
        public DateTime NextAppointmentDate { get; set; } = DateTime.Now;

        [Column(MotherDataColumn.IS_DELIVERY_ARRIVAL_NOTIFICATION_SENT)]
        public bool IsDeliveryArrivalNotificationSent { get; set; } = false;

        [Column(MotherDataColumn.IS_SEND_DEL_NOTIFICATION_TYPE1)]
        public string IsSendDelNotificationType1 { get; set; } = string.Empty;

        [Column(MotherDataColumn.IS_SEND_DEL_NOTIFICATION_TYPE2)]
        public string IsSendDelNotificationType2 { get; set; } = string.Empty;

        [Column(MotherDataColumn.IS_SEND_DEL_NOTIFICATION_TYPE3)]
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

    public static class MotherDataColumn {
        public const string MOTHER_ID = "MOTHER_ID";
        public const string USER_NAME = "USER_NAME";
        public const string PASSWORD = "PASSWORD";
        public const string FIRST_NAME = "FIRST_NAME";
        public const string LAST_NAME = "LAST_NAME";
        public const string NIC = "NIC";
        public const string DOB = "DOB";
        public const string PHONE = "PHONE";
        public const string ADDRESS = "ADDRESS";
        public const string OCCUPATION = "OCCUPATION";
        public const string EMAIL = "EMAIL";
        public const string MIDWIFE_ID = "MIDWIFE_ID";
        public const string LATITUDE = "LATITUDE";
        public const string LONGITUDE = "LONGITUDE";
        public const string SEQUENCE = "SEQUENCE";
        public const string NEXT_APPOINTMENT_DATE = "NEXT_APPOINTMENT_DATE";
        public const string IS_DELIVERY_ARRIVAL_NOTIFICATION_SENT = "IS_DELIVERY_ARRIVAL_NOTIFICATION_SENT";
        public const string IS_SEND_DEL_NOTIFICATION_TYPE1 = "IS_SEND_DEL_NOTIFICATION_TYPE1";
        public const string IS_SEND_DEL_NOTIFICATION_TYPE2 = "IS_SEND_DEL_NOTIFICATION_TYPE2";
        public const string IS_SEND_DEL_NOTIFICATION_TYPE3 = "IS_SEND_DEL_NOTIFICATION_TYPE3";
    }

}
