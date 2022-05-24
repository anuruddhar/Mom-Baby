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
using Mobile.Core.Helpers;
using Mobile.Data;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Models.Login;
using Mobile.Services;
using Plugin.DeviceInfo;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
#endregion


namespace Mobile.ViewModels {
    public class LoginPageViewModel : ViewModelBase {

        #region Private Variables
        #region Services
        private ILoginService _loginService;
        private IMidwifeDataService _midwifeDataService;
        private IUserFunctionDataService _userFunctionDataService;


        #endregion
        private string callBackFunctionCode;
        private Midwife _user;
        #endregion

        #region Properties
        private string _BackgroundImage = AppConstant.AppImges.IMG_LOGIN_BACKGROUND;
        private string _UserIcon = AppConstant.AppIcons.ICO_LOG_USERNAME;
        private string _PasswordIcon = AppConstant.AppIcons.ICO_LOG_PASSWORD;
#if DEBUG
        private string _userId = "833143261v";
        private string _password = "UAT@123";
#else
        private string _userId = string.Empty;
        private string _password = string.Empty;
#endif
        private string _appVersion = "Version " + CrossDeviceInfo.Current.AppVersion;


        public Page MainPage;
        public ICommand NavigateToHomePageCommand { get; protected set; }

        public string BackgroundImage {
            get { return _BackgroundImage; }
            set { SetProperty(ref _BackgroundImage, value); }
        }
        public string UserIcon {
            get { return _UserIcon; }
            set { SetProperty(ref _UserIcon, value); }
        }
        public string PasswordIcon {
            get { return _PasswordIcon; }
            set { SetProperty(ref _PasswordIcon, value); }
        }
        public string UserId {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }
        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public string AppVersion {
            get { return _appVersion; }
            set { SetProperty(ref _appVersion, value); }
        }
        #endregion

        #region Constructor

        public LoginPageViewModel(INavigationService navigationService,
                                  IEventAggregator eventAggregator,
                                  IUserDialogs dialogs,
                                  ICommonFunction commonFunction,
                                  ILoginService loginService,
                                  IMidwifeDataService midwifeDataService,
                                  IUserFunctionDataService userFunctionDataService
            )
            : base(navigationService, eventAggregator, dialogs, commonFunction, string.Empty) {
            IsNormalPage = false;
            _loginService = loginService;
            _midwifeDataService = midwifeDataService;
            _userFunctionDataService = userFunctionDataService;

            GlobalSetting.Instance.PDTNo = Settings.DeviceId;
        }


        #endregion

        #region PageLifeCycle
        protected override void OnPageAppearing() {

        }
        protected override void OnPageDisappearing() {

        }
        #endregion

        #region Methods


        #region Commands
        public ICommand LoginCommand => new DelegateCommand(Login);

        private async void Login() {
            try {
                await CheckLogin();
            } catch (Exception ex) {
                if (ex.Message == "WebException") {
                    await DisplayMessage(MessageType.Warning, Message.CAP_LOGIN, Message.ERR_UNABLE_TO_CONNECT);
                } else {
                    await DisplayMessage(MessageType.Error, Message.CAP_LOGIN, Message.ERR_UN_EXPECTED);
                }
            } finally {

            }
        }
        #endregion

        #region Base Method Override
        protected override async void OnPageResume(INavigationParameters parameters) {

        }
        #endregion

        #region IConnectionDecider Members
        protected async override Task<bool> OnDoOnlineProcessing() {
            try {
                return await OfflineLoginCheck();
            } catch (Exception ex) {
                throw ex;
            }
        }

        protected async override Task<bool> OnDoOfflineProcessing() {
            try {
                return await OfflineLoginCheck();
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion

        private async Task<bool> CheckLogin() {
            if (await ValidateFields()) {
                return await LoadData();
            } else {
                return false;
            }
        }

        private async Task<bool> ValidateFields() {
            if (string.IsNullOrEmpty(UserId.Trim()) && string.IsNullOrEmpty(Password.Trim())) {
                await DisplayMessage(MessageType.Validation, Message.CAP_LOGIN, Message.MSG_COM_011);
                return false;
            }

            if (string.IsNullOrEmpty(UserId.Trim())) {
                await DisplayMessage(MessageType.Validation, Message.CAP_LOGIN, Message.MSG_COM_012);
                return false;
            }

            if (string.IsNullOrEmpty(Password.Trim())) {
                await DisplayMessage(MessageType.Validation, Message.CAP_LOGIN, Message.MSG_COM_013);
                return false;
            }

            return true;
        }

        private async Task<bool> LoadData() {
            try {
                bool result = false;
                ShowActivityIndicator(Message.CAP_LOADING);
                result = await ConnectionDecider.Instance.DoProcessing(2, this);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<bool> OnlineLoginCheck() {
            try {
                _user.UserName = UserId;
                _user.Password = Password;
                // #Todo#
                //_user = await _loginService.Login(_user);

                if (_user == null) {
                    await DisplayMessage(MessageType.Validation, Message.CAP_LOGIN, Message.ERR_UNABLE_TO_CONNECT);
                    return false;
                }
                _user.Password = Password;

                return await SaveUser();

            } catch (Exception) {
                await DisplayMessage(MessageType.Validation, Message.CAP_LOGIN, Message.ERR_UNABLE_TO_CONNECT);
                return false;
            }
        }

        private async Task<bool> SaveUser() {
            try {
                await _midwifeDataService.SaveItemAsync(_user);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        private async Task NavigateToHomePage() {
            await CommonFunction.CreateAppMenuGroup();
            HideActivityIndicator();
            await NavigationService.NavigateAsync("app:///TransitionNavigationPage/HomePage");
        }


        public async Task<bool> OfflineLoginCheck() {
            bool result = false;
            if (await ValidateFields()) {
                ShowActivityIndicator(Message.CAP_LOADING);
                await Task.Run(() => { Thread.Sleep(2000); });
                Midwife localUser = (await _midwifeDataService.GetItemsAsync<Midwife>(i => i.UserName == UserId.ToUpper())).FirstOrDefault();
                HideActivityIndicator();
                if (localUser == null) {
                    await OnlineLoginCheck();
                } else if (localUser.UserName != UserId) {
                    await DisplayMessage(MessageType.Validation, Message.CAP_LOGIN, Message.MSG_COM_014);
                    // (Cryptography.Instance.DecryptString(localUser.Password) != Password)
                } else if (localUser.UserName == UserId && (localUser.Password != Password)) {
                    await DisplayMessage(MessageType.Validation, Message.CAP_LOGIN, Message.MSG_COM_014);
                } else {
                    GlobalSetting.Instance.User = localUser;
                    await NavigateToHomePage();
                    result = true;
                }
                HideActivityIndicator();
            }
            return result;
        }

        #endregion

    }
}
