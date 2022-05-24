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
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Core.Extensions;
using Mobile.Data;
using Mobile.Enum;
using Mobile.Models.Common;
using Mobile.Services;
using Plugin.DeviceInfo;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace Mobile.Helpers {
    public class CommonFunction : BindableBase, ICommonFunction {

        #region Private Variables
        private List<string> _favouriteMenuFunctionCodes;
        private AppMenuGroup _appMenuGroup;
        private ObservableCollection<AppMenuGroup> _authorizedAppMenuGroups;
        private ObservableCollection<AppMenuItem> _favouriteMenus;
        private UserSetting _userSetting;
        private ILoadingPageService _loadingPageService;
        private IUserSettingDataService _userSettingDataService;
        private IUserSettingService _userSettingService;
        #endregion

        #region Properties
        public ObservableCollection<AppMenuGroup> AuthorizedAppMenuGroups {
            get { return _authorizedAppMenuGroups; }
            set { SetProperty(ref _authorizedAppMenuGroups, value); }
        }
        #endregion

        #region Constructor
        public CommonFunction(ILoadingPageService loadingPageService,
                              IUserSettingDataService userSettingDataService,
                              IUserSettingService userSettingService) {
            try {
                _loadingPageService = loadingPageService;
                _userSettingDataService = userSettingDataService;
                _userSettingService = userSettingService;
                _authorizedAppMenuGroups = new ObservableCollection<AppMenuGroup>();
            } catch (Exception) {

            }
        }


        #endregion

        #region Methods
        public async Task CreateAppMenuGroup() {
            _authorizedAppMenuGroups = new ObservableCollection<AppMenuGroup>();
            await ProcessFavouriteMenus();
            AddMomMenus();
            AddBabyMenus();
        }

        private async Task ProcessFavouriteMenus() {
            try {
                string menus = string.Empty;
                _favouriteMenuFunctionCodes = new List<string>();


                // Case 01 (Setting Found locally)
                _userSetting = await _userSettingDataService.GetItemsByKey(GlobalSetting.Instance.User.UserName, AppConstant.UserSettingKey.FAVOURITE_MENUS);
                if (_userSetting != null
                   && !string.IsNullOrEmpty(_userSetting.Values)) {
                    AddToFavoriteMenus(_userSetting.Values);
                    return;
                }

                // Case 02 (Setting Found Remotely)
                if (ConnectionDecider.Instance.IsOnline()) {
                    _userSetting = await _userSettingService.GetUserSettingByKey(GlobalSetting.Instance.User.UserName, AppConstant.UserSettingKey.FAVOURITE_MENUS);
                }
                if (_userSetting != null
                    && !string.IsNullOrEmpty(_userSetting.Values)) {
                    AddToFavoriteMenus(_userSetting.Values);
                    await _userSettingDataService.SaveItemAsync(_userSetting);
                    return;
                }

                // Case 03 (Not in local and remote)
                if (GlobalSetting.Instance.User.FunctionList.IsNotNullOrEmpty()) {
                    // 01 Add default Collection
                    if (GlobalSetting.Instance.User.FunctionList.Count > 0) {
                        for (int i = 0; i <= 1; i++) {
                            _favouriteMenuFunctionCodes.Add(GlobalSetting.Instance.User.FunctionList[i].FunctionCode);
                            menus = string.IsNullOrEmpty(menus) ? GlobalSetting.Instance.User.FunctionList[i].FunctionCode : menus + "," + GlobalSetting.Instance.User.FunctionList[i].FunctionCode;
                        }
                    } else {
                        _favouriteMenuFunctionCodes.Add(GlobalSetting.Instance.User.FunctionList[0].FunctionCode);
                        menus = GlobalSetting.Instance.User.FunctionList[0].FunctionCode;
                    }

                    _userSetting = new UserSetting() { UserId = GlobalSetting.Instance.User.UserName, Key = AppConstant.UserSettingKey.FAVOURITE_MENUS, Values = menus };
                    // 02 Save locally
                    await _userSettingDataService.SaveItemAsync(_userSetting);

                    // 03 Save Remotely
                    if (ConnectionDecider.Instance.IsOnline()) {
                        await _userSettingService.SaveUserSetting(_userSetting);
                    }
                }
            } catch (Exception) {
            }
        }

        private void AddToFavoriteMenus(string passedValues) {
            var values = passedValues.Split(',');
            foreach (var item in values) {
                _favouriteMenuFunctionCodes.Add(item);
            }
        }

        private AppMenuItem GetMenuItem(string functionCode, string functionNameCode, string iconImage, int order, string buttonIcon, string screenToOpen, INavigationParameters param = null) {
            AppMenuItem appMenuItem;
            appMenuItem = new AppMenuItem();
            appMenuItem.FunctionCode = functionCode;
            appMenuItem.MenuName = GetConvertedMessage(functionNameCode);
            appMenuItem.Icon = iconImage;
            appMenuItem.Order = order;
            appMenuItem.IsFavorite = _favouriteMenuFunctionCodes.Contains(appMenuItem.FunctionCode);
            appMenuItem.ButtonIcon = buttonIcon;
            appMenuItem.ScreenToOpen = screenToOpen;
            appMenuItem.INavigationParameters = param == null ? new NavigationParameters() : param;
            return appMenuItem;
        }


        private void AddMomMenus() {
            _appMenuGroup = new AppMenuGroup(GetConvertedMessage(Message.BTN_MAIN_001), AppConstant.AppImges.IMG_MOTHER, 1);

            _appMenuGroup.Add(GetMenuItem("mnuMotherList", GetConvertedMessage(Message.BTN_MAIN_003), AppConstant.AppImgesSvg.IMG_MNU_LIST, 1, null, AppConstant.Screen.MOM_LIST_PAGE));
            NavigationParameters modifyNavigationParameters = new NavigationParameters();
            modifyNavigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_CREATE_MOTHER);
            _appMenuGroup.Add(GetMenuItem("mnuMotherCreate", GetConvertedMessage(Message.BTN_MAIN_004), AppConstant.AppImgesSvg.IMG_MNU_CREATE, 1, null, AppConstant.Screen.MOM_PAGE, modifyNavigationParameters));
            //modifyNavigationParameters = new NavigationParameters();
            //modifyNavigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_MODIFY_MOTHER);
           // _appMenuGroup.Add(GetMenuItem("mnuMotherModify", GetConvertedMessage(Message.BTN_MAIN_005), AppConstant.AppImgesSvg.IMG_MNU_MODIFY, 1, null, AppConstant.Screen.MOM_PAGE, modifyNavigationParameters));
            _appMenuGroup.Add(GetMenuItem("mnuMotherAppoinmentList", GetConvertedMessage(Message.BTN_MAIN_006), AppConstant.AppImgesSvg.IMG_MNU_APPOINMENT, 1, null, AppConstant.Screen.MOM_APPOINTMENT_LIST_PAGE));
            _appMenuGroup.Add(GetMenuItem("mnuMotherCreateAppoinment", GetConvertedMessage(Message.BTN_MAIN_007), AppConstant.AppImgesSvg.IMG_MNU_CREATE_APPOINTMENT, 1, null, AppConstant.Screen.MOM_APPOINTMENT_PAGE));

            AuthorizedAppMenuGroups.Add(_appMenuGroup);
        }

        private void AddBabyMenus() {
            _appMenuGroup = new AppMenuGroup(GetConvertedMessage(Message.BTN_MAIN_002), AppConstant.AppImges.IMG_BABY, 2);

            _appMenuGroup.Add(GetMenuItem("mnuBabyList", GetConvertedMessage(Message.BTN_MAIN_008), AppConstant.AppImgesSvg.IMG_MNU_LIST, 1, null, AppConstant.Screen.BABY_LIST_PAGE));
            NavigationParameters modifyNavigationParameters = new NavigationParameters();
            modifyNavigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_CREATE_BABY);
            _appMenuGroup.Add(GetMenuItem("mnuBabyCreate", GetConvertedMessage(Message.BTN_MAIN_009), AppConstant.AppImgesSvg.IMG_MNU_CREATE, 1, null, AppConstant.Screen.BABY_PAGE, modifyNavigationParameters));
            //modifyNavigationParameters = new NavigationParameters();
            //modifyNavigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_MODIFY_BABY);
            //_appMenuGroup.Add(GetMenuItem("mnuBabyModify", GetConvertedMessage(Message.BTN_MAIN_010), AppConstant.AppImgesSvg.IMG_MNU_MODIFY, 1, null, AppConstant.Screen.BABY_PAGE, modifyNavigationParameters));
            _appMenuGroup.Add(GetMenuItem("mnuBabyAppoinmentList", GetConvertedMessage(Message.BTN_MAIN_011), AppConstant.AppImgesSvg.IMG_MNU_APPOINMENT, 1, null, AppConstant.Screen.BABY_APPOINTMENT_LIST_PAGE));
            _appMenuGroup.Add(GetMenuItem("mnuBabyCreateAppoinment", GetConvertedMessage(Message.BTN_MAIN_012), AppConstant.AppImgesSvg.IMG_MNU_CREATE_APPOINTMENT, 1, null, AppConstant.Screen.BABY_APPOINTMENT_PAGE));

            AuthorizedAppMenuGroups.Add(_appMenuGroup);
        }

        public bool IsAuthorized(string functionCode) {
            if (Settings.UseMock) {
                return true;
            } else {
                if (GlobalSetting.Instance.User.FunctionList.IsNotNullOrEmpty()) {
                    return GlobalSetting.Instance.User.FunctionList.Exists(a => a.FunctionCode == functionCode);
                }
            }
            return false;
        }

        public ObservableCollection<AppMenuItem> GetFavouriteAppMenus() {
            if (_favouriteMenus != null) {
                return _favouriteMenus;
            }
            ObservableCollection<AppMenuItem> appMenuItems = new ObservableCollection<AppMenuItem>();
            List<AppMenuItem> appMenuItemlist;
            if (AuthorizedAppMenuGroups.IsNotNullOrEmpty()) {
                foreach (AppMenuGroup appMenuGroup in AuthorizedAppMenuGroups) {
                    appMenuItemlist = appMenuGroup.Where(a => a.IsFavorite).ToList();
                    if (appMenuItemlist != null && appMenuItemlist.Count > 0) {
                        foreach (var item in appMenuItemlist) {
                            appMenuItems.Add(item);
                        }
                    }
                }
            }
            _favouriteMenus = appMenuItems;
            return appMenuItems;
        }

        public async Task ChangeFavouriteMenu(AppMenuItem appMenuItem) {
            if (_favouriteMenus == null) {
                _favouriteMenus = new ObservableCollection<AppMenuItem>();
            }
            if (appMenuItem.IsFavorite) {
                _favouriteMenus.Add(appMenuItem);
                _favouriteMenuFunctionCodes.Add(appMenuItem.FunctionCode);
            } else {
                _favouriteMenus.Remove(appMenuItem);
                _favouriteMenuFunctionCodes.Remove(appMenuItem.FunctionCode);
            }

            _userSetting.Values = string.Empty;
            if (_favouriteMenuFunctionCodes.Count > 0) {
                foreach (var item in _favouriteMenuFunctionCodes) {
                    _userSetting.Values = string.IsNullOrEmpty(_userSetting.Values) ? item : _userSetting.Values + "," + item;
                }
            } else {
                _userSetting.Values = string.Empty;
            }

            // 01 Save locally
            await _userSettingDataService.SaveItemAsync(_userSetting);

            // 02 Save Remotely
            if (ConnectionDecider.Instance.IsOnline()) {
                await _userSettingService.SaveUserSetting(_userSetting);
            }
        }

        public async Task DisplayDeviceInfo() {
            var appversion = "App Version " + CrossDeviceInfo.Current.AppVersion;
            var DeviceName = "App DeviceName " + CrossDeviceInfo.Current.DeviceName;
            var Model = "App Model " + CrossDeviceInfo.Current.Model;
            var Manufacturer = "App Version " + CrossDeviceInfo.Current.Manufacturer;

            await Application.Current.MainPage.DisplayAlert("Device Info", appversion + DeviceName + Model + Manufacturer, "OK");
        }

        public async Task DisplayDiscrepancy(INavigationService navigationService, string titleCode, string discrepancyMessageCode, List<Discrepancy> discrepancies, bool isConfirm = false, string confirmationForFunctionCode = "", bool isYesNo = false) {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(AppConstant.NavigationParameterName.DICREPANCY_TITLE, GetConvertedMessage(titleCode));
            navigationParams.Add(AppConstant.NavigationParameterName.DICREPANCY_MESSAGE, GetConvertedMessage(discrepancyMessageCode));
            navigationParams.Add(AppConstant.NavigationParameterName.DICREPANCIES, discrepancies);
            navigationParams.Add(AppConstant.NavigationParameterName.DICREPANCY_IS_CONFIRM, isConfirm);
            navigationParams.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, confirmationForFunctionCode);
            navigationParams.Add(AppConstant.NavigationParameterName.MESSAGE_YES_NO, isYesNo);
            await navigationService.NavigateAsync(AppConstant.Screen.DISCREPANCY_PAGE, navigationParams);
        }

        public async Task DisplayMessage(INavigationService navigationService, MessageType messageType, string titleCode, string messageCode, object[] values = null, bool isConfirm = false, string confirmationForFunctionCode = "", bool isYesNo = false) {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(AppConstant.NavigationParameterName.MESSAGE_TYPE, messageType);
            navigationParams.Add(AppConstant.NavigationParameterName.MESSAGE_TITLE_CODE, GetConvertedMessage(titleCode));
            navigationParams.Add(AppConstant.NavigationParameterName.MESSAGE_IS_CONFIRM, isConfirm);
            navigationParams.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, confirmationForFunctionCode);
            navigationParams.Add(AppConstant.NavigationParameterName.MESSAGE_YES_NO, isYesNo);
            if (values == null) {
                navigationParams.Add(AppConstant.NavigationParameterName.MESSAGE_CODE, GetConvertedMessage(messageCode));
            } else {
                navigationParams.Add(AppConstant.NavigationParameterName.MESSAGE_CODE, GetConvertedMessage(messageCode, values));
            }
            await navigationService.NavigateAsync(AppConstant.Screen.USER_MESSAGE_PAGE, navigationParams);
        }

        public string GetConvertedMessage(string messageCode) {
            return L10n.Localize(messageCode, "");
        }

        public string GetConvertedMessage(string messageCode, object[] values) {
            return string.Format((L10n.Localize(messageCode, "")), values);
        }

        #region PlayBeepSound
        private void PlayBeep() {
            var stream = GetStreamFromFile();
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            audio.Load(stream);
            audio.Play();
        }
        private Stream GetStreamFromFile() {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(AppConstant.AppSound.BEEP);
            return stream;
        }
        #endregion

        public bool ValidateFutureDate(DateTime selectedDate) {
            DateTime nextMonthFirstDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            if (selectedDate >= nextMonthFirstDate)
                return false;

            return true;
        }

        public bool ValidatePastDate(DateTime selectedDate) {
            DateTime currentMonthFirstDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            if (selectedDate <= currentMonthFirstDate)
                return false;

            return true;
        }

        public bool ValidateWeight(decimal weight) {
            if (Convert.ToDecimal(weight) > 0)
                return true;
            else
                return false;
        }

        public void ShowActivityIndicator(string message) {
            _loadingPageService.ShowLoadingPage(message);
        }

        public void HideActivityIndicator() {
            _loadingPageService.HideLoadingPage();
        }


        #endregion

    }
}
