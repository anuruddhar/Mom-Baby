#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Helpers
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
21/02/2022         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Core.Extensions;
using Mobile.Data.MockData;
using Mobile.Enum;
using Mobile.Events;
using Mobile.Helpers;
using Mobile.Logic;
using Mobile.Models.Common;
using Plugin.DeviceInfo;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace Mobile.ViewModels {
    public class HomePageViewModel : ViewModelBase {

        #region Private Variables
        private string _mainButtonIcon = AppConstant.AppIcons.ICO_COM_MENU;
        private string _settingMenuIcon = AppConstant.AppIcons.ICO_COM_SETTINGS;
        private string _mainScreenBanner = AppConstant.AppImges.IMG_MAIN_SCREEN_BANNER;
        private string _motherButtonImage = AppConstant.AppImges.IMG_MOTHER;
        private string _babyButtonImage = AppConstant.AppImges.IMG_BABY;
        private string _motherIcon = AppConstant.AppImges.IMG_MOTHER;
        private string _babyIcon = AppConstant.AppImges.IMG_BABY;
        private string _familyIcon = AppConstant.AppImges.IMG_FAMILY;
        private string _motherNewIcon = AppConstant.AppImges.IMG_NEW_MOTHER;
        private string _babyNewIcon = AppConstant.AppImges.IMG_NEW_BABY;
        private string _headerInfomation;
        private string _detailInformation;
        private string _appVersion = "Version " + CrossDeviceInfo.Current.AppVersion;
        private int _motherHealthDataToBeSynced = 0;
        private int _babyHealthDataToBeSynced = 0;
        private int _motherDataToBeSynced = 0;
        private int _babyDataToBeSynced = 0;
        private ObservableCollection<AppMenuItem> _favouriteMenus;
        private string _logo = AppConstant.AppImges.IMG_APPLOGO;
        private string _logOutImage = AppConstant.AppImgesSvg.IMG_MNU_LOG_OUT;
        private string _loginUserId = string.Empty;
        private ObservableCollection<AppMenuGroup> _AllAppMenuGroups;
        private ObservableCollection<AppMenuGroup> _ExpandedAppMenuGroups;
        private ILoadingPageService _iLoadingPageService;
        #endregion

        #region Properties
        public ICommand OpenMotherPageCommand => new DelegateCommand(async () => await OpenMotherPage());
        public ICommand OpenBabyPageCommand => new DelegateCommand(async () => await OpenBabyPage());
        public ICommand OpenSettingPageCommand => new DelegateCommand(OpenSettingPage);
        public ICommand MotherHealthDataSyncCommand => new DelegateCommand(async () => await SynchronizeMotherHealthData());
        public ICommand BabyHealthDataSyncCommand => new DelegateCommand(async () => await SynchronizeBabyHealthData());
        public ICommand MotherDataSyncCommand => new DelegateCommand(async () => await SynchronizeMotherData());
        public ICommand BabyDataSyncCommand => new DelegateCommand(async () => await SynchronizeBabyData());
        public ICommand ChangeFavouriteColletionCommand;
        public ICommand OnMenuTappedCommand;
        public ICommand LogOutCommand { get; private set; }
        public ICommand OnMenuShowHideCommand;

        public string HeaderInformation {
            get { return _headerInfomation; }
            set { SetProperty(ref _headerInfomation, value); }
        }

        public string DetailInformation {
            get { return _detailInformation; }
            set { SetProperty(ref _detailInformation, value); }
        }

        public string SettingButtonIcon {
            get { return _settingMenuIcon; }
            set { SetProperty(ref _settingMenuIcon, value); }
        }

        public string MainButtonIcon {
            get { return _mainButtonIcon; }
            set { SetProperty(ref _mainButtonIcon, value); }
        }

        public string MainScreenBanner {
            get { return _mainScreenBanner; }
            set { SetProperty(ref _mainScreenBanner, value); }
        }

        public string MotherButtonImage {
            get { return _motherButtonImage; }
            set { SetProperty(ref _motherButtonImage, value); }
        }

        public string BabyButtonImage {
            get { return _babyButtonImage; }
            set { SetProperty(ref _babyButtonImage, value); }
        }

        public string MotherIcon {
            get { return _motherIcon; }
            set { SetProperty(ref _motherIcon, value); }
        }

        public string BabyIcon {
            get { return _babyIcon; }
            set { SetProperty(ref _babyIcon, value); }
        }

        public string FamilyIcon {
            get { return _familyIcon; }
            set { SetProperty(ref _familyIcon, value); }
        }

        public string MotherNewIcon {
            get { return _motherNewIcon; }
            set { SetProperty(ref _motherNewIcon, value); }
        }

        public string BabyNewIcon {
            get { return _babyNewIcon; }
            set { SetProperty(ref _babyNewIcon, value); }
        }


        public string LoginUserId {
            get { return _loginUserId; }
            set { SetProperty(ref _loginUserId, value); }
        }

        public ObservableCollection<AppMenuItem> FavouriteMenus {
            get { return _favouriteMenus; }
            set { SetProperty(ref _favouriteMenus, value); }
        }


        public string LogOutImage {
            get { return _logOutImage; }
            set { SetProperty(ref _logOutImage, value); }
        }

        public string Logo {
            get { return _logo; }
            set { SetProperty(ref _logo, value); }
        }

        public ObservableCollection<AppMenuGroup> ExpandedAppMenuGroups {
            get { return _ExpandedAppMenuGroups; }
            set { SetProperty(ref _ExpandedAppMenuGroups, value); }
        }

        public string AppVersion {
            get { return _appVersion; }
            set { SetProperty(ref _appVersion, value); }
        }

        public int MotherHealthDataToBeSynced {
            get { return _motherHealthDataToBeSynced; }
            set { SetProperty(ref _motherHealthDataToBeSynced, value); }
        }

        public int BabyHealthDataToBeSynced {
            get { return _babyHealthDataToBeSynced; }
            set { SetProperty(ref _babyHealthDataToBeSynced, value); }
        }

        public int MotherDataToBeSynced {
            get { return _motherDataToBeSynced; }
            set { SetProperty(ref _motherDataToBeSynced, value); }
        }

        public int BabyDataToBeSynced {
            get { return _babyDataToBeSynced; }
            set { SetProperty(ref _babyDataToBeSynced, value); }
        }

        #endregion

        #region Constructor
        public HomePageViewModel(INavigationService navigationService,
                                 IEventAggregator eventAggregator,
                                 IUserDialogs dialogs,
                                 ICommonFunction commonFunction,
                                 ILoadingPageService loadingPageService
                                 )
                : base(navigationService, eventAggregator, dialogs, commonFunction, string.Empty) {
            IsNormalPage = false;
            _iLoadingPageService = loadingPageService;
            ChangeFavouriteColletionCommand = new DelegateCommand<AppMenuItem>(async ami => await ChangeFavouriteColletion(ami));
            OnMenuTappedCommand = new DelegateCommand<AppMenuItem>(async ami => await OnMenuTapped(ami));
            LogOutCommand = new DelegateCommand(async () => await OnLogOut());
            OnMenuShowHideCommand = new DelegateCommand<AppMenuGroup>(vm => OnMenuShowHide(vm));
            _AllAppMenuGroups = CommonFunction.AuthorizedAppMenuGroups;
            FavouriteMenus = CommonFunction.GetFavouriteAppMenus();
            LoginUserId = GlobalSetting.Instance.User.Name;
            UpdateListContent();

            if (Settings.UseMock) {
                _motherHealthDataToBeSynced = SyncMockData.Instance.MotherHealthDataToBeSynced;
                _babyHealthDataToBeSynced = SyncMockData.Instance.BabyHealthDataToBeSynced;
                _motherDataToBeSynced = SyncMockData.Instance.MotherDataToBeSynced;
                _babyDataToBeSynced = SyncMockData.Instance.BabyDataToBeSynced;
            }
        }
        #endregion

        #region Methods
        protected override void OnPageAppearing() {
            HeaderInformation = "Mom & Baby";
            EventAggregator.GetEvent<MenuClickEvent>().Subscribe(OnMenuFavTapped);
            GlobalSetting.TransitionType = TransitionType.Flip;
        }

        protected override async void OnPageResume(INavigationParameters parameters) {
            try {
                if (IsCallBackRequired(parameters)) {
                    await InvokeCallBack(parameters);
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task InvokeCallBack(INavigationParameters parameters) {
            _callBackFunctionCode = (string)parameters[AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE];
            switch (_callBackFunctionCode) {
                case AppConstant.NavigationParameterName.CALL_BACK_BACK_BUTTON_CONFIRMATION:
                    await OnLogOut();
                    break;
                default:
                    break;
            }
        }

        protected override void OnPageDisappearing() {
            EventAggregator.GetEvent<MenuClickEvent>().Unsubscribe(OnMenuFavTapped);
        }

        #region Open Pages
        private async void OpenSettingPage() {
            await NavigationService.NavigateAsync(AppConstant.Screen.SETTING_PAGE);
        }

        protected async Task OpenMotherPage() {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_MOTHER_APPOINTMENTS);
            await NavigationService.NavigateAsync(AppConstant.Screen.MOM_APPOINTMENT_LIST_PAGE, navigationParameters);
        }
        private async Task OpenBabyPage() {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_BABY_APPOINTMENTS);
            await NavigationService.NavigateAsync(AppConstant.Screen.BABY_APPOINTMENT_LIST_PAGE, navigationParameters);
        }

        private async Task OnMenuTapped(AppMenuItem appMenuItem) {
            await NavigationService.NavigateAsync(appMenuItem.ScreenToOpen, appMenuItem.INavigationParameters);
        }

        private async void OnMenuFavTapped(AppMenuItem appMenuItem) {

            await NavigationService.NavigateAsync(appMenuItem.ScreenToOpen, appMenuItem.INavigationParameters);
        }
        #endregion

        private async Task ChangeFavouriteColletion(AppMenuItem appMenuItem) {
            await CommonFunction.ChangeFavouriteMenu(appMenuItem);
            ObservableCollection<AppMenuItem> items = CommonFunction.GetFavouriteAppMenus();
            FavouriteMenus = new ObservableCollection<AppMenuItem>();
            foreach (var item in items) {
                FavouriteMenus.Add(item);
            }
        }


        private void UpdateListContent() {
            ExpandedAppMenuGroups = new ObservableCollection<AppMenuGroup>();
            if (_AllAppMenuGroups.IsNotNullOrEmpty()) {
                foreach (AppMenuGroup group in _AllAppMenuGroups) {
                    AppMenuGroup newGroup = new AppMenuGroup(group.Title, group.MenuIcon, group.Order, group.Expanded);
                    if (group.Expanded) {
                        foreach (AppMenuItem appMenuItem in group) {
                            newGroup.Add(appMenuItem);
                        }
                    }
                    ExpandedAppMenuGroups.Add(newGroup);
                }
            }
        }

        private void OnMenuShowHide(AppMenuGroup appMenuGroup) {
            int selectedIndex = _ExpandedAppMenuGroups.IndexOf(appMenuGroup);
            _AllAppMenuGroups[selectedIndex].Expanded = !_AllAppMenuGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        protected override async void OnPageBackButtonPressed() {
            await DisplayMessage(MessageType.Question, Message.CAP_LOG_OUT, Message.MSG_COM_021, null, true, AppConstant.NavigationParameterName.CALL_BACK_BACK_BUTTON_CONFIRMATION);
        }

        private async Task OnLogOut() {
            try {

            } catch (Exception) { }

            CommonFunction.AuthorizedAppMenuGroups = null;
            await NavigationService.NavigateAsync("app:///TransitionNavigationPage/LoginPage");

        }

        #region SyncData
        protected override async Task OnCheckSynchronizeData() {
            if (Settings.UseMock) {
                _motherHealthDataToBeSynced = SyncMockData.Instance.MotherHealthDataToBeSynced;
                _babyHealthDataToBeSynced = SyncMockData.Instance.BabyHealthDataToBeSynced;
                _motherDataToBeSynced = SyncMockData.Instance.MotherDataToBeSynced;
                _babyDataToBeSynced = SyncMockData.Instance.BabyDataToBeSynced;
            }
        }

        private async Task SynchronizeMotherHealthData() {
            await SynchronizeData(MotherHelathSyncLogic.Instance);
            if (ConnectionDecider.Instance.IsOnline()) {
                SyncMockData.Instance.MotherHealthDataToBeSynced = 0;
                MotherHealthDataToBeSynced = 0;
            }
        }

        private async Task SynchronizeBabyHealthData() {
            await SynchronizeData(BabyHealthSyncLogic.Instance);
            if (ConnectionDecider.Instance.IsOnline()) {
                SyncMockData.Instance.BabyHealthDataToBeSynced = 0;
                BabyHealthDataToBeSynced = 0;
            }
        }

        private async Task SynchronizeMotherData() {
            await SynchronizeData(MotherSyncLogic.Instance);
            if (ConnectionDecider.Instance.IsOnline()) {
                SyncMockData.Instance.MotherDataToBeSynced = 0;
                MotherDataToBeSynced = 0;
            }
        }

        private async Task SynchronizeBabyData() {
            await SynchronizeData(BabySyncLogic.Instance);
            if (ConnectionDecider.Instance.IsOnline()) {
                SyncMockData.Instance.BabyDataToBeSynced = 0;
                BabyDataToBeSynced = 0;
            }
        }


        private async Task SynchronizeData(ISyncLogic syncLogic) {
            if (ConnectionDecider.Instance.IsOnline()) {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(AppConstant.NavigationParameterName.I_SYNC_LOGIC, syncLogic);
                await NavigationService.NavigateAsync(AppConstant.Screen.SYNCHRONIZATION_PAGE, navigationParameters);
            } else {
                await DisplayMessage(MessageType.Message, Message.MSG_COM_027, Message.MSG_COM_001);
            }
        }
        #endregion

        #endregion
    }
}


