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
20/02/2022        1.0         Anuruddha.Rajapaksha   		  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Mobile.Helpers {
    public class Message {

        #region Caption
        public const string CAP_LOGIN = "CAP_LOGIN";                                            // Mom & Baby
        public const string CAP_LOADING = "CAP_LOADING";                                        // Loading...
        public const string CAP_SAVING = "CAP_SAVING";                                          // Saving...
        public const string CAP_SETTINGS_ABOUT = "CAP_SETTINGS_ABOUT";                          // About
        public const string CAP_SETTINGS = "CAP_SETTINGS";                                      // Settings 
        public const string CAP_DOWNLOAD_MASTERDATA = "CAP_DOWNLOAD_MASTERDATA";                // Download Master Data
        public const string CAP_LOG_OUT = "CAP_LOG_OUT";                                        // Logging Out
        public const string CAP_BABY = "CAP_BABY";                                              // Babies
        public const string CAP_MOTHER = "CAP_MOTHER";                                          // Mothers
        public const string CAP_CREATE_BABY = "CAP_CREATE_BABY";                                // Create Baby
        public const string CAP_CREATE_MOTHER = "CAP_CREATE_MOTHER";                            // Create Mother
        public const string CAP_CREATE_APPOINMENT = "CAP_CREATE_APPOINMENT";                    // Create Appoinment
        public const string CAP_MODIFY_BABY = "CAP_MODIFY_BABY";                                // Modify Baby
        public const string CAP_MODIFY_MOTHER = "CAP_MODIFY_MOTHER";                            // Modify Mother
        public const string CAP_BABY_APPOINTMENTS = "CAP_BABY_APPOINTMENTS";                    // Baby Appointments
        public const string CAP_MOTHER_APPOINTMENTS = "CAP_MOTHER_APPOINTMENTS";                // Mother Appointments
        public const string CAP_CONFIRM = "CAP_CONFIRM";                                        // Confirm 
        public const string CAP_TRAVEL_TIME = "CAP_TRAVEL_TIME";                                // Travel Time
        public const string CAP_SIGNATURE = "CAP_SIGNATURE";                                    // Signature
        public const string CAP_GENDER = "CAP_GENDER";                                          // Gender
        public const string CAP_MOM_HEALTH = "CAP_MOM_HEALTH";                                  // Capture Mother Health 
        public const string CAP_BABY_HEALTH = "CAP_BABY_HEALTH";                                // Capture Baby Health 
        public const string CAP_SAVE = "CAP_SAVE";                                              // Save
        #endregion

        #region Button
        public const string BTN_LOGI_001 = "BTN_LOGI_001"; // Login
        public const string BTN_LOGI_002 = "BTN_LOGI_002"; // Exit
        public const string BTN_LOGI_003 = "BTN_LOGI_003"; // Log Out
        public const string BTN_HOME_001 = "BTN_HOME_001";  // Pregant Mother
        public const string BTN_HOME_002 = "BTN_HOME_002";  // Child

        public const string BTN_MAIN_001 = "BTN_MAIN_001"; // Mom
        public const string BTN_MAIN_002 = "BTN_MAIN_002"; // Baby

        public const string BTN_MAIN_003 = "BTN_MAIN_003";// Mom List
        public const string BTN_MAIN_004 = "BTN_MAIN_004";// Create Mom
        public const string BTN_MAIN_005 = "BTN_MAIN_005";// Modify Mom
        public const string BTN_MAIN_006 = "BTN_MAIN_006";// Mom Appoinment List
        public const string BTN_MAIN_007 = "BTN_MAIN_007";// Create Mom Appoinment

        public const string BTN_MAIN_008 = "BTN_MAIN_008";// Baby List
        public const string BTN_MAIN_009 = "BTN_MAIN_009";// Create Baby
        public const string BTN_MAIN_010 = "BTN_MAIN_010";// Modify Baby
        public const string BTN_MAIN_011 = "BTN_MAIN_011";// Baby Appoinment List
        public const string BTN_MAIN_012 = "BTN_MAIN_012";// Create Baby Appoinment

        public const string BTN_DELV_022 = "BTN_DELV_022"; // 15 Minutes
        public const string BTN_DELV_023 = "BTN_DELV_023"; // 30 Minutes
        public const string BTN_DELV_024 = "BTN_DELV_024"; // 45 Minutes
        public const string BTN_DELV_025 = "BTN_DELV_025"; // 1 Hour
        public const string BTN_DELV_026 = "BTN_DELV_026"; // Other
        #endregion

        #region Message
        public const string MSG_COM_001 = "MSG_COM_001"; // This functionality is available only in online mode.
        public const string MSG_COM_027 = "MSG_COM_027"; // Synchronizing  Data...
        public const string MSG_SET_030 = "MSG_SET_030"; // Language 
        public const string MSG_SET_028 = "MSG_SET_028"; // Device Number
        public const string MSG_COM_021 = "MSG_COM_021"; // Are you sure you want to log out? !&#x0a; If not, press CANCEL to return to the Main Menu.
        public const string MSG_COM_011 = "MSG_COM_011"; // UserId and Password not specified!
        public const string MSG_COM_012 = "MSG_COM_012"; // UserId not specified!
        public const string MSG_COM_013 = "MSG_COM_013"; // Password not specified!
        public const string MSG_COM_014 = "MSG_COM_014"; // Wrong username and / or password!
        public const string MSG_COM_019 = "MSG_COM_019"; // User group doesn't have any functions assigned!
        public const string MSG_COM_002 = "MSG_COM_002"; // Do you want to create a new mother?
        public const string MSG_COM_003 = "MSG_COM_003"; // Do you want to create a new baby?
        public const string MSG_COM_004 = "MSG_COM_004"; // Do you want to create an appointment?
        public const string MSG_DEL_162 = "MSG_DEL_162"; // Input estimated time of arrival ?
        public const string MSG_DEL_156 = "MSG_DEL_156"; // Inform customer of travel time? ({0} : {1})
        public const string MSG_DEL_158 = "MSG_DEL_158"; // Sending start notification...
        public const string MSG_DEL_159 = "MSG_DEL_159"; // Sending arriving notification...
        public const string MSG_DEL_160 = "MSG_DEL_160"; // Sending completed notification...
        public const string SVR_DEL_018 = "SVR_DEL_018"; // Unable to send the delivery notification!
        public const string MSG_DEL_041 = "MSG_DEL_041"; // Signature and Signer name are mandatory.
        public const string MSG_INI_069 = "MSG_INI_069"; // Former date is not allowed
        public const string MSG_INI_070 = "MSG_INI_070"; // Future date is not allowed
        public const string MSG_INI_071 = "MSG_INI_071"; // Required field
        public const string MSG_INI_001 = "MSG_INI_001"; // Uploading Baby Data
        public const string MSG_INI_002 = "MSG_INI_002"; // Uploading Mother Data
        public const string MSG_INI_003 = "MSG_INI_003"; // Uploading Baby Health Data
        public const string MSG_INI_004 = "MSG_INI_004"; // Uploading Mother Health Data
        public const string MSG_INI_005 = "MSG_INI_005"; // Upload Failed
        public const string MSG_SAVE = "MSG_SAVE"; // Item Saved Successfully !
        public const string MSG_SAVE_LOCALLY = "MSG_SAVE_LOCALLY"; // Item Saved Locally Successfully !



        #region 'Settings' Messages
        public const string MSG_SET_029 = "MSG_SET_029"; //  Used in Application 
        public const string MSG_SET_031 = "MSG_SET_031"; //  You may change the language of the application 
        public const string MSG_SET_038 = "MSG_SET_038"; //  About
        public const string MSG_SET_039 = "MSG_SET_039"; //  Application version, Device info
        public const string MSG_SET_032 = "MSG_SET_032"; //  Connections 
        public const string MSG_SET_033 = "MSG_SET_033"; //  Printer
        public const string MSG_SET_045 = "MSG_SET_045"; //  Local Database 
        public const string MSG_SET_046 = "MSG_SET_046"; //  Share Local Database
        #endregion

        #endregion

        #region 'Error' Messages
        public const string ERR_UN_EXPECTED = "ERR_UN_EXPECTED";              // Unexpected error occoured!
        public const string ERR_UNABLE_TO_CONNECT = "ERR_UNABLE_TO_CONNECT";  // Unable to connect to server! Check the connection.
        #endregion

        #region Label
        public const string LBL_PREP_008 = "LBL_PREP_008"; // Mother Name:
        public const string LBL_PREP_999 = "LBL_PREP_999"; // NIC:
        public const string LBL_PREP_001 = "LBL_PREP_001"; // Date:
        public const string LBL_MAP_VIEW = "LBL_MAP_VIEW";   // Map View
        public const string LBL_LIST_VIEW = "LBL_LIST_VIEW"; // List View


        public const string LBL_DATA_001 = "LBL_DATA_001";      // First Name:	
        public const string LBL_DATA_002 = "LBL_DATA_002";      // Last Name:	
        public const string LBL_DATA_003 = "LBL_DATA_003";      // NIC:	
        public const string LBL_DATA_004 = "LBL_DATA_004";      // DOB:	
        public const string LBL_DATA_005 = "LBL_DATA_005";      // Phone:	
        public const string LBL_DATA_006 = "LBL_DATA_006";      // Address:	
        public const string LBL_DATA_007 = "LBL_DATA_007";      // Occupation:	
        public const string LBL_DATA_008 = "LBL_DATA_008";      // Email:	
        public const string LBL_DATA_009 = "LBL_DATA_009";      // Next Appointment DateTime:	
        public const string LBL_DATA_010 = "LBL_DATA_010";      // Name:	
        public const string LBL_DATA_011 = "LBL_DATA_011";      // Health Condition:	
        public const string LBL_DATA_012 = "LBL_DATA_012";      // Weight:	
        public const string LBL_DATA_013 = "LBL_DATA_013";      // Blood Pressure:	
        public const string LBL_DATA_014 = "LBL_DATA_014";      // Glucouse Level:	
        public const string LBL_DATA_015 = "LBL_DATA_015";      // Vaccine:	
        public const string LBL_DATA_016 = "LBL_DATA_016";      // Instruction:	
        public const string LBL_DATA_017 = "LBL_DATA_017";      // Gender:	
        public const string LBL_DATA_018 = "LBL_DATA_018";      // Height:	
        public const string LBL_DATA_019 = "LBL_DATA_019";      // Mother:	


        public const string LBL_DELV_017 = "LBL_DELV_017"; // Signed By:
        public const string LBL_DELV_052 = "LBL_DELV_052"; // Please Sign above the line
        public const string LBL_DELV_035 = "LBL_DELV_035"; // Please rate your satisfaction level:
        public const string LBL_DELV_036 = "LBL_DELV_036"; // Thank you for rating!

        #endregion


    }
}
