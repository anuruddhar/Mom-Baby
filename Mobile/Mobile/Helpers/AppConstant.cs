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
19/02/2022         1.0      Anuruddha.Rajapaksha   	  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
#endregion	  

namespace Mobile.Helpers {
    public class AppConstant {

        public class AppSound {
            public const string BEEP = "Mobile.Assets.Sounds.beep.wav";
        }

        public class AppImges {
            public const string IMG_LOGIN_BACKGROUND = "img_login_background.png";
            public const string IMG_APPLOGO = "resource://Mobile.Assets.Image.img-applogo.png";
            public const string IMG_MAIN_SCREEN_BANNER = "resource://Mobile.Assets.Image.img-mainscreen-banner.png";
            public const string IMG_MOTHER = "resource://Mobile.Assets.Image.img-mother.PNG";
            public const string IMG_BABY = "resource://Mobile.Assets.Image.img-baby.PNG";
            public const string IMG_NEW_MOTHER = "resource://Mobile.Assets.Image.img-new-mother.PNG";
            public const string IMG_NEW_BABY = "resource://Mobile.Assets.Image.img-new-baby.PNG";
            public const string IMG_FAMILY = "resource://Mobile.Assets.Image.img-family.PNG";
            public const string IMG_ENGLISH = "resource://Mobile.Assets.Image.img-english.PNG";
            public const string IMG_SINHALA = "resource://Mobile.Assets.Image.img-sinhala.PNG";
            public const string IMG_TAMIL = "resource://Mobile.Assets.Image.img-tamil.PNG";
        }

        public class AppImgesSvg {

            public const string IMG_APPLOGO = "resource://Mobile.Assets.Svg.img-applogo.svg";

            // Message Box
            public const string IMG_ALERT_DENIED = "resource://Mobile.Assets.Svg.img-alert-denied.svg";
            public const string IMG_ALERT_ERROR = "resource://Mobile.Assets.Svg.img-alert-error.svg";
            public const string IMG_ALERT_MESSAGE = "resource://Mobile.Assets.Svg.img-alert-message.svg";
            public const string IMG_ALERT_QUESTION = "resource://Mobile.Assets.Svg.img-alert-question.svg";
            public const string IMG_ALERT_SUCESS = "resource://Mobile.Assets.Svg.img-alert-success.svg";
            public const string IMG_ALERT_WARNING = "resource://Mobile.Assets.Svg.img-alert-warning.svg";

            // List Item Images
            public const string IMG_LIST_NAVIGATE_ARROW = "resource://Mobile.Assets.Svg.img-list-navigate-arrow.svg";
            public const string IMG_LIST_NOTIFICATION_SYNC = "resource://Mobile.Assets.Svg.img-list-notification-sync.svg";
            public const string IMG_LIST_DELETE = "resource://Mobile.Assets.Svg.img-list-delete-icon.svg";

            // Menu Images
            public const string IMG_MNU_LOG_OUT = "resource://Mobile.Assets.Svg.img-menu-logout.svg";
            public const string IMG_MNU_PDT_NO = "resource://Mobile.Assets.Svg.img-menu-pdt-no.svg";
            public const string IMG_MNU_LANGUAGE = "resource://Mobile.Assets.Svg.img-menu-language.svg";
            public const string IMG_MNU_LOCAL_DB = "resource://Mobile.Assets.Svg.img-menu-local-db.svg";
            public const string IMG_MNU_ABOUT = "resource://Mobile.Assets.Svg.img-menu-about.svg";
            public const string IMG_MNU_CONNECTIONS = "resource://Mobile.Assets.Svg.img-menu-connections.svg";

            public const string IMG_MNU_LIST = "resource://Mobile.Assets.Svg.img-menu-report.svg";
            public const string IMG_MNU_CREATE = "resource://Mobile.Assets.Svg.img-menu-preparation.svg";
            public const string IMG_MNU_MODIFY = "resource://Mobile.Assets.Svg.img-list-value-edit.svg";
            public const string IMG_MNU_APPOINMENT = "resource://Mobile.Assets.Svg.img-menu-distribution.svg";
            public const string IMG_MNU_CREATE_APPOINTMENT = "resource://Mobile.Assets.Svg.img-menu-delivery.svg";

