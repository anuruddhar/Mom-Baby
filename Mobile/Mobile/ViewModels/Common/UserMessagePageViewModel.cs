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
using Mobile.Enum;
using Mobile.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
#endregion

namespace Mobile.ViewModels {
    public class UserMessagePageViewModel : PopupBaseViewModel {

        #region Private Variables
        private MessageType _messageType;
        private string _messageTitle;
        private string _message;
        private string _messageImage;
        private bool _isShowButton = false;
        private bool _isMessage;
        private bool _isConfirm;
        private bool _result;
        private bool _isYesNo;
        private string _confirmationForFunctionCode;
        #endregion

        #region Properties
        public ICommand OkButtonCommand { get; private set; }
        public ICommand ConfirmButtonCommand { get; private set; }
        public ICommand CancelButtonCommand { get; private set; }

        public MessageType MessageType {
            get { return _messageType; }
            set { SetProperty(ref _messageType, value); }
        }

        public string MessageTitle {
            get { return _messageTitle; }
            set { SetProperty(ref _messageTitle, value); }
        }

        public string Message {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string MessageImage {
            get { return _messageImage; }
            set { SetProperty(ref _messageImage, value); }
        }

        public bool IsShowButton {
            get { return _isShowButton; }
            set { SetProperty(ref _isShowButton, value); }
        }

        public bool IsMessage {
            get { return _isMessage; }
            set { SetProperty(ref _isMessage, value); }
        }

        public bool IsConfirm {
            get { return _isConfirm; }
            set { SetProperty(ref _isConfirm, value); }
        }
        #endregion

        #region Constructor
        public UserMessagePageViewModel(INavigationService navigationService,
                                        IEventAggregator eventAggregator,
                                        IUserDialogs dialogs,
                                        ICommonFunction commonFunction)
                : base(navigationService, eventAggregator, dialogs, commonFunction) {
            OkButtonCommand = new DelegateCommand(OnOkClicked);
            ConfirmButtonCommand = new DelegateCommand(OnConfirm);
            CancelButtonCommand = new DelegateCommand(OnCancel);
        }
        #endregion

        #region Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                await Task.Run(() => {
                    MessageType = (MessageType)parameters[AppConstant.NavigationParameterName.MESSAGE_TYPE];
                    MessageTitle = (string)parameters[AppConstant.NavigationParameterName.MESSAGE_TITLE_CODE];
                    Message = (string)parameters[AppConstant.NavigationParameterName.MESSAGE_CODE];
                    IsConfirm = (bool)parameters[AppConstant.NavigationParameterName.MESSAGE_IS_CONFIRM];
                    _confirmationForFunctionCode = (string)parameters[AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE];
                    _isYesNo = (bool)parameters[AppConstant.NavigationParameterName.MESSAGE_YES_NO];
                    IsMessage = !IsConfirm;
                    SetStyleAndImage();
                    IsShowButton = true;
                });
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private void SetStyleAndImage() {
            switch (MessageType) {
                case MessageType.Error:
                    Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["ErrorButtonStyle"];
                    MessageImage = AppConstant.AppImgesSvg.IMG_ALERT_ERROR;
                    break;
                case MessageType.Warning:
                    Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["WarningButtonStyle"];
                    MessageImage = AppConstant.AppImgesSvg.IMG_ALERT_WARNING;
                    break;
                case MessageType.Message:
                    Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["InformarionButtonStyle"];
                    MessageImage = AppConstant.AppImgesSvg.IMG_ALERT_MESSAGE;
                    break;
                case MessageType.Validation:
                    Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["ErrorButtonStyle"];
                    MessageImage = AppConstant.AppImgesSvg.IMG_ALERT_DENIED;
                    break;
                case MessageType.Sucesss:
                    Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["SucessButtonStyle"];
                    MessageImage = AppConstant.AppImgesSvg.IMG_ALERT_SUCESS;
                    break;
                case MessageType.Question:
                    Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["WarningButtonStyle"];
                    MessageImage = AppConstant.AppImgesSvg.IMG_ALERT_QUESTION;
                    break;
                case MessageType.Nothing:
                    Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["InformarionButtonStyle"];
                    MessageImage = AppConstant.AppImgesSvg.IMG_ALERT_MESSAGE;
                    break;
                default:
                    break;
            }
        }

        private void OnOkClicked() {
            if (_confirmationForFunctionCode != string.Empty) {
                _result = true;
            }
            NavigationService.GoBackAsync();
        }

        private void OnConfirm() {
            _result = true;
            NavigationService.GoBackAsync();
        }

        private void OnCancel() {
            _result = false;
            NavigationService.GoBackAsync();
        }

        protected override void OnPageNavigatedFrom(INavigationParameters parameters) {
            parameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, _result);
            parameters.Add(AppConstant.NavigationParameterName.MESSAGE_YES_NO, _isYesNo);
            parameters.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, _confirmationForFunctionCode);
        }
        #endregion

    }
}
