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
13/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using Mobile.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
#endregion

namespace Mobile.FormModel {
    public abstract class BaseFormModel : INotifyPropertyChanged {
        public bool IsNotValid { get; set; } = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string CreatedUserId { get; set; } = GlobalSetting.Instance.User.Name;
        public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
        public string UpdatedUserId { get; set; } = GlobalSetting.Instance.User.Name;

        public Field NextAppointmentDate { get; set; } = new Field();
        public DateTime SelectedNextAppointmentDate { get; set; } = Utils.GetCurrentDateTime();
        public Field NextAppointmentTime { get; set; } = new Field();
        public TimeSpan SelectedNextAppointmentTime { get; set; } = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        public DateTime NextAppointmentDateTime {
            get {
                return new DateTime(SelectedNextAppointmentDate.Year, SelectedNextAppointmentDate.Month, SelectedNextAppointmentDate.Day, SelectedNextAppointmentTime.Hours, SelectedNextAppointmentTime.Minutes, SelectedNextAppointmentTime.Seconds);
            }
        }
    }

}