            //Home Page
            //  "resource://Mobile.Assets.Svg.img-menu-report.svg";
            public const string IMG_MNU_PREGNANT_MOTHER = "resource://Mobile.Assets.Svg.img-mom-baby.svg";
            public const string IMG_MNU_CHILD = "resource://Mobile.Assets.Svg.img-baby.svg";

            // Scan Screens
            public const string IMG_BARCODE_SCANNER = "resource://Mobile.Assets.Svg.img-barcode-scanner.svg";
            public const string IMG_COM_BARCODE = "resource://Mobile.Assets.Svg.img-com-barcode-scanner.svg";

            public const string IMG_LIST_OPENED = "resource://Mobile.Assets.Svg.img-list-opened.svg";
            public const string IMG_LIST_ASSIGN_PROGRESS = "resource://Mobile.Assets.Svg.img-list-assign-progress.svg";
            public const string IMG_LIST_ASSIGN_VALID = "resource://Mobile.Assets.Svg.img-list-assign-valid.svg";
        }

        public class AppIcons {
            public const string ICO_LOG_USERNAME = "ico_log_username";  // Note this has fo file name - don't change this
            public const string ICO_LOG_PASSWORD = "ico_log_password";  // Note this has fo file name - don't change this

            public const string ICO_BTN_NAVIGATE = "ico_btn_navigate_arrow.png";
            public const string ICO_COM_ADD_SAVE = "ico_com_add_save.png";
            public const string ICO_COM_BACK = "ico_com_back.png";
            public const string ICO_COM_CANCEL = "ico_com_cancel.png";
            public const string ICO_COM_CLOSE = "ico_com_close.png";
            public const string ICO_COM_CONFIRM = "ico_com_confirm.png";
            public const string ICO_COM_CONFIRM_FLOATING = "ico_com_confirm_button.png";
            public const string ICO_COM_CREATE_ORDER = "ico_com_create_order.png";
            public const string ICO_COM_CREATE_TRIP = "ico_com_create_trip_button.png";
            public const string ICO_COM_DECREASE = "ico_com_decrease.png";
            public const string ICO_COM_DELETE = "ico_com_delete.png";
            public const string ICO_COM_DELIVERY = "ico_com_delivery.png";
            public const string ICO_COM_EMERGENCY = "ico_com_emergency_button.png";
            public const string ICO_COM_INCREASE = "ico_com_increase.png";
            public const string ICO_COM_ITEMS = "ico_com_items.png";
            public const string ICO_COM_MANNAUL = "ico_com_mannual.png";
            public const string ICO_COM_MENU = "ico_com_menu.png";
            public const string ICO_COM_MODIFY_DATE = "ico_com_modify_date.png";
            public const string ICO_COM_MORE = "ico_com_more.png";
            public const string ICO_COM_NAVIGATE_FLOATING = "ico_com_navigate_button.png";
            public const string ICO_COM_NEUTRAL_FACE = "ico_com_neutral_face.png";
            public const string ICO_COM_SAVE_FLOATING = "ico_com_save_button.png";
            public const string ICO_COM_RETURN = "ico_com_return.png";
            public const string ICO_COM_SAD_FACE = "ico_com_sad_face.png";
            public const string ICO_COM_SETTINGS = "ico_com_settings.png";
            public const string ICO_COM_SKIP_RATING = "ico_com_skip_rating.png";
            public const string ICO_COM_SMILEY_FACE = "ico_com_smiley_face.png";
            public const string ICO_COM_TOOL_BAR_BLUETOOTH = "ico_com_toolbar_blutooth.png";
            public const string ICO_COM_CAMERA = "ico_com_toolbar_camera.png";
            public const string ICO_COM_UNLOAD_PRODUCT = "ico_com_unload_product.png";
            public const string ICO_COM_PRINT = "ico_com_print.png";
            public const string ICO_LST_ASSIGN_CHECKED = "ico_lst_assign_checked.png";
            public const string ICO_LST_ASSIGN_PROGRESS = "ico_lst_assign_progress.png";
            public const string ICO_LST_ASSIGN_VALID = "ico_lst_assign_valid.png";
            public const string ICO_LST_DOWNLOADED = "ico_lst_download.png";
            public const string ICO_LST_OPENED = "ico_lst_opened.png";
            public const string ICO_MNU_COLLAPSEMENU = "ico_mnu_collapsemenu.png";
            public const string ICO_MNU_DISTRIBUTION = "ico_mnu_distribution.png";
            public const string ICO_MNU_DISTRIBUTION_DELIVERY = "ico_mnu_distribution_delivery.png";
            public const string ICO_MNU_DISTRIBUTION_PICKUP = "ico_mnu_distribution_pickup.png";
            public const string ICO_MNU_EXPANDMENU = "ico_mnu_expandmenu.png";
            public const string ICO_MNU_FAVORITE_NOSELECT = "ico_mnu_favorite_noselect.png";
            public const string ICO_MNU_FAVORITE_SELECT = "ico_mnu_favorite_select.png";
            public const string ICO_MNU_PREPARATION = "ico_mnu_preparation.png";
            public const string ICO_MNU_PRODUCTION = "ico_mnu_production.png";

            public const string ICO_MNU_RELEASE_GROUP = "ico_mnu_release_group.png";
            public const string ICO_MNU_RELEASE_ITEM = "ico_mnu_release_item.png";
            public const string ICO_MNU_SHIPMENT = "ico_mnu_shipment.png";
            public const string ICO_MNU_SG = "ico_mnu_specialgas.png";
            public const string ICO_MNU_SG_ASSIGN_COA = "ico_mnu_specialgas_assign_coa.png";
            public const string ICO_MNU_SG_ASSIGN_WIP = "ico_mnu_specialgas_assign_wip.png";
            public const string ICO_MNU_SG_ASSIGN_WIP_PROCESS = "ico_mnu_specialgas_wip_process.png";

        }

        public class AnimationFile {
            public const string SCANNING = "search.json";
            public const string DOWNLOADING = "cloud-download.json";
            public const string UPLOADING = "cloud-upload.json";
            public const string SUCESS = "success.json";
            public const string DOWNLOAD_FAILED = "download-fail.json";
            public const string PRINTING = "printing.json";
        }

        public class Screen {
            public const string NAVIGATION_PAGE = "NavigationPage";
            public const string TRANSITION_NAVIGATION_PAGE = "TransitionNavigationPage";
            public const string HOME_PAGE = "HomePage";
            public const string LOGIN_PAGE = "LoginPage";
            public const string SYNC_MASTER_DATA_PAGE = "SyncMasterDataPage";
            public const string SETTING_PAGE = "SettingPage";
            public const string USER_MESSAGE_PAGE = "UserMessagePage";
            public const string DISCREPANCY_PAGE = "DiscrepancyPage";
            public const string SYNCHRONIZATION_PAGE = "SynchronizationPage";
            public const string TOOLBAR_ITEMS_PAGE = "ToolBarItemsPage";
            public const string ITEM_PAGE = "ItemPage";
            public const string DROPDOWN_PAGE = "DropDownPage";
            public const string ERROR_CONFIRMATION_LIST_PAGE = "ErrorConfirmationListPage";
            public const string DATE_TIME_SELECTION_PAGE = "DateTimeSelectionPage";
            public const string LANGUAGE_LIST_PAGE = "LanguageListPage";
            public const string ABOUT_PAGE = "AboutPage";
            public const string LOCAL_DB_PAGE = "LocalDBPage";
            public const string ARRIVAL_TIME_SELECT_PAGE = "ArrivalTimeSelectPage";

            public const string MOM_LIST_PAGE = "MotherListPage";
            public const string MOM_APPOINTMENT_LIST_PAGE = "MotherAppointmentListPage";
            public const string MOM_PAGE = "MotherPage";
            public const string MOM_APPOINTMENT_PAGE = "MotherAppointmentPage";

            public const string BABY_LIST_PAGE = "BabyListPage";
            public const string BABY_APPOINTMENT_LIST_PAGE = "BabyAppointmentListPage";
            public const string BABY_PAGE = "BabyPage";
            public const string BABY_APPOINTMENT_PAGE = "BabyAppointmentPage";

            public const string SIGNATURE_PAGE = "SignaturePage";
            

            #region Common
            public const string CALENDAR_PAGE = "CalendarPage";
            #endregion

        }

        public class NavigationParameterName {
            #region Common
            public const string TITLE = "TITLE";
            public const string DATA = "DATA";
            public const string PAGE = "PAGE";
            public const string TITLE_CODE = "TITLE_CODE";
            public const string DISPLAY_TEXT_CODE = "DISPLAY_TEXT_CODE";
            public const string CALL_BACK_REFRESH_DATA = "CALL_BACK_REFRESH_DATA";
            public const string CALL_BACK_BACK_BUTTON_CONFIRMATION = "CALL_BACK_BACK_BUTTON_CONFIRMATION";
            public const string CALL_BACK_SAVE_CONFIRMAION = "CALL_BACK_SAVE_CONFIRMAION";

            public const string MESSAGE_TYPE = "MESSAGE_TYPE";
            public const string MESSAGE_TITLE_CODE = "MESSAGE_TITLE_CODE";
            public const string MESSAGE_CODE = "MESSAGE_CODE";
            public const string MESSAGE_IS_CONFIRM = "MESSAGE_IS_CONFIRM";
            public const string MESSAGE_YES_NO = "MESSAGE_YES_NO";

            public const string DICREPANCY_TITLE = "DICREPANCY_TITLE";
            public const string DICREPANCY_MESSAGE = "DICREPANCY_MESSAGE";
            public const string DICREPANCY_IS_CONFIRM = "DICREPANCY_IS_CONFIRM";
            public const string DICREPANCIES = "DICREPANCIES";
            public const string DICREPANCY_RESULT = "DICREPANCY_RESULT";
            public const string CALL_BACK_DICREPANCY_ACCEPTED = "CALL_BACK_DICREPANCY_ACCEPTED";

            public const string MASTER_DATA_KEY_LIST = "MASTER_DATA_KEY_LIST";
            public const string IS_SELECTED_MASTER_DATA = "IS_SELECTED_MASTER_DATA";
            public const string I_SYNC_LOGIC = "I_SYNC_LOGIC";

            public const string TOOL_BAR_ITEMS = "TOOL_BAR_ITEMS";
            public const string TOOL_BAR_SELECTED_COMMAND = "TOOL_BAR_SELECTED_COMMAND";

            public const string DATE_TIME = "DATE_TIME";
            public const string DATE_TIME_RESULT = "DATE_TIME_RESULT";
            public const string CALL_BACK_DATE_TIME = "CALL_BACK_DATE_TIME";

            public const string SETTING_ITEM = "SETTING_ITEM";


            public const string CALL_BACK_REQUIRED = "CALL_BACK_REQUIRED";
            public const string CALL_BACK_FUNCTION_CODE = "CALL_BACK_FUNCTION_CODE";
            public const string CALL_BACK_DATA_SYNC_SUCESS = "CALL_BACK_DATA_SYNC_SUCESS";
            public const string CALL_BACK_DATA_SYNC_FAILED = "CALL_BACK_DATA_SYNC_FAILED";
            public const string CALL_BACK_LANGUAGE_SELECTED = "CALL_BACK_LANGUAGE_SELECTED";
            public const string CALL_BACK_CONNECTION_NOT_AVAILABLE = "CALL_BACK_CONNECTION_NOT_AVAILABLE";

            public const string CALL_BACK_ACCEPTED = "CALL_BACK_ACCEPTED";
            public const string CALL_BACK_CREATE_ACCEPTED = "CALL_BACK_CREATE_ACCEPTED";


            public const string CALL_BACK_ACCPT_TO_ENTER_ARRIVALTIME = "CALL_BACK_ACCPT_TO_ENTER_ARRIVALTIME";
            public const string CALL_BACK_ARRIVALTIME_CONFIRMED = "CALL_BACK_ARRIVALTIME_CONFIRMED";
            public const string CALL_BACK_ARRIVALTIME_CAPTURED = "CALL_BACK_ARRIVALTIME_CAPTURED";

            public const string CALL_BACK_SAVE = "CALL_BACK_SAVE";
            #endregion


            #region Calendar
            public const string CALENDAR_CATEGORY = "CALENDAR_CATEGORY";
            public const string CALL_BACK_CALENDAR_SELECT = "CALL_BACK_CALENDAR_SELECT";
            public const string CALENDAR_DATE = "CALENDAR_DATE";
            public const string CALENDAR_YEAR = "CALENDAR_YEAR";
            public const string CALENDAR_MONTH = "CALENDAR_MONTH";
            #endregion

            #region DropDown
            public const string DROP_DOWN_DATA_CATEGORY = "DROP_DOWN_DATA_CATEGORY";
            public const string DROP_DOWN_DATA_LIST = "DROP_DOWN_DATA_LIST";
            public const string DROP_DOWN_DATA = "DROP_DOWN_DATA";
            public const string CALL_BACK_DROP_DOWN_DATA_SELECTED = "CALL_BACK_DROP_DOWN_DATA_SELECTED";

            #region Settings
            public const string PRINTER_MODEL = "PRINTER_MODEL";
            #endregion

            public const string SELECTED_ITEM = "SELECTED_ITEM";
            public const string ARRIVAL_TIME = "ARRIVAL_TIME";
            #endregion


        }

        public class ConversionFomat {
            public const string DECIMAL_FORMAT_1 = "{0:0.00}";
            public const string NUMBER_FORMAT = "0.##";
            public const string INT_FORMAT = "{0:0}";
        }

        public class DatTimeFormat {
            public const string YYYY_MM_DD = "yyyy/MM/dd";
            public const string HH_mm = "HH:mm:ss";
            public const string YYYY_MM_DD_HH_mm_ss = "yyyy-MM-dd HH:mm:ss";
        }

        public class Others {
            public const int LOAD_DELAY = 100;
            public const int LOAD_DELAY_SETTINGS_PAGE = 500;
        }


        public static class Parameter {
            public const string SEX = "SEX";
            public const string MOTHER = "MOTHER";
            public const string BABY = "BABY";
        }


        public static class MessageConstant {

        }

        public static class PrintConstant {

            #region Font
            public static string ENGLISH_FONT = "ENGLISH_FONT";
            public static string ENGLISH_ITALIC_FONT = "ENGLISH_ITALIC_FONT";

            public static string ENGLISH_FONT_NAME = "arial.ttf";
            public static string ENGLISH_ITALIC_FONT_NAME = "ArialItalic.ttf";
            #endregion
        }

        public class UserSettingKey {
            public const string FAVOURITE_MENUS = "FAVOURITE_MENUS";
        }

        public static class ServerName {
            #region DEV
            public const string DEV = "http://10.225.12.6";
            #endregion

            #region UAT
            public const string UAT = "http://10.225.13.46";
            #endregion

            #region PROD
            public const string PROD = "http://10.225.13.46";
            #endregion
        }


        public static class ApplicationName {
            public const string UAT = "Mom&Baby";
            public const string LIVE = "LIVE";
        }


    }
}
